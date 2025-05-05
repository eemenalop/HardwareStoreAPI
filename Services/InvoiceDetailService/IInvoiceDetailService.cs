using billingSystem.Models;

namespace billingSystem.Services.InvoiceDetailService
{
    public interface IInvoiceDetailService
    {
        Task<List<InvoicesDetail>> GetAllInvoicesDetail();

        Task<InvoicesDetail?> GetInvoicesDetailById(int id);

        Task<InvoicesDetail> CreateInvoicesDetail(InvoicesDetail newInvoiceDetail);

        Task<InvoicesDetail?> UpdateInvoicesDetail(int id, InvoicesDetail updatedInvoicesDetail);

        Task DeleteInvoicesDetail(int id);
    }
}
