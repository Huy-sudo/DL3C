using AutoMapper;
using DL3C_API.Business.Node.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DL3C_API.Business.Node.Controller
{
    /// <summary>
    /// Handle requests related to Node.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly INodeSvc _nodeSvc;

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeController"/> class.
        /// </summary>
        /// <param name="nodeSvc">Injection of <see cref="INodeSvc"/>.</param>
        public NodeController(INodeSvc nodeSvc)
        {
            this._nodeSvc = nodeSvc;
        }

        /// <summary>
        /// Endpoint for get all nodes with some conditions
        /// </summary>
        /// <returns>List of nodes.</returns>
        /// <response code="200">Returns the list of nodes.</response>
        /// <response code="204">Returns if list of nodes is empty.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Data.Source.Node), StatusCodes.Status200OK)]
        public IActionResult GetNodes()
        {
            IQueryable<Data.Source.Node> queryNode = this._nodeSvc.GetNodes();

            if (!queryNode.ToList().Any())
            {
                return this.NoContent();
            }

            return this.Ok(queryNode.ToList());
        }
    }
}