using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  
        [ApiController]
        [Route("[controller]")]
        public class QuoteController
        {
            private QuoteService _quoteService;
            public QuoteController()
            {
                _quoteService = new QuoteService();
            }

            [HttpGet("Get")]
            public List<Quote> Get()
            {
                return _quoteService.GetQuote();
            }
            [HttpGet(" GetQuoteById ")]

            public List<Quote> GetQuoteById(int id)
            {
               return _quoteService.GetCategoryById(id);
            }
            [HttpPost("Add")]
            public bool Add(Quote quote)

            {
                return _quoteService.AddQuote(quote);
            }
            [HttpPut("Update")]
            public bool Update(Quote quote)
            {
                return _quoteService.UpdateQuote(quote);
            }

            [HttpDelete("Delete")]
            public void Delete(int id)
            {
                _quoteService.DeleteQuote(id);
            }
        }
    
}
