using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungDocTruyen.Data;

namespace UngDungDocTruyen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        private readonly bookStoreContext _context;

        public booksController(bookStoreContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<book>>> Getbooks()
        {
            return await _context.books.ToListAsync();
        }

        // GET: api/books/5
        [HttpGet("{Mabook}")]
        public async Task<ActionResult<book>> Getbook(string Mabook)
        {
            var book = await _context.books.FirstOrDefaultAsync(book=>book.MaBook== Mabook);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Mabook}")]
        public async Task<IActionResult> Putbook(string Mabook, book book)
        {
            if (Mabook != book.MaBook)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(Mabook))
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

        // POST: api/books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<book>> Postbook(book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            try
            {
                _context.books.Add(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (bookExists(book.MaBook))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Getbook), new { id = book.MaBook }, book);
        }


        // DELETE: api/books/5
        [HttpDelete("{Mabook}")]
        public async Task<IActionResult> Deletebook(string Mabook)
        {
            var book = await _context.books.FirstOrDefaultAsync(book => book.MaBook == Mabook);
            if (book == null)
            {
                return NotFound();
            }

            _context.books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool bookExists(string id)
        {
            return _context.books.Any(e => e.MaBook == id);
        }
    }
}
