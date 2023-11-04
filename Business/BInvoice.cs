using Datos;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BInvoice
    {

        public List<Invoice> GetByDate(DateTime date)
        {
            DInvoice data = new DInvoice();
            var invoices = data.Get();
          //   var result = invoices.Where(x => x.date == date).ToList();
            return invoices;
        }



        public void DeleteInvoice(int id)
        {
            DInvoice data = new DInvoice();
            data.DeleteInvoice(id);
        }

        public void CreateInvoice(Invoice invoice)
        {
            DInvoice data = new DInvoice();
            data.CreateInvoice(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            DInvoice data = new DInvoice();
            data.UpdateInvoice(invoice);
        }

    }
}
