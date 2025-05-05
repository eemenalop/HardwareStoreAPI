using billingSystem.Data;
using billingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace billingSystem.Services.InvoiceDetailService
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly AppDbContext _context;
        public InvoiceDetailService(AppDbContext context) { 
            _context = context;
        }
        public async Task<List<InvoicesDetail>> GetAllInvoicesDetail()
        {
            return await _context.InvoicesDetails.ToListAsync();
        }
        public async Task<InvoicesDetail?> GetInvoicesDetailById(int id)
        {
            var invoiceDetail = _context.InvoicesDetails.FirstOrDefaultAsync(i => i.Id == id);
            return await invoiceDetail;
        }
        public async Task<InvoicesDetail> CreateInvoicesDetail(InvoicesDetail newInvoiceDetail)
        {
            var invoiceDetail = new InvoicesDetail
            {
                InvoiceId = newInvoiceDetail.InvoiceId,
                ItemId = newInvoiceDetail.ItemId,
                Quantity = newInvoiceDetail.Quantity,
            };

            _context.InvoicesDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();
            return invoiceDetail;
        }
        public async Task<InvoicesDetail?> UpdateInvoicesDetail(int id, InvoicesDetail updatedInvoicesDetail)
        {
            var invoiceDetail = await GetInvoicesDetailById(id) ?? throw new Exception($"InvoiceDetail ID: {id} not found");
            invoiceDetail.InvoiceId = updatedInvoicesDetail.InvoiceId;
            invoiceDetail.ItemId = updatedInvoicesDetail.ItemId;
            invoiceDetail.Quantity = updatedInvoicesDetail.Quantity;
            await _context.SaveChangesAsync();
            return invoiceDetail;
        }
        public async Task DeleteInvoicesDetail(int id)
        {
            var invoiceDetail = await GetInvoicesDetailById(id) ?? throw new Exception($"InvoiceDetail ID: {id} not found");
            _context.InvoicesDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();
        }



    }
}
