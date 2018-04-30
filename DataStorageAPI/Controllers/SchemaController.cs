using DataStorage.Model.Common;
using DataStorage.Service.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DataStorageAPI.Controllers
{
    [Produces("application/json")]
    [Route("data/schemas")]
    public class SchemaController : Controller
    {

        #region Properties

        protected ISchemaService SchemaService { get; private set; }

        #endregion Properties

        #region Constructors

        public SchemaController(ISchemaService resourceService)
        {
            SchemaService = resourceService;
        }

        #endregion Constructors

        #region Methods

        // GET: data/schemas?searchQuery="where 'age' = 15"&page=1&rpp=15&sort=asc
        [HttpGet(Name = "GetBySearchCriteria")]
        [ProducesResponseType(200, Type = typeof(ISchema))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBySearchCriteria([FromQuery] string searchQuery, [FromQuery] int page, [FromQuery] int rpp, [FromQuery] string sort)
        {
            ISchema schema = null; //await this.SchemaService.GetBySearchCriteria(searchQuery,page,rpp,sort);
            if (schema != null)
            {
                return Ok(new { result = schema });
            }
            else
            {
                return NotFound(new { message = "Schema is not found." });
            }
        }

        // GET: data/schemas/5
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(200, Type = typeof(ISchema))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            ISchema schema = null; //await this.SchemaService.Get(id);
            if (schema != null)
            {
                return Ok(new { result = schema });
            }
            else
            {
                return NotFound(new { message = "Schema is not found." });
            }
              
        }

        // POST: data/schemas
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(ISchema))]
        public async Task<IActionResult> Post([FromBody] ISchema schema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ISchema newSchema =null;//await this.SchemaService.Create(schema);
            
            return Created(Url.RouteUrl(newSchema.Id), newSchema.Id);      
        }

        // PUT: data/schemas/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody] ISchema schema)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ISchema newSchema = null;//await this.SchemaService.Update(schema);

            if (newSchema != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "Schema is not found." });
            }
        }

        // DELETE: data/schemas/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            ISchema newSchema = null;//await this.SchemaService.Delete(schema);

            if (newSchema != null)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "Schema is not found." });
            }
        }

    #endregion Methods
    }
}
