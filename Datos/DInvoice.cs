using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DInvoice
    {


        // Configurar la cadena de conexión a tu base de datos
        public static string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS ;Initial Catalog=Tecsup;User ID=erika;Password= ";


        public List<Invoice> Get() {

            List<Invoice> result=new  List<Invoice>();

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "ListarInvoice";

                // Crear un comando para ejecutar el procedimiento almacenado
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                     

                        // Leer los datos y agregarlos a la lista de productos
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice()
                            {
                                invoice_id = Convert.ToInt32(reader["invoice_id"]),
                                customer_id = Convert.ToInt32(reader["customer_id"]),
                                date = Convert.ToDateTime(reader["date"]),
                                total = Convert.ToDecimal(reader["total"]),

                            };

                            result.Add(invoice);
                        }


                    }
                }
                connection.Close();
            }
            return result;
        }
    }
    

}
    

