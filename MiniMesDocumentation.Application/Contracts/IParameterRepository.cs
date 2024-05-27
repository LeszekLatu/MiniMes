using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Application.Contracts
{
    public interface IParameterRepository
    {
        Task<List<ParameterEntity>> GetAllParameters();
        Task<ParameterEntity> CreateParameter(ParameterEntity parameter);
        Task<ParameterEntity> UpdateParameter(int id, ParameterEntity updatedParameter);
        Task<bool> DeleteParameter(int id);
        Task<List<ParameterEntity>> GetBottomParameters(int count);
        Task<List<ParameterEntity>> GetTopParameters(int count);
    }

}
