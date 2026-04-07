# Need to be updated

# Helpful commands

<p> EF Core Commands</p>
    

    1. Add migrations - 
        dotnet ef migrations add <NameOfMigration> \
        --project Your.DataAccess.Project \
        --startup-project Your.Startup.Project
    
    2. Update database - 
        dotnet ef database update <NameOfMigration> \
        --project MyApp.Infrastructure \
        --startup-project MyApp.API
