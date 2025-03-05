using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        // In-memory storage for demonstration
        private static List<Quote> quotes = new List<Quote>();

        // GET: api/quotes
        [HttpGet]
        public IActionResult GetQuotes() => Ok(quotes);

        // GET: api/quotes/{id}
        [HttpGet("{id}")]
        public IActionResult GetQuoteById(int id)
        {
            var quote = quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
                return NotFound();
            return Ok(quote);
        }

        // POST: api/quotes
        [HttpPost]
        public IActionResult CreateQuote([FromBody] Quote newQuote)
        {
            newQuote.Id = quotes.Any() ? quotes.Max(q => q.Id) + 1 : 1;
            quotes.Add(newQuote);
            return CreatedAtAction(nameof(GetQuoteById), new { id = newQuote.Id }, newQuote);
        }

        // DELETE: api/quotes/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
                return NotFound();
            quotes.Remove(quote);
            return NoContent();
        }
    }

    public class Quote
    {
        public int Id { get; set; }
        public string? PersonalInfo { get; set; }
        public string? VehicleInfo { get; set; }
        public decimal QuoteAmount { get; set; }
    }
}
