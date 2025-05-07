using billingSystem.Models;

namespace billingSystem.Services.InvoiceDetailService
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoicesDetail>> GetAllInvoicesDetail();

        Task<InvoicesDetail?> GetInvoicesDetailById(int id);

        Task<SimpleResponse<InvoicesDetail>> CreateInvoicesDetail(CreateInvoiceDetailDto newInvoiceDetail);

        Task<InvoicesDetail?> UpdateInvoicesDetail(int id, UpdateInvoiceDetailDto updatedInvoicesDetail);

        Task DeleteInvoicesDetail(int id);
    }
}
