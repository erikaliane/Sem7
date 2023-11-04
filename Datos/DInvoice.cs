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
        public static string connectionString = "Data Source=DESKTOP-DE20VUT\\SQLEXPRESS ;Initial Catalog=Tecsup;User ID=erika;Password= ";


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

        public void DeleteInvoice(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeleteInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@invoice_id", SqlDbType.Int));
                    command.Parameters["@invoice_id"].Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateInvoice(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                    command.Parameters["@customer_id"].Value = invoice.customer_id;
                    command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                    command.Parameters["@date"].Value = invoice.date;
                    command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal));
                    command.Parameters["@total"].Value = invoice.total;
                    command.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit));
                    command.Parameters["@active"].Value = invoice.active;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateInvoice(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@invoice_id", SqlDbType.Int));
                    command.Parameters["@invoice_id"].Value = invoice.invoice_id;
                    command.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                    command.Parameters["@customer_id"].Value = invoice.customer_id;
                    command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                    command.Parameters["@date"].Value = invoice.date;
                    command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal));
                    command.Parameters["@total"].Value = invoice.total;
                    command.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit));
                    command.Parameters["@active"].Value = invoice.active;

                    command.ExecuteNonQuery();
                }
            }
        }

    }


}
    

