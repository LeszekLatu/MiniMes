using Microsoft.AspNetCore.Mvc;
using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterController(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        // Get All Parameters
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ParameterEntity>>> GetAllParameters()
        {
            var parameters = await _parameterRepository.GetAllParameters();
            return Ok(parameters);
        }

        // Create Parameter
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ParameterEntity>> CreateParameter(ParameterEntity parameter)
        {
            var createdParameter = await _parameterRepository.CreateParameter(parameter);
            return CreatedAtAction(nameof(CreateParameter), new { id = createdParameter.Id }, createdParameter);
        }

        // Update Parameter
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<ParameterEntity>> UpdateParameter(int id, ParameterEntity updatedParameter)
        {
            var parameter = await _parameterRepository.UpdateParameter(id, updatedParameter);
            if (parameter == null)
            {
                return NotFound();
            }
            return Ok(parameter);
        }

        // Delete Parameter
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteParameter(int id)
        {
            var result = await _parameterRepository.DeleteParameter(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom Parameters
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<ParameterEntity>>> GetBottomParameters(int count)
        {
            var parameters = await _parameterRepository.GetBottomParameters(count);
            return Ok(parameters);
        }

        // Get Top Parameters
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<ParameterEntity>>> GetTopParameters(int count)
        {
            var parameters = await _parameterRepository.GetTopParameters(count);
            return Ok(parameters);
        }
    }

}
