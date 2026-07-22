using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniversidadPOO
{
    public class RepositorioDocumentosProfesor
    {
        public void AgregarDocumento(Documento doc)
        {
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO DocumentosProfesores (NombreDocumento, Estado, FechaEntrega, ProfesorId) " + "VALUES (@nom,@est,@fecha,@profId)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nom", doc.Nombre);
                    cmd.Parameters.AddWithValue("@est", doc.Estado);
                    cmd.Parameters.AddWithValue("@fecha", doc.FechaEntrega);
                    cmd.Parameters.AddWithValue("@profId", doc.PersonaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Documento> ObtenerDocumentosPorProfesor(int profesorId)
        {
            List<Documento> lista = new List<Documento>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM DocumentosProfesores WHERE ProfesorId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", profesorId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Documento
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["NombreDocumento"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]),
                                PersonaId = Convert.ToInt32(reader["ProfesorId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
               