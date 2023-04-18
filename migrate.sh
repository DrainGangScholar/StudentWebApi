migration_name="$1"
dotnet ef migrations add $migration_name -p Infrastructure -s API -o Data/Migrations
dotnet ef database update -p Infrastructure -s API
