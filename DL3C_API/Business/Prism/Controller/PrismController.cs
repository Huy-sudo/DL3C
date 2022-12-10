using AutoMapper;
using DL3C_API.Business.Prism.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.Prism.Controller
{
    /// <summary>
    /// Handle requests related to Prism.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrismController : ControllerBase
    {
        private readonly IPrismSvc _prismSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrismController"/> class.
        /// </summary>
        /// <param name="prismSvc">Injection of <see cref="IPrismSvc"/>.</param>
        public PrismController(IPrismSvc prismSvc)
        {
            this._prismSvc = prismSvc;
        }

        /// <summary>
        /// Endpoint for get all prisms with some conditions
        /// </summary>
        /// <returns>List of prisms.</returns>
        /// <response code="200">Returns the list of prisms.</response>
        /// <response code="204">Returns if list of prisms is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.Prism), StatusCodes.Status200OK)]
        public IActionResult GetPrisms()
        {
            IQueryable<Data.Source.Prism> queryPrism = this._prismSvc.GetPrisms();

            if (!queryPrism.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryPrism.ToList());
        }
    }
}