using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly WebAppDbContext _dbContext;
        public ProcessRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProcessEntity>> GetAllProcesses()
        {
            var processes = await _dbContext.Proceses.ToListAsync();
            return processes;
        }

        public async Task<ProcessEntity> CreateProcess(ProcessEntity process)
        {
            _dbContext.Proceses.Add(process);
            await _dbContext.SaveChangesAsync();
            return process;
        }

        public async Task<ProcessEntity> UpdateProcess(int id, ProcessEntity updatedProcess)
        {
            var process = await _dbContext.Proceses.FindAsync(id);
            if (process == null)
            {
                return null;
            }

            process.SerialNumber = updatedProcess.SerialNumber;
            process.OrderId = updatedProcess.OrderId;
            process.Status = updatedProcess.Status;
            process.DateTime = updatedProcess.DateTime;

            await _dbContext.SaveChangesAsync();
            return process;
        }

        public async Task<bool> DeleteProcess(int id)
        {
            var process = await _dbContext.Proceses.FindAsync(id);
            if (process == null)
            {
                return false;
            }

            _dbContext.Proceses.Remove(process);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProcessEntity>> GetBottomProcesses(int count)
        {
            return await _dbContext.Proceses
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<ProcessEntity>> GetTopProcesses(int count)
        {
            return await _dbContext.Proceses
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }
}
