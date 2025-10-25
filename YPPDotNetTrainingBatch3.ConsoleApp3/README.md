-Model First
-Code First
-Database First

dotnet ef dbcontext scaffold "Server=.;Database=Batch3MiniPOs;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContentModels -c AppDbContext -f 