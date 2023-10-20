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

      
        public void conexion()
        {


            // Configurar la cadena de conexión a tu base de datos
            string connectionString = "Data Source=LAB1504-16\\SQLEXPRESS ;Initial Catalog=Tecsup;User ID=erika;Password= ";

            try
            {
                // Crear una conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear un comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("ListarInvoice", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Invoice> invoices = new List<Invoice>();

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

                                invoices.Add(invoice);
                            }

                           
                        }
                    }
           }
            }
            catch (Exception ex)
            {

            }
        }
    


        public List<Invoice> Get()
        {
        }


        public void InsertInvoice(Invoice invoice) { }

        public void UpdateInvoice(Invoice invoice) { }

        public void DeleteInvoice (int invoice) { }
    }
}
