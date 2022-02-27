using cqrs_budget.classes;
using cqrs_budget.Services;


namespace cqrs_budget
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // BudgetContext.PrintData();

            var seedData = new SeedData();
            await seedData.Go();
            Console.WriteLine("Hello World!");
        }
    }
}