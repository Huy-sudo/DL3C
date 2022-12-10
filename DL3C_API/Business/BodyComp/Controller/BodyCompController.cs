using AutoMapper;
using DL3C_API.Business.BodyComp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.BodyComp.Controller
{
    /// <summary>
    /// Handle requests related to BodyComp.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BodyCompController : ControllerBase
    {
        private readonly IBodyCompSvc _bodyCompSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyCompController"/> class.
        /// </summary>
        /// <param name="bodyCompSvc">Injection of <see cref="IBodyCompSvc"/>.</param>
        public BodyCompController(IBodyCompSvc bodyCompSvc)
        {
            this._bodyCompSvc = bodyCompSvc;
        }

        /// <summary>
        /// Endpoint for get all bodyComps with some conditions
        /// </summary>
        /// <returns>List of bodyComps.</returns>
        /// <response code="200">Returns the list of bodyComps.</response>
        /// <response code="204">Returns if list of bodyComps is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.BodyComp), StatusCodes.Status200OK)]
        public IActionResult GetBodyComps()
        {
            IQueryable<Data.Source.BodyComp> queryBodyComp = this._bodyCompSvc.GetBodyComps();

            if (!queryBodyComp.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryBodyComp.ToList());
        }
    }
}