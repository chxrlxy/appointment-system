using AppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Data;

// AppDbContext is the session with the database.
// It does 3 jobs:
//
// 1. Describes the model: each DbSet<T> tells EF Core 'there is a table for this class'.
// 2. Runs queries: _db.Customers.Where(...) is translated into SQL.
// 3. Tracks changes and saves them: when you load a Customer, change a property and call SaveChangesAsync(),
//    EF Core notices what changed and generates the matching UPDATE. Nothing is written until you call 
//    SaveChangesAsync() and all pendnig changes are saved together in one transaction.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
}