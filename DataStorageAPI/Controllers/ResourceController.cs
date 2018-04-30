using DataStorage.Model.Common;
using DataStorage.Service.Common;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet( Name = "GetBySearchCriteria")]
        [ProducesResponseType(200, Type = typeof(IResource))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBySearchCriteria([FromQuery] string searchQuery, [FromQuery] int page, [FromQuery] int rpp, [FromQuery] string sort)
        {
            IResource resource = null; //await this.ResourceService.GetBySearchCriteria(searchQuery,page,rpp,sort);
            if (resource != null)
            {
                return Ok(new { result = resource });
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
        public async Task<IActionResult> Get(string schemaName, int id)
        {
            IResource resource = null; //await this.ResourceService.Get(id);
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
        public async Task<IActionResult> Post(string schemaName, [FromBody] IResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IResource newResource = null;//await this.ResourceService.Create(resource);

            return Created(Url.RouteUrl(newResource.Id), newResource.Id);
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

            IResource newResource = null;//await this.ResourceService.Update(resource);

            if (newResource != null)
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
        public async Task<IActionResult> Delete(string schemaName, int id)
        {
            IResource newResource = null;//await this.ResourceService.Delete(resource);

            if (newResource != null)
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
