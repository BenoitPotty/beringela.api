using Microsoft.EntityFrameworkCore;

namespace b_healthy.Data;

public class BHealthyDbContext: DbContext
{
    public BHealthyDbContext(DbContextOptions<BHealthyDbContext> options) : base(options) { }
}