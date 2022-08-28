using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Data;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public testsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<test>>> Gettest()
        {
          if (_context.test == null)
          {
              return NotFound();
          }
            return await _context.test.ToListAsync();
        }

        // GET: api/tests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<test>> Gettest(int id)
        {
          if (_context.test == null)
          {
              return NotFound();
          }
            var test = await _context.test.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // PUT: api/tests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttest(int id, test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testExists(id))
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

        // POST: api/tests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<test>> Posttest(test test)
        {
          if (_context.test == null)
          {
              return Problem("Entity set 'ApplicationDbContext.test'  is null.");
          }
            _context.test.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettest", new { id = test.Id }, test);
        }

        // DELETE: api/tests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetest(int id)
        {
            if (_context.test == null)
            {
                return NotFound();
            }
            var test = await _context.test.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.test.Remove(test);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool testExists(int id)
        {
            return (_context.test?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
