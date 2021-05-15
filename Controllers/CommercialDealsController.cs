using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commercial_Adverts_Web_API.Model;
using Commercial_Adverts_Web_API.Models;

namespace Commercial_Adverts_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialDealsController : ControllerBase
    {
        private readonly Commercial_Adverts_DataContext _context;

        public CommercialDealsController(Commercial_Adverts_DataContext context)
        {
            _context = context;
        }

        // GET: api/CommercialDeals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommercialDeal>>> GetCommercialDeal()
        {
            return await _context.CommercialDeal.ToListAsync();
        }

        // GET: api/CommercialDeals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommercialDeal>> GetCommercialDeal(int id)
        {
            var commercialDeal = await _context.CommercialDeal.FindAsync(id);

            if (commercialDeal == null)
            {
                return NotFound();
            }

            return commercialDeal;
        }

        // PUT: api/CommercialDeals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommercialDeal(int id, CommercialDeal commercialDeal)
        {
            if (id != commercialDeal.Id)
            {
                return BadRequest();
            }

            _context.Entry(commercialDeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialDealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CommercialDeals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CommercialDeal>> PostCommercialDeal(CommercialDeal commercialDeal)
        {
            _context.CommercialDeal.Add(commercialDeal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommercialDeal", new { id = commercialDeal.Id }, commercialDeal);
        }

        // DELETE: api/CommercialDeals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommercialDeal>> DeleteCommercialDeal(int id)
        {
            var commercialDeal = await _context.CommercialDeal.FindAsync(id);
            if (commercialDeal == null)
            {
                return NotFound();
            }

            _context.CommercialDeal.Remove(commercialDeal);
            await _context.SaveChangesAsync();

            return commercialDeal;
        }

        private bool CommercialDealExists(int id)
        {
            return _context.CommercialDeal.Any(e => e.Id == id);
        }
    }
}
