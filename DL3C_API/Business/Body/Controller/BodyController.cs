using AutoMapper;
using DL3C_API.Business.Body.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.Body.Controller
{
    /// <summary>
    /// Handle requests related to Body.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        private readonly IBodySvc _bodySvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyController"/> class.
        /// </summary>
        /// <param name="bodySvc">Injection of <see cref="IBodySvc"/>.</param>
        public BodyController(IBodySvc bodySvc)
        {
            this._bodySvc = bodySvc;
        }

        /// <summary>
        /// Endpoint for get all bodies with some conditions
        /// </summary>
        /// <returns>List of bodies.</returns>
        /// <response code="200">Returns the list of bodies.</response>
        /// <response code="204">Returns if list of bodies is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.Body), StatusCodes.Status200OK)]
        public IActionResult GetBodys()
        {
            IQueryable<Data.Source.Body> queryBody = this._bodySvc.GetBodies();
        
            if (!queryBody.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryBody.ToList());
        }
    }
}