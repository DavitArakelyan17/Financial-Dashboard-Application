using System;
using System.Collections.Generic;

// Define a class to represent financial transactions
public class Transaction
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

// Define a class for the financial dashboard
public class FinancialDashboard
{
    private List<Transaction> transactions;

    public FinancialDashboard()
    {
        transactions = new List<Transaction>();
    }

    // Method to add a new transaction to the dashboard
    public void AddTransaction(string description, decimal amount, DateTime date)
    {
        Transaction transaction = new Transaction
        {
            Description = description,
            Amount = amount,
            Date = date
        };
        transactions.Add(transaction);
    }

    // Method to display the financial data on the dashboard
    public void DisplayDashboard()
    {
        Console.WriteLine("Financial Dashboard");
        Console.WriteLine("-------------------");

        // Display recent transactions
        Console.WriteLine("Recent Transactions:");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Date.ToShortDateString()} - {transaction.Description}: {transaction.Amount}");
        }

        // Calculate total income, expenses, and savings
        decimal totalIncome = 0;
        decimal totalExpenses = 0;
        foreach (var transaction in transactions)
        {
            if (transaction.Amount > 0)
                totalIncome += transaction.Amount;
            else
                totalExpenses += Math.Abs(transaction.Amount);
        }
        decimal totalSavings = totalIncome - totalExpenses;

        // Display total income, expenses, and savings
        Console.WriteLine($"Total Income: {totalIncome}");
        Console.WriteLine($"Total Expenses: {totalExpenses}");
        Console.WriteLine($"Total Savings: {totalSavings}");

        // Visual representation (e.g., charts, graphs) can be added here for a more appealing display
    }

    // Method to save transactions to a file or database
    public void SaveTransactions(string filename)
    {
        // Implement code to save transactions to a file or database
        // Example: write transactions to a CSV file
        // Code omitted for brevity
    }

    // Method to load transactions from a file or database
    public void LoadTransactions(string filename)
    {
        // Implement code to load transactions from a file or database
        // Example: read transactions from a CSV file
        // Code omitted for brevity
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Your main program logic here
    }
}


