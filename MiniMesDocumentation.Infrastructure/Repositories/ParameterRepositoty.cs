using MiniMesDocumentation.Application.Contracts;
using MiniMesDocumentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniMesDocumentation.Infrastructure.Repositories
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly WebAppDbContext _dbContext;
        public ParameterRepository(WebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ParameterEntity>> GetAllParameters()
        {
            var parameters = await _dbContext.Parameters.ToListAsync();
            return parameters.Cast<ParameterEntity>().ToList();
        }

        public async Task<ParameterEntity> CreateParameter(ParameterEntity parameter)
        {
            _dbContext.Parameters.Add(parameter);
            await _dbContext.SaveChangesAsync();
            return parameter;
        }

        public async Task<ParameterEntity> UpdateParameter(int id, ParameterEntity updatedParameter)
        {
            var parameter = await _dbContext.Parameters.FindAsync(id);
            if (parameter == null)
            {
                return null;
            }

            parameter.Name = updatedParameter.Name;
            parameter.Unit = updatedParameter.Unit;

            await _dbContext.SaveChangesAsync();
            return parameter;
        }

        public async Task<bool> DeleteParameter(int id)
        {
            var parameter = await _dbContext.Parameters.FindAsync(id);
            if (parameter == null)
            {
                return false;
            }

            _dbContext.Parameters.Remove(parameter);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ParameterEntity>> GetBottomParameters(int count)
        {
            return await _dbContext.Parameters
                .OrderBy(p => p.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<ParameterEntity>> GetTopParameters(int count)
        {
            return await _dbContext.Parameters
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }

}