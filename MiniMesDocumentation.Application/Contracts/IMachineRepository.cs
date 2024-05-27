using MiniMesDocumentation.Domain.Entities;

namespace MiniMesDocumentation.Application.Contracts
{
    public interface IMachineRepository
    {
        Task<List<MachineEntity>> GetAllMachines();
        Task<MachineEntity> CreateMachine(MachineEntity machine);
        Task<MachineEntity> UpdateMachine(int id, MachineEntity updatedMachine);
        Task<bool> DeleteMachine(int id);
        Task<List<MachineEntity>> GetBottomMachines(int count);
        Task<List<MachineEntity>> GetTopMachines(int count);
    }


}
