using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly WebAppDbContext _dbContext;
        public MachineRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MachineEntity>> GetAllMachines()
        {
            var machine = await _dbContext.Machines.ToListAsync();
            return machine.Cast<MachineEntity>().ToList();
        }

        public async Task<MachineEntity> CreateMachine(MachineEntity machine)
        {
            _dbContext.Machines.Add(machine);
            await _dbContext.SaveChangesAsync();
            return machine;
        }

        public async Task<MachineEntity> UpdateMachine(int id, MachineEntity updatedMachine)
        {
            var machine = await _dbContext.Machines.FindAsync(id);
            if (machine == null)
            {
                return null; 
            }

            machine.Id = updatedMachine.Id;
            machine.Name = updatedMachine.Name;
            machine.Description = updatedMachine.Description;
            

            await _dbContext.SaveChangesAsync();
            return machine;
        }

        public async Task<bool> DeleteMachine(int id)
        {
            var machine = await _dbContext.Machines.FindAsync(id);
            if (machine == null)
            {
                return false; 
            }

            _dbContext.Machines.Remove(machine);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MachineEntity>> GetBottomMachines(int count)
        {
            return await _dbContext.Machines
                .OrderBy(m => m.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<MachineEntity>> GetTopMachines(int count)
        {
            return await _dbContext.Machines
                .OrderByDescending(m => m.Id)
                .Take(count)
                .ToListAsync();
        }





    }
}