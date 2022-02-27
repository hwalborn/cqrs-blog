using System.Data;
using cqrs_budget.classes;
using Dapper;
using Npgsql;

namespace cqrs_budget.data
{
    public class BudgetContext
    {
        private static string _connectionString => "Host=localhost;Database=cqrs_blog";
        public static IDbConnection OpenConnection(string connStr)  
        {  
            var conn = new NpgsqlConnection(connStr);  
            conn.Open();  
            return conn; 
        }

        public static void InsertSeedData(List<SeedTransaction> transactions)
        {
            using (var conn = OpenConnection(_connectionString))  
            {  
                string processQuery = @"INSERT INTO transaction (description, amount, account_id, transaction_type_id)
                                        VALUES (@Description, @Amount, @AccountId, @TransactionTypeId)";        
                conn.Execute(processQuery, transactions);
            }
        }

        public static List<Account> GetAllAccounts()
        {
            List<Account> list;  
            using (var conn = OpenConnection(_connectionString))  
            {  
                var querySQL = @"SELECT id, name FROM account;";  
                list = conn.Query<Account>(querySQL).ToList();  
            }
            return list;
        }

        public static List<TransactionType> GetAllTransactionTypes()
        {
            List<TransactionType> list;  
            using (var conn = OpenConnection(_connectionString))  
            {  
                var querySQL = @"SELECT id, name FROM transaction_type;";  
                list = conn.Query<TransactionType>(querySQL).ToList();  
            }
            return list;

        }

        public static void PrintData()  
        {
            IList<Account> list;  
            using (var conn = OpenConnection(_connectionString))  
            {  
                var querySQL = @"SELECT id, name FROM account;";  
                list = conn.Query<Account>(querySQL).ToList();  
            }  
            if (list.Count > 0)  
            {  
                foreach (var item in list)  
                {
                    Console.WriteLine($"Name is {item.Name}");  
                }  
            }  
            else  
            {  
                Console.WriteLine("the table is empty!");  
            }
        }  
    }
}