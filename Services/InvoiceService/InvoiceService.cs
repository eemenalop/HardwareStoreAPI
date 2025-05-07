using billingSystem.Data;
using billingSystem.Models;
using Microsoft.EntityFrameworkCore;
using billingSystem.Dtos.InvoiceDtos;

namespace billingSystem.Services.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;

        public InvoiceService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Invoice>> GetAllInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }
        public async Task<Invoice?> GetInvoiceById(int id)
        {
            var invoice = _context.Invoices.Include(i => i.InvoicesDetails).FirstOrDefaultAsync(i => i.Id == id);
            return await invoice;
        }

        public async Task<Invoice> CreateInvoice(CreateInvoiceDto newInvoice)
        {
            var invoice = new Invoice
            {
                Date = newInvoice.Date,
                IsCanceled = newInvoice.IsCanceled,
                CustomerId = newInvoice.CustomerId,
                EmployeeId = newInvoice.EmployeeId,
                Subtotal = newInvoice.Subtotal,
                TotalAmount = newInvoice.TotalAmount
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;

        }
        public async Task<Invoice?> UpdateInvoice(int id, UpdateInvoiceDto updatedInvoice)
        {
            var invoice = await GetInvoiceById(id) ?? throw new Exception($"Invoice ID: {id} not found");
            invoice.Date = updatedInvoice.Date;
            invoice.IsCanceled = updatedInvoice.IsCanceled;
            invoice.CustomerId = updatedInvoice.CustomerId;
            invoice.EmployeeId = updatedInvoice.EmployeeId;
            invoice.Subtotal = updatedInvoice.Subtotal;
            invoice.TotalAmount = updatedInvoice.TotalAmount;
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = await GetInvoiceById(id) ?? throw new Exception($"Invoice ID: {id} not found");
            invoice.IsCanceled = false;
            await _context.SaveChangesAsync();
        }



    }
}
