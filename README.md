# InventoryItems

## Update local database
dotnet ef migrations add <name> --startup-project InventoryItems\InventoryItems.csproj --project InventoryItems.Data\InventoryItems.Data.csproj

dotnet ef database update <name> --startup-project InventoryItems\InventoryItems.csproj --project InventoryItems.Data\InventoryItems.Data.csproj