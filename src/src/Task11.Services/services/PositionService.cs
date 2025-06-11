using Microsoft.EntityFrameworkCore;
using src.Task11.Services.dtos;

namespace src.Task11.Services;

public class PositionService : IPositionService
{
    private readonly DeviceEmployeeDbContext _db;

    public PositionService(DeviceEmployeeDbContext db)
    {
        _db = db;
    }

    public async Task<List<GetPositionsDto>> GetAllPositions(CancellationToken ct)
    {
        var positionEntities = await _db.Positions.ToListAsync(ct);

        var dtoList = positionEntities
            .Select(pos => new GetPositionsDto
            {
                Id = pos.Id,
                Name = pos.Name
            })
            .ToList();

        return dtoList;
    }
}