using AutoMapper;
using DL3C_API.Business.Building.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.Building.Controller
{
    /// <summary>
    /// Handle requests related to Building.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingSvc _buildingSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingController"/> class.
        /// </summary>
        /// <param name="buildingSvc">Injection of <see cref="IBuildingSvc"/>.</param>
        public BuildingController(IBuildingSvc buildingSvc)
        {
            this._buildingSvc = buildingSvc;
        }

        /// <summary>
        /// Endpoint for get all buildings with some conditions
        /// </summary>
        /// <returns>List of buildings.</returns>
        /// <response code="200">Returns the list of buildings.</response>
        /// <response code="204">Returns if list of buildings is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.Building), StatusCodes.Status200OK)]
        public IActionResult GetBuildings()
        {
            IQueryable<Data.Source.Building> queryBuilding = this._buildingSvc.GetBuildings();

            if (!queryBuilding.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryBuilding.ToList());
        }
    }
}