# add migration
dotnet ef migrations Add "<name>" -o .\Entities\Migrations

# update database
dotnet ef database update