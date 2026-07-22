using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioMaterias
    {
        public void AgregarMateria(Materia materia)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Materias (Nombre, CarreraId) VALUES (@nom, @carId)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@nom", materia.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@carId", materia.CarreraId));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Materia> ObtenerTodas()
        {
            System.Collections.Generic.List<Materia>lista = new System.Collections.Generic.List<Materia>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id, Nombre, CarreraId FROM Materias";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Materia
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                CarreraId = Convert.ToInt32(reader["CarreraId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public List<Materia> ObtenerPorCarrera(int carreraId)
        {
            List<Materia> lista = new List<Materia>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id, Nombre, CarreraId FROM Materias WHERE CarreraId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", carreraId));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Materia
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                CarreraId = Convert.ToInt32(reader["CarreraId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

