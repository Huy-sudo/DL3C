using AutoMapper;
using DL3C_API.Business.Face.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.Face.Controller
{
    /// <summary>
    /// Handle requests related to Face.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {
        private readonly IFaceSvc _faceSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="FaceController"/> class.
        /// </summary>
        /// <param name="faceSvc">Injection of <see cref="IFaceSvc"/>.</param>
        public FaceController(IFaceSvc faceSvc)
        {
            this._faceSvc = faceSvc;
        }

        /// <summary>
        /// Endpoint for get all faces with some conditions
        /// </summary>
        /// <returns>List of faces.</returns>
        /// <response code="200">Returns the list of faces.</response>
        /// <response code="204">Returns if list of faces is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.Face), StatusCodes.Status200OK)]
        public IActionResult GetFaces()
        {
            IQueryable<Data.Source.Face> queryFace = this._faceSvc.GetFaces();

            if (!queryFace.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryFace.ToList());
        }
    }
}