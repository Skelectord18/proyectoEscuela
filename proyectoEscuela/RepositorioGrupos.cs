using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioGrupos
    {
        public List<Grupo> ObtenerPorCarrera(int carreraId)
        {
            List<Grupo> lista = new List<Grupo>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT Id, Nombre, CarreraId FROM Grupos WHERE CarreraId = @carId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@carId", carreraId));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Grupo
                            {
                                Id = Convert.ToInt32(reader["id"]),
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