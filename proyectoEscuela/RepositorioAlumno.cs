using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace UniversidadPOO
{
    public class RepositorioAlumno
    {
        public void AgregarAlumno(Alumno alumno)
        {
            using (var con = DB.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Alumnos (Nombre,Apellido,Edad,CarreraId,GrupoId) VALUES (@nom,@ape,@eda,@carId,@grupId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@nom", alumno.Nombre));
                        cmd.Parameters.Add(new SqlParameter("@ape", alumno.Apellido));
                        cmd.Parameters.Add(new SqlParameter("@eda", alumno.Edad));
                        cmd.Parameters.Add(new SqlParameter("@carId", alumno.CarreraId));
                        cmd.Parameters.Add(new SqlParameter("@grupId", alumno.GrupoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        throw new Exception("Error: La carrera ingresada no existe en la base de datos.");
                    }
                    throw ex;
                }
            }
        }
        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> lista = new List<Alumno>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id,Nombre,Apellido,Edad,CarreraId,GrupoId FROM Alumnos";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while
                            (reader.Read())
                        {
                            lista.Add(new Alumno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                CarreraId = Convert.ToInt32(reader["CarreraId"]),
                                GrupoId = reader["GrupoId"] != DBNull.Value ? Convert.ToInt32(reader["GrupoId"]) : 0
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public Alumno ObtenerPorId(int id)
        {
            Alumno al = null;
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id,Nombre,Apellido,Edad,CarreraId,GrupoId FROM Alumnos WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            al = new Alumno
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                CarreraId = Convert.ToInt32(reader["CarreraId"]),
                                GrupoId = reader["GrupoId"] != DBNull.Value ? Convert.ToInt32(reader["GrupoId"]) : 0
                            };
                        }
                    }
                }
            }
            return al;
        }
        public void Agregar(Alumno nuevoAlumno)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                string query = "INSERT INTO Alumnos (Nombre, Apellido, Edad, CarreraId, GrupoId) " +
                               "VALUES (@Nombre, @Apellido, @Edad, @CarreraId, @GrupoId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevoAlumno.Nombre);

                    cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrEmpty(nuevoAlumno.Apellido) ? "Sin Asignar" : nuevoAlumno.Apellido);
                    cmd.Parameters.AddWithValue("@Edad", nuevoAlumno.Edad == 0 ? 18 : nuevoAlumno.CarreraId);
                    cmd.Parameters.AddWithValue("@CarreraId", nuevoAlumno.CarreraId == 0 ? 1 : nuevoAlumno.CarreraId);
                    cmd.Parameters.AddWithValue("@GrupoId", nuevoAlumno.GrupoId == 0 ? 1 : nuevoAlumno.GrupoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
                                