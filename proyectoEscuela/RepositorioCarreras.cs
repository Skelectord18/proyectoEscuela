using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioCarreras
    {
        public List<Carrera> ObtenerCarreras()
        {
            List<Carrera> lista = new List<Carrera>();
            using (var con = DB.GetConnection())
            {
                try
                {
                    con.Open();
                    string query = "SELECT Id,Nombre,MaxAños FROM Carreras";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Carrera
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    MaxAños = Convert.ToInt32(reader["MaxAños"])
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener carreras:" + ex.Message);
                }
            }
            return lista;
        }
        public Carrera ObtenerCarreraPorId(int id)
        {
            Carrera carreraEncontrada = null;

            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id,Nombre,MaxAños FROM Carreras WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carreraEncontrada = new Carrera
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                MaxAños = Convert.ToInt32(reader["MaxAños"])
                            };
                        }
                    }
                }
            }
            return carreraEncontrada;
        }
    }
}



        