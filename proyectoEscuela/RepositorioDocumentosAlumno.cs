using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversidadPOO
{
    public class RepositorioDocumentosAlumno
    {
                    public void AgregarDocumento(Documento doc)
                {
                    using (var con = DB.GetConnection())
                    {
                        con.Open();

                        string query = "INSERT INTO DocumentosAlumnos (NombreDocumento, Estado, FechaEntrega,AlumnoId)" + "VALUES(@nom, @est, @fecha, @alumId)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@nom", doc.Nombre);
                            cmd.Parameters.AddWithValue("@est", doc.Estado);
                            cmd.Parameters.AddWithValue("@fecha", doc.FechaEntrega);
                            cmd.Parameters.AddWithValue("@alumId", doc.PersonaId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

        public List<Documento> ObtenerDocumentosPorAlumno(int alumnoId)
        {
            List<Documento> lista = new List<Documento>();
            using (var con = DB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM DocumentosAlumnos WHERE AlumnoId = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", alumnoId));
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
                                PersonaId = Convert.ToInt32(reader["AlumnoId"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
