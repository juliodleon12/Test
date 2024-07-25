using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuoteController : ControllerBase
	{
		private readonly IQuoteService _quoteService;

		public QuoteController(IQuoteService quoteService)
		{
			this._quoteService = quoteService;
		}

		[HttpGet]
		public IEnumerable<Quote> GetQuoteList()
		{
			return _quoteService.GetQuoteList();
		}

		[HttpGet("ById/{id}")]
		public IEnumerable<Quote> GetQuoteById(int id) 
		{ 
			return _quoteService.GetQuoteById(id);
		}

		[HttpGet("ByName/{name}")]
		public IEnumerable<Quote> GetQuoteByName(string name)
		{
			return _quoteService.GetQuoteByName(name);
		}

		[HttpPost]
		public IActionResult SaveQuote([FromBody] Quote quote)
		{
			var res = _quoteService.SaveQuote(quote);
			return StatusCode(StatusCodes.Status201Created, new {mensaje = "Add Successful"});
		}

		[HttpPut]
		public IActionResult UpdateQuote([FromBody] Quote quote)
		{
			var res = _quoteService.UpdateQuote(quote);
			return StatusCode(StatusCodes.Status201Created, new { message = "Update Succesful" });
		}

	}
}
