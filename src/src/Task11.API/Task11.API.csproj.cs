<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
    <!-- JWT Auth -->
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.0" />

    <!-- Swagger -->
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />

    <!-- EF Core -->
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.16" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.16">
    <PrivateAssets>all</PrivateAssets>
    </PackageReference>


    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.13" />
    </ItemGroup>

    <ItemGroup>
    <ProjectReference Include="..\Task11.Models\Task11.Models.csproj" />
    <ProjectReference Include="..\Task11.Services\Task11.Services.csproj" />
    </ItemGroup>

    </Project>