using Domain.Entities;
namespace Domain.Interface
{
	public interface IQuoteService
	{
		IEnumerable<Quote> GetQuoteList();
		IEnumerable <Quote> GetQuoteById(int quoteId);
		IEnumerable <Quote> GetQuoteByName(string quoteName);
		int SaveQuote(Quote quote);
		int UpdateQuote(Quote quote);
	}
}
