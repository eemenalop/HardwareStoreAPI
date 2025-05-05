using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingSystem.Data;
using billingSystem.Models;
using billingSystem.Services.InvoiceService;
using billingSystem.Services.InvoiceDetailService;

namespace billingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoicesDetailsController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        // GET: api/invoiceDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllInvoicesDetail()
        {
            try
            {
                var invoiceDetail = await _invoiceDetailService.GetAllInvoicesDetail();
                return Ok(invoiceDetail);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/invoiceDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetInvoicesDetailById(int id)
        {
            try
            {
                var invoiceDetail = await _invoiceDetailService.GetInvoicesDetailById(id);

                if (invoiceDetail == null)
                {
                    return NotFound();
                }

                return Ok(invoiceDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/invoiceDetail
        [HttpPost]
        public async Task<ActionResult<Item>> CreateInvoicesDetail(InvoicesDetail newInvoiceDetail)
        {
            try
            {
                var invoiceDetail = await _invoiceDetailService.CreateInvoicesDetail(newInvoiceDetail);
                return CreatedAtAction(nameof(GetInvoicesDetailById), new { id = invoiceDetail.Id }, invoiceDetail);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/invoiceDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoicesDetail(int id, InvoicesDetail updatedInvoiceDetail)
        {
            try
            {
                var invoiceDetail = await _invoiceDetailService.UpdateInvoicesDetail(id, updatedInvoiceDetail);
                return Ok(invoiceDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/invoiceDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoicesDetail(int id)
        {
            try
            {
                await _invoiceDetailService.DeleteInvoicesDetail(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
