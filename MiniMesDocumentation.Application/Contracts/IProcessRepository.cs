using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Application.Contracts
{
    public interface IProcessRepository
    {
        Task<List<ProcessEntity>> GetAllProcesses();
        Task<ProcessEntity> CreateProcess(ProcessEntity process);
        Task<ProcessEntity> UpdateProcess(int id, ProcessEntity updatedProcess);
        Task<bool> DeleteProcess(int id);
        Task<List<ProcessEntity>> GetBottomProcesses(int count);
        Task<List<ProcessEntity>> GetTopProcesses(int count);
    }


}
