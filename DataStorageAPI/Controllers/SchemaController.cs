using DataStorage.Model.Common;
using DataStorage.Service.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            ICollection<ISchema> schemas = await this.SchemaService.GetBySearchCriteriaAsync("",searchQuery,page,rpp,sort);
            if (schemas.Count!=0)
            {
                return Ok(new { result = schemas });
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
        public async Task<IActionResult> Get(Guid id)
        {
            ISchema schema = await this.SchemaService.GetByIdAsync(id, "");
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
        [ProducesResponseType(409)]
        public async Task<IActionResult> Post([FromBody] ISchema schema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ISchema newSchema = await this.SchemaService.AddAsync(schema,"");
            if (newSchema != null)
            {
                return Created(Url.RouteUrl(newSchema.Id), newSchema.Id);      // Tu još treba vidjet jel Id ili Name
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
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

            bool updateSucceeded =  await this.SchemaService.UpdateAsync(schema, "");

            if (updateSucceeded != false)
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
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleteSucceeded = await this.SchemaService.DeleteAsync(id,"");

            if (deleteSucceeded != false)
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
