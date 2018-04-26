using Microsoft.AspNetCore.Mvc;

namespace DataStorageAPI.Controllers
{
    [Produces("application/json")]
    [Route("data/resources")]
    public class ResourceController : Controller
    {



        // GET: data/resources/{schemaName}?searchQuery={searchQuery}&page={page}&rpp={rpp}&sort={sort}
        [HttpGet("{schemaName}?searchQuery={searchQuery}&page={page}&rpp={rpp}&sort={sort}", Name = "GetBySearchCriteria")]
        public string GetBySearchCriteria(string schemaName, string searchQuery, int page, int rpp, string sort)
        {
            return "value";
        }


        // GET: data/resources/{schemaName}/5
        [HttpGet("{schemaName}/{id}", Name = "Get")]
        public string Get(string schemaName, int id)
        {
            return "value";
        }

        // POST: api/Resource
        [HttpPost("{schemaName}")]
        public void Post(string schemaName, [FromBody]string value)
        {
        }

        // PUT: api/Resource/5
        [HttpPut("{schemaName}/{id}")]
        public void Put(string schemaName, int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{schemaName}/{id}")]
        public void Delete(string schemaName, int id)
        {
        }
    }
}
