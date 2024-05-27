using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MiniMesDocumentation.Infrastructure;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class ParameterValueRepository : IParameterValueRepository
    {
        private readonly WebAppDbContext _dbContext;
        public ParameterValueRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ParameterValueEntity>> GetAllParameterValues()
        {
            var parameterValues = await _dbContext.ParameterValues.ToListAsync();
            return parameterValues.Cast<ParameterValueEntity>().ToList();
        }

        public async Task<ParameterValueEntity> CreateParameterValue(ParameterValueEntity parameterValue)
        {
            _dbContext.ParameterValues.Add(parameterValue);
            await _dbContext.SaveChangesAsync();
            return parameterValue;
        }

        public async Task<ParameterValueEntity> UpdateParameterValue(int id, ParameterValueEntity updatedParameterValue)
        {
            var parameterValue = await _dbContext.ParameterValues.FindAsync(id);
            if (parameterValue == null)
            {
                return null;
            }

            parameterValue.ProcessId = updatedParameterValue.ProcessId;
            parameterValue.ParameterId = updatedParameterValue.ParameterId;
            parameterValue.Value = updatedParameterValue.Value;

            await _dbContext.SaveChangesAsync();
            return parameterValue;
        }

        public async Task<bool> DeleteParameterValue(int id)
        {
            var parameterValue = await _dbContext.ParameterValues.FindAsync(id);
            if (parameterValue == null)
            {
                return false;
            }

            _dbContext.ParameterValues.Remove(parameterValue);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ParameterValueEntity>> GetBottomParameterValues(int count)
        {
            return await _dbContext.ParameterValues
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<ParameterValueEntity>> GetTopParameterValues(int count)
        {
            return await _dbContext.ParameterValues
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }

}