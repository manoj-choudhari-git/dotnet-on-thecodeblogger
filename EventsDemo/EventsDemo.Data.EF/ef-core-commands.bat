dotnet ef database update 0 --context UniversityContext 

dotnet ef migrations remove --context UniversityContext 

dotnet ef migrations add InitialCreate --context UniversityContext 

dotnet ef database update --context UniversityContext 