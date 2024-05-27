using Microsoft.AspNetCore.Mvc;
using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using MiniMesDocumentation.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesDocumentation.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParameterValueController : ControllerBase
    {
        private readonly IParameterValueRepository _parameterValueRepository;

        public ParameterValueController(IParameterValueRepository parameterValueRepository)
        {
            _parameterValueRepository = parameterValueRepository;
        }

        // Get All ParameterValues
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ParameterValueEntity>>> GetAllParameterValues()
        {
            var parameterValues = await _parameterValueRepository.GetAllParameterValues();
            return Ok(parameterValues);
        }

        // Create ParameterValue
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ParameterValueEntity>> CreateParameterValue(ParameterValueEntity parameterValue)
        {
            var createdParameterValue = await _parameterValueRepository.CreateParameterValue(parameterValue);
            return CreatedAtAction(nameof(CreateParameterValue), new { id = createdParameterValue.Id }, createdParameterValue);
        }

        // Update ParameterValue
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<ParameterValueEntity>> UpdateParameterValue(int id, ParameterValueEntity updatedParameterValue)
        {
            var parameterValue = await _parameterValueRepository.UpdateParameterValue(id, updatedParameterValue);
            if (parameterValue == null)
            {
                return NotFound();
            }
            return Ok(parameterValue);
        }

        // Delete ParameterValue
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteParameterValue(int id)
        {
            var result = await _parameterValueRepository.DeleteParameterValue(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom ParameterValues
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<ParameterValueEntity>>> GetBottomParameterValues(int count)
        {
            var parameterValues = await _parameterValueRepository.GetBottomParameterValues(count);
            return Ok(parameterValues);
        }

        // Get Top ParameterValues
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<ParameterValueEntity>>> GetTopParameterValues(int count)
        {
            var parameterValues = await _parameterValueRepository.GetTopParameterValues(count);
            return Ok(parameterValues);
        }
    }

}
