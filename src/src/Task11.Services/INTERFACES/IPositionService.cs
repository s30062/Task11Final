using src.Task11.Services.dtos;

namespace src.DeviceEmployeeAuthManager.Services;

public interface IPositionService
{
    public Task<List<GetPositionsDto>> GetAllPositions(CancellationToken cancellationToken);
}