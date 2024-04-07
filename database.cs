using Microsoft.Data.Sqlite;

public class FinancialDatabase
{
    private const string connectionString = "Data Source=financial.db";

    public FinancialDatabase()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Transactions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Description TEXT NOT NULL,
                    Amount DECIMAL(18,2) NOT NULL,
                    Date TEXT NOT NULL,
                    Type TEXT NOT NULL
                );
            ";
            command.ExecuteNonQuery();
        }
    }

    public void AddTransaction(Transaction transaction)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Transactions (Description, Amount, Date, Type) 
                VALUES ($description, $amount, $date, $type);
            ";
            command.Parameters.AddWithValue("$description", transaction.Description);
            command.Parameters.AddWithValue("$amount", transaction.Amount);
            command.Parameters.AddWithValue("$date", transaction.Date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$type", transaction.Amount > 0 ? "Income" : "Expense");

            command.ExecuteNonQuery();
        }
    }

    public List<Transaction> GetAllTransactions()
    {
        var transactions = new List<Transaction>();

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Transactions";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var transaction = new Transaction
                    {
                        Description = reader.GetString(1),
                        Amount = reader.GetDecimal(2),
                        Date = DateTime.Parse(reader.GetString(3))
                    };
                    transactions.Add(transaction);
                }
            }
        }

        return transactions;
    }
}
public class FinancialDashboard
{
    private FinancialDatabase database;

    public FinancialDashboard()
    {
        database = new FinancialDatabase();
    }

    public void AddTransaction(string description, decimal amount, DateTime date)
    {
        Transaction transaction = new Transaction
        {
            Description = description,
            Amount = amount,
            Date = date
        };
        database.AddTransaction(transaction);
    }

    public List<Transaction> GetAllTransactions()
    {
        return database.GetAllTransactions();
    }

    // Other methods...
}
class Program
{
    static void Main(string[] args)
    {
        var dashboard = new FinancialDashboard();

        // Add a transaction
        dashboard.AddTransaction("Salary", 3000, new DateTime(2024, 4, 1));

        // Get all transactions
        var transactions = dashboard.GetAllTransactions();
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.Description}: {transaction.Amount}");
        }
    }
}


