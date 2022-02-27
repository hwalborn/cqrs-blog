// using Microsoft.EntityFrameworkCore;

// namespace cqrs_budget.classes
// {
//     public class TestDB : DbContext
//     {
//         public DbSet<Person> People { get; set; }
//         public DbSet<account> Accounts { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(@"Host=localhost;Database=cqrs_blog");
        
//     }

//     public class Person
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//     }

//     public class account
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//     }
// }