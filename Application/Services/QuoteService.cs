using Domain.Entities;
using Domain.Interface;
using Infrastructure.Persistence;

namespace Application.Services
{
	public class QuoteService : IQuoteService
	{
		private readonly DataPersistence _data;

		public QuoteService(DataPersistence dataObj)
		{
			_data = dataObj;
		}

		public IEnumerable <Quote> GetQuoteById(int quoteId)
		{
			var quote = _data.Quotes.FirstOrDefault(q => q.Id == quoteId);
			if (quote != null)
			{
				return new List<Quote> { quote };
			}
			else 
			{ 
				return Enumerable.Empty<Quote>(); 
			}
		}

		public IEnumerable<Quote> GetQuoteByName(string quoteName)
		{
			var quote = _data.Quotes.Where(q => q.Author != null && q.Author.Contains(quoteName, StringComparison.OrdinalIgnoreCase));
			if (quote != null)
			{
				return quote;
			}
			else
			{
				return Enumerable.Empty<Quote>();
			}
		}

		public IEnumerable<Quote> GetQuoteList()
		{
			return _data.Quotes;
		}
	}
}
