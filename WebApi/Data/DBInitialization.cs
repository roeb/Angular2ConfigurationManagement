using Microsoft.EntityFrameworkCore;

public class DBInitialization
{
    public static void Initialize()
    {
        var options = new DbContextOptionsBuilder<ConfigurationContext>()
        .UseSqlServer("Server=localhost;Database=ConfigSample;User Id=sa;Password=myVeryStrong(!)Password;");

        using (var context = new ConfigurationContext(options.Options))
        {
            context.Database.Migrate();

            // Other db initialization code.
        }
    }
}