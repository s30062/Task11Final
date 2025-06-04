

{
    "ConnectionStrings": {
        "EmployeeDatabase": "Server=localhost;Database=s30062;Trusted_Connection=True;TrustServerCertificate=True;"
    },
    "JwtSettings": {
        "SecretKey": "this-is-a-very-secure-key-at-least-32-characters",
        "Issuer": "EmployeeManager",
        "Audience": "EmployeeUsers",
        "ExpiryMinutes": 60
    }
}
