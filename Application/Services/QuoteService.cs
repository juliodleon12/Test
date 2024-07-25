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

		public int SaveQuote(Quote quote)
		{
			var lastId = _data.Quotes.LastOrDefault();
			if (lastId != null)
			{
				quote.Id = lastId.Id + 1;
			}
			_data.Quotes.Add(quote);
			return 1;
		}

		public int UpdateQuote(Quote quote)
		{
			var quoteRes = _data.Quotes.FirstOrDefault(q => q.Id == quote.Id);
			if (quoteRes != null) 
			{
				quoteRes.Text = quote.Text;
				quoteRes.Author = quote.Author;
			}
			return 1;
		}
	}
}
