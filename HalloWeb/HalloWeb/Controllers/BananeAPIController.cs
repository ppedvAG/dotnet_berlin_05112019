using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalloWeb.Models;

namespace HalloWeb.Controllers
{

    public interface IEi
    {
        public string Endiness { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BananeAPIController : ControllerBase
    {
        private readonly BananenContext _context;

        public BananeAPIController(BananenContext context, IEi ei)
        {
            _context = context;

            ei.Endiness = "Big";
        }

        // GET: api/BananeAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banane>>> GetBanane()
        {
            return await _context.Banane.ToListAsync();
        }

        // GET: api/BananeAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banane>> GetBanane(int id)
        {
            var banane = await _context.Banane.FindAsync(id);

            if (banane == null)
            {
                return NotFound();
            }

            return banane;
        }

        // PUT: api/BananeAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanane(int id, Banane banane)
        {
            if (id != banane.Id)
            {
                return BadRequest();
            }

            _context.Entry(banane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BananeExists(id))
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

        // POST: api/BananeAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Banane>> PostBanane(Banane banane)
        {
            _context.Banane.Add(banane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanane", new { id = banane.Id }, banane);
        }

        // DELETE: api/BananeAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banane>> DeleteBanane(int id)
        {
            var banane = await _context.Banane.FindAsync(id);
            if (banane == null)
            {
                return NotFound();
            }

            _context.Banane.Remove(banane);
            await _context.SaveChangesAsync();

            return banane;
        }

        private bool BananeExists(int id)
        {
            return _context.Banane.Any(e => e.Id == id);
        }
    }
}
