using GraphQL;
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

        [HttpPost]
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