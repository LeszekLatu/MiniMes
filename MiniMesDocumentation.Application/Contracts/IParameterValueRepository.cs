using MiniMesDocumentation.Domain.Entities;
namespace MiniMesDocumentation.Application.Contracts
{
    public interface IParameterValueRepository
    {
        Task<List<ParameterValueEntity>> GetAllParameterValues();
        Task<ParameterValueEntity> CreateParameterValue(ParameterValueEntity parameterValue);
        Task<ParameterValueEntity> UpdateParameterValue(int id, ParameterValueEntity updatedParameterValue);
        Task<bool> DeleteParameterValue(int id);
        Task<List<ParameterValueEntity>> GetBottomParameterValues(int count);
        Task<List<ParameterValueEntity>> GetTopParameterValues(int count);
    }

}
