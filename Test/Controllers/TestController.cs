using Microsoft.AspNetCore.Mvc;
using Test.Data;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataObj _data;

        public TestController(DataObj data)
        {
            _data = data;
        }

        [HttpGet]
        [Route("GetAllData")]
        public ActionResult<List<QuoteModel>> GetAllData()
        {
            return _data.Quotes.ToList();
        }

        [HttpGet("GetDataById/{id}")]
        public ActionResult<QuoteModel> GetDataById(int id)
        {
            return _data.Quotes.FirstOrDefault(q => q.Id == id);
        }

        [HttpGet("GetByAuthor")]
        public ActionResult<List<QuoteModel>> GetByauthor(string autor)
        {
            return _data.Quotes.Where(q => q.Author != null &&  q.Author.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
