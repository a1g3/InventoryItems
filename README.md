# CoinCompanion
[![Build Status](https://dev.azure.com/alexgebhard/Coin%20Companion/_apis/build/status/a1g3.CoinCompanion?branchName=master)](https://dev.azure.com/alexgebhard/Coin%20Companion/_build/latest?definitionId=2&branchName=master)

## Update local database
dotnet ef migrations add <name> --startup-project InventoryItems\InventoryItems.csproj --project InventoryItems.Data\InventoryItems.Data.csproj

dotnet ef database update <name> --startup-project InventoryItems\InventoryItems.csproj --project InventoryItems.Data\InventoryItems.Data.csproj
