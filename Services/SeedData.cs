using System.Text.Json;
using cqrs_budget.classes;
using cqrs_budget.data;

namespace cqrs_budget.Services
{
    public class SeedData
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Account> Accounts = BudgetContext.GetAllAccounts();
        private List<TransactionType> TransactionTypes = BudgetContext.GetAllTransactionTypes();
        private Random Randomizer = new Random();

        public async Task Go()
        {
            try
            {
                var streamTask = client.GetStreamAsync("https://jsonplaceholder.typicode.com/posts");
                var seedData = await JsonSerializer.DeserializeAsync<List<SeedTransaction>>(await streamTask);
                if (seedData == null)
                {
                    return;
                }
                var accountCount = Accounts.Count;
                var transactionTypeCount = TransactionTypes.Count;
                for(var i = 0; i < seedData.Count; i++)
                {
                    var currentSeedData = seedData[i];
                    var accountIndex = Randomizer.Next(0, accountCount - 1);
                    var transactionTypeIndex = Randomizer.Next(0, transactionTypeCount - 1);
                    var amount = Randomizer.NextDouble() * 100;
                    currentSeedData.Description = currentSeedData.title;
                    currentSeedData.AccountId = Accounts[accountIndex].Id;
                    currentSeedData.TransactionTypeId = TransactionTypes[transactionTypeIndex].Id;
                    currentSeedData.Amount = (decimal) amount;
                }
                BudgetContext.InsertSeedData(seedData);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        
    }
}