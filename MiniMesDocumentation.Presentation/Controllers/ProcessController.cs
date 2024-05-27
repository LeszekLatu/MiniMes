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
    public class ProcessController : ControllerBase
    {
        private readonly IProcessRepository _processRepository;

        public ProcessController(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        // Get All Processes
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<ProcessEntity>>> GetAllProcesses()
        {
            var processes = await _processRepository.GetAllProcesses();
            return Ok(processes);
        }

        // Create Process
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ProcessEntity>> CreateProcess(ProcessEntity process)
        {
            var createdProcess = await _processRepository.CreateProcess(process);
            return CreatedAtAction(nameof(CreateProcess), new { id = createdProcess.Id }, createdProcess);
        }

        // Update Process
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<ProcessEntity>> UpdateProcess(int id, ProcessEntity updatedProcess)
        {
            var process = await _processRepository.UpdateProcess(id, updatedProcess);
            if (process == null)
            {
                return NotFound();
            }
            return Ok(process);
        }

        // Delete Process
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteProcess(int id)
        {
            var result = await _processRepository.DeleteProcess(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom Processes
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<ProcessEntity>>> GetBottomProcesses(int count)
        {
            var processes = await _processRepository.GetBottomProcesses(count);
            return Ok(processes);
        }

        // Get Top Processes
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<ProcessEntity>>> GetTopProcesses(int count)
        {
            var processes = await _processRepository.GetTopProcesses(count);
            return Ok(processes);
        }
    }

}
