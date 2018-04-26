using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers
{
    [Produces("application/json")]
    [Route("data/schemas")]
    public class SchemaController : Controller
    {

        // GET: data/schemas?searchQuery={searchQuery}&page={page}&rpp={rpp}&sort={sort}
        [HttpGet("searchQuery={searchQuery}&page={page}&rpp={rpp}&sort={sort}", Name = "GetBySearchCriteria")]
        public string GetBySearchCriteria(string searchQuery, int page, int rpp, string sort)
        {
            return "value";
        }

        // GET: data/schemas/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: data/schemas
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: data/schemas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: data/schemas/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
