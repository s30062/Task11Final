namespace Task11.Services.services;

public interface IRoleSeeder
{
    Task SeedRolesAsync(CancellationToken ct);
}