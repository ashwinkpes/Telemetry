﻿using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Telemetry.Api.Graphlql;

namespace Telemetry.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        private readonly ILogger<GraphQLController> _logger;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter, ILogger<GraphQLController> logger)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _logger = logger;
        }

        /// <summary>
        /// Performs GraphQL queries.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///	query TelemetryQuery
        ///	{
        ///	 deviceQuery {
        ///	 allDevices {
        ///		 deviceId,
        ///		 deviceName
        ///                 }
        ///		     }
        ///	}
        ///
        /// </remarks>
        /// <param name="query"></param>   
        /// <returns>A status code indicating success or failure</returns>
        /// <response code="200">Returns the success code 200 if query executed successfully</response>
        /// <response code="400">Returns the Badrequest code 400 if errors found in response</response>            
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null) {throw new ArgumentNullException(nameof(query)); }

            this._logger.LogInformation($"----Query----  {query.Query}");
            this._logger.LogInformation($"----Variables----  {query.Variables}");

            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            this._logger.LogInformation($"----Data----  {JsonConvert.SerializeObject(result.Data)}");

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
       
    }
}