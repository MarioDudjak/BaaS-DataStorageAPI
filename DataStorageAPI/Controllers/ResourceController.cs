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
    [Route("data/resources")]
    public class ResourceController : Controller
    {

        #region Properties

        protected IResourceService ResourceService { get; private set; }

        #endregion Properties

        #region Constructors

        public ResourceController(IResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        #endregion Constructors

        #region Methods

        // GET: data/resources/myScheme?searchQuery="where 'age'=15"&page=1&rpp=10&sort=asc
        [HttpGet("{schemaName}", Name = "GetBySearchCriteria")]
        [ProducesResponseType(200, Type = typeof(ICollection<IResource>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBySearchCriteria(string schemaName, [FromQuery] string searchQuery, [FromQuery] int page, [FromQuery] int rpp, [FromQuery] string sort)
        {
            ICollection<IResource> resources = await this.ResourceService.GetBySearchCriteriaAsync("", schemaName, searchQuery, page, rpp, sort);
            if (resources.Count!=0)
            {
                return Ok(new { result = resources });
            }
            else
            {
                return NotFound(new { message = "Resource is not found." });
            }
        }
       

        // GET: data/resources/mySchema/5
        [HttpGet("{schemaName}/{id}", Name = "Get")]
        [ProducesResponseType(200, Type = typeof(IResource))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(string schemaName, Guid id)
        {
            IResource resource = await this.ResourceService.GetByIdAsync(id, "", schemaName);
            if (resource != null)
            {
                return Ok(new { result = resource });
            }
            else
            {
                return NotFound(new { message = "Resource is not found." });
            }
        }
       
        // POST: api/Resource
        [HttpPost("{schemaName}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(IResource))]
        [ProducesResponseType(409)]
        public async Task<IActionResult> Post(string schemaName, [FromBody] IResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IResource newResource = await this.ResourceService.AddAsync(resource, "", schemaName);
            if (newResource != null)
            {
                return Created(Url.RouteUrl(newResource.Id), newResource.Id);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }

        // PUT: api/Resource/5
        [HttpPut("{schemaName}/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(string schemaName, int id, [FromBody] IResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool updateSucceeded= await this.ResourceService.UpdateAsync(resource, "", schemaName);

            if (updateSucceeded != false)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "Resource is not found." });
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{schemaName}/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string schemaName, Guid id)
        {
            bool deleteSuceeded= await this.ResourceService.DeleteAsync(id, "", schemaName);

            if (deleteSuceeded != false)
            {
                return NoContent();
            }
            else
            {
                return NotFound(new { message = "Resource is not found." });
            }
        }

        #endregion Methods
    }
}
