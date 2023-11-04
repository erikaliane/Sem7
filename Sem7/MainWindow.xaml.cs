using Business;
using Entity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sem7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BInvoice bInvoice = new BInvoice();
        

        private void DeleteInvoice(object sender, RoutedEventArgs e)
        {
            int invoiceId = (int)((Button)sender).CommandParameter;
            bInvoice.DeleteInvoice(invoiceId);
            ListInvoice();
        }

        private void Listar(object sender, RoutedEventArgs e)
        {
            BInvoice invoice = new BInvoice();

            dataGrid.ItemsSource = invoice.GetByDate(DateTime.Now);

        }

        private void ListInvoice()
        {
            BInvoice invoice = new BInvoice();

            dataGrid.ItemsSource = invoice.GetByDate(DateTime.Now);

        }

        private void Registrar(object sender, RoutedEventArgs e)
        {
            // Crear una nueva factura con los datos ingresados
            Invoice newInvoice = new Invoice
            {
                customer_id = int.Parse(txtCustomerId.Text),
                date = dpDate.SelectedDate ?? DateTime.Now,
                total = decimal.Parse(txtTotal.Text),
                active = 1 // Puedes establecer el valor activo según tus necesidades
            };

            bInvoice.CreateInvoice(newInvoice);
            ListInvoice();
        }

        private void EditarRegistro(object sender, RoutedEventArgs e)
        {
            Invoice selectedInvoice = (Invoice)((Button)sender).CommandParameter;
            if (selectedInvoice != null)
            {
                txtCustomerId.Text = selectedInvoice.customer_id.ToString();
                dpDate.SelectedDate = selectedInvoice.date;
                txtTotal.Text = selectedInvoice.total.ToString();
            }
        }



    }
}
