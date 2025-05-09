using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingSystem.Data;
using billingSystem.Models;
using billingSystem.Services.ItemService;
using billingSystem.Dtos.ItemDtos;
using Microsoft.AspNetCore.Authorization;

namespace billingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService  _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            try
            {
                var Items = await _itemService.GetAllItems();
                return Ok(Items);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            try
            {
                var item = await _itemService.GetItemById(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> CreateItem(CreateItemDto newItem)
        {
            try
            {
                var item = await _itemService.CreateItem(newItem);
                return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, UpdateItemDto updatedItem)
        {
            try
            {
                var item = await _itemService.UpdateItem(id, updatedItem);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                await _itemService.DeleteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
