using billingSystem.Dtos.EmployeeDtos;
using billingSystem.Models;

namespace billingSystem.Services.InvoiceService
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetAllInvoices();

        Task<Invoice?> GetInvoiceById(int id);

        Task<Invoice> CreateInvoice(Invoice newInvoice);

        Task<Invoice?> UpdateInvoice(int id, Invoice updatedInvoice);

        Task DeleteInvoice(int id);
    }
}
