using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioProfesor
    {
        public void AgregarProfesor(Profesor profe)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        string queryProf = "INSERT INTO Profesores (Nombre, Apellido, Edad, AñosExperiencia, MateriaId) " + "OUTPUT INSERTED.Id VALUES (@nom, @ape, @eda, @exp, @matId)";

                        int nuevoProfesorId;
                        using (SqlCommand cmd = new SqlCommand(queryProf, con, transaccion))
                        {

                            cmd.Parameters.AddWithValue("@nom", profe.Nombre);
                            cmd.Parameters.AddWithValue("@ape", profe.Apellido);
                            cmd.Parameters.AddWithValue("@eda", profe.Edad);
                            cmd.Parameters.AddWithValue("@exp", profe.AñosExperiencia);
                            cmd.Parameters.AddWithValue("@matId", profe.MateriaId);
                            nuevoProfesorId = (int)cmd.ExecuteScalar();
                        }

                        string queryPuente = "INSERT INTO Profesores_Grupos (ProfesorId, GrupoId) VALUES (@profId, @grupId)";
                        if (profe.GruposIds != null && profe.GruposIds.Count > 0)
                        {
                            foreach (int idDelGrupo in profe.GruposIds)
                            {
                                using (SqlCommand cmdPuente = new SqlCommand(queryPuente, con, transaccion))
                                {
                                    cmdPuente.Parameters.AddWithValue("@profId", nuevoProfesorId);
                                    cmdPuente.Parameters.AddWithValue("@grupId", idDelGrupo);
                                    cmdPuente.ExecuteNonQuery();
                                }
                            }
                        }
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al guardar el profesor: " + ex.Message);
                    }
                }
            }
        }

        public List<Profesor> ObtenerProfesores()
        {
            List<Profesor> lista = new List<Profesor>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id, Nombre, Apellido, Edad, AñosExperiencia, MateriaId FROM Profesores";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Profesor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                AñosExperiencia = Convert.ToInt32(reader["AñosExperiencia"]),
                                MateriaId = Convert.ToInt32(reader["MateriaId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public Profesor ObtenerPorId(int id)
        {
            Profesor prof = null;
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id, Nombre, Apellido, Edad, AñosExperiencia, MateriaId FROM Profesores WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prof = new Profesor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Edad = Convert.ToInt32(reader["Edad"]),
                                AñosExperiencia = Convert.ToInt32(reader["AñosExperiencia"]),
                                MateriaId = Convert.ToInt32(reader["MateriaId"])
                            };
                        }
                    }
                }
            }
            return prof;
        }

        public void Agregar(Profesor nuevoProfesor)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();

                string query = "INSERT INTO Profesores (Nombre, Apellido, Edad, AñosExperiencia, MateriaId) " +
                    "VALUES (@Nombre, @Apellido, @Edad, @Experiencia, @MateriaId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nuevoProfesor.Nombre);

                    cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrEmpty(nuevoProfesor.Apellido) ? "Sin Asignar" : nuevoProfesor.Apellido);
                    cmd.Parameters.AddWithValue("@Edad", nuevoProfesor.Edad == 0 ? 30 : nuevoProfesor.Edad);
                    cmd.Parameters.AddWithValue("@Experiencia", nuevoProfesor.AñosExperiencia == 0 ? 1 : nuevoProfesor.AñosExperiencia);
                    cmd.Parameters.AddWithValue("@MateriaId", nuevoProfesor.MateriaId == 0 ? 1 : nuevoProfesor.MateriaId);
                }
            }
        }
    }
}
