using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.IO.Pipelines;

namespace PruebaConcepto.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<DatosInfo> listDatos = new List<DatosInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=LENIN;Initial Catalog=Prueba_concepto;Integrated Security=True;Encrypt=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Datos";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DatosInfo datosInfo = new DatosInfo();
                                datosInfo.id_datos = "" + reader.GetInt32(0);
                                datosInfo.dato = "" + reader.GetInt32(1);

                                listDatos.Add(datosInfo);
                            }
                        }
                    }
                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

    }
    public class DatosInfo 
    {
        public String id_datos;
        public String dato;
    }

}
