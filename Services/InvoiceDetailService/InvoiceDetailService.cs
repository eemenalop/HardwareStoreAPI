using billingSystem.Data;
using billingSystem.Models;
using Microsoft.EntityFrameworkCore;
using billingSystem.Services.InvoiceService;
using billingSystem.Services.ItemService;

namespace billingSystem.Services.InvoiceDetailService
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly AppDbContext _context;
        private readonly IInvoiceService _invoiceService;
        private readonly IItemService _itemService;
        public InvoiceDetailService(AppDbContext context, IItemService itemService, IInvoiceService invoiceService)
        {
            _context = context;
            _itemService = itemService;
            _invoiceService = invoiceService;
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
        public async Task<SimpleResponse<InvoicesDetail>> CreateInvoicesDetail(CreateInvoiceDetailDto newInvoiceDetail)
        {
            var invoiceId = await _invoiceService.GetInvoiceById(newInvoiceDetail.InvoiceId);
            if (invoiceId == null)
            {
                return new SimpleResponse<InvoicesDetail>
                {
                    Success = false,
                    Message = "Invoice not found",
                    Data = null
                };
            }

            var itemId = await _itemService.GetItemById(newInvoiceDetail.ItemId);
            if (itemId == null)
            {
                return new SimpleResponse<InvoicesDetail>
                {
                    Success = false,
                    Message = "Item not found",
                    Data = null
                };
            }

            if (itemId.StockAvailable < newInvoiceDetail.Quantity)
            {
                return new SimpleResponse<InvoicesDetail>
                {
                    Success = false,
                    Message = "Not enough stock available",
                    Data = null
                };
            }

            var invoiceDetail = new InvoicesDetail
            {
                InvoiceId = newInvoiceDetail.InvoiceId,
                ItemId = newInvoiceDetail.ItemId,
                Quantity = newInvoiceDetail.Quantity,
            };

            _context.InvoicesDetails.Add(invoiceDetail);
            invoiceId.Subtotal += itemId.Price * newInvoiceDetail.Quantity;
            invoiceId.TotalAmount = invoiceId.Subtotal * 1.18m;
            itemId.StockAvailable -= newInvoiceDetail.Quantity;
            _context.Items.Update(itemId);
            await _context.SaveChangesAsync();

            return new SimpleResponse<InvoicesDetail>
            {
                Success = true,
                Message = "Invoice detail created successfully",
                Data = invoiceDetail
            };
        }
        public async Task<InvoicesDetail?> UpdateInvoicesDetail(int id, UpdateInvoiceDetailDto updatedInvoicesDetail)
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
