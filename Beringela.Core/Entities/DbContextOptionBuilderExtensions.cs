using Microsoft.EntityFrameworkCore;

namespace Beringela.Core.Entities
{
    public static class DbContextOptionBuilderExtensions
    {
        public static DbContextOptionsBuilder UseBeringelaWithMySql(this DbContextOptionsBuilder optionBuilder, string connectionString)
        {
            return optionBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
} 
