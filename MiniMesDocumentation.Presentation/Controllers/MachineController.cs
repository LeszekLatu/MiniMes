using Microsoft.AspNetCore.Mvc;
using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        // Get All Machines
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<MachineEntity>>> GetAllMachines()
        {
            var machines = await _machineRepository.GetAllMachines();
            return Ok(machines);
        }

        // Create Machine
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<MachineEntity>> CreateMachine(MachineEntity machine)
        {
            var createdMachine = await _machineRepository.CreateMachine(machine);
            return CreatedAtAction(nameof(CreateMachine), new { id = createdMachine.Id }, createdMachine);
        }

        // Update Machine
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<ActionResult<MachineEntity>> UpdateMachine(int id, MachineEntity updatedMachine)
        {
            var machine = await _machineRepository.UpdateMachine(id, updatedMachine);
            if (machine == null)
            {
                return NotFound();
            }
            return Ok(machine);
        }

        // Delete Machine
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var result = await _machineRepository.DeleteMachine(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Get Bottom Machines
        [HttpGet]
        [Route("GetBottom/{count}")]
        public async Task<ActionResult<IEnumerable<MachineEntity>>> GetBottomMachines(int count)
        {
            var machines = await _machineRepository.GetBottomMachines(count);
            return Ok(machines);
        }

        // Get Top Machines
        [HttpGet]
        [Route("GetTop/{count}")]
        public async Task<ActionResult<IEnumerable<MachineEntity>>> GetTopMachines(int count)
        {
            var machines = await _machineRepository.GetTopMachines(count);
            return Ok(machines);
        }
    }


}
