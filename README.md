# Mineralab
Inicio del proyecto 3/12/2020
# databse migrations
dotnet ef migrations add CreateIdentitySchema --context Mineralab.Data.ApplicationDbContext -o "`D:\git\Mineralab1.1\Mineralab\Data\Migrations"
dotnet ef migrations add CreateIdentitySchema --context Mineralab.Data.ApplicationDbContext -o "C:\Users\PC_\Desktop\Mineralab\Data\Migrations"
# update databse
dotnet ef database update
