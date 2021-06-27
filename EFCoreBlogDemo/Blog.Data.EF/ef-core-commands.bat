dotnet ef database update 0 --context BlogContext 

dotnet ef migrations remove --context BlogContext 

dotnet ef migrations add InitialCreate --context BlogContext

dotnet ef database update --context BlogContext