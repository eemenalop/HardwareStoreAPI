using billingSystem.Dtos.EmployeeDtos;
using billingSystem.Models;
using billingSystem.Dtos.InvoiceDtos;

namespace billingSystem.Services.InvoiceService
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoices();

        Task<Invoice?> GetInvoiceById(int id);

        Task<Invoice> CreateInvoice(CreateInvoiceDto newInvoice);

        Task<Invoice?> UpdateInvoice(int id, UpdateInvoiceDto updatedInvoice);

        Task DeleteInvoice(int id);
    }
}
