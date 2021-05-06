dotnet ef:
dotnet ef database update -p infrastructure -s coffeehouseapi
dotnet ef database drop -p infrastructure -s coffeehouseapi
dotnet ef migrations add first -p infrastructure -s coffeehouseapi  
