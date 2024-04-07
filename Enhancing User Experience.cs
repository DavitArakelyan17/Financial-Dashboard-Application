public class FinancialDashboard
{
    // Add method to filter transactions by type (income/expense)
    public List<Transaction> FilterTransactionsByType(bool isIncome)
    {
        return transactions.Where(t => (isIncome && t.Amount > 0) || (!isIncome && t.Amount < 0)).ToList();
    }

    // Add method to set financial goals
    public void SetFinancialGoal(string goal, decimal targetAmount)
    {
        // Implement code to set financial goals
    }

    // Add method to provide personalized recommendations
    public string GetRecommendations()
    {
        // Implement code to generate personalized recommendations
        return "Consider investing in low-cost index funds for long-term growth.";
    }
}

public class MainForm : Form
{
    // Add ComboBox and Label controls for filtering transactions
    private ComboBox filterComboBox;
    private Label recommendationsLabel;

    public MainForm()
    {
        // Initialize the financial dashboard

        // Set up form components...

        // Initialize and configure the ComboBox control for filtering transactions
        filterComboBox = new ComboBox();
        filterComboBox.Items.AddRange(new object[] { "All", "Income", "Expenses" });
        filterComboBox.SelectedIndex = 0;
        filterComboBox.Location = new System.Drawing.Point(20, 160);
        filterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged;

        // Initialize and configure the Label control for recommendations
        recommendationsLabel = new Label();
        recommendationsLabel.Location = new System.Drawing.Point(20, 200);
        recommendationsLabel.AutoSize = true;

        // Add the ComboBox and Label controls to the form
        Controls.Add(filterComboBox);
        Controls.Add(recommendationsLabel);
    }

    private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Filter transactions based on selected option
        string selectedOption = filterComboBox.SelectedItem.ToString();
        List<Transaction> filteredTransactions;
        if (selectedOption == "Income")
            filteredTransactions = dashboard.FilterTransactionsByType(true);
        else if (selectedOption == "Expenses")
            filteredTransactions = dashboard.FilterTransactionsByType(false);
        else
            filteredTransactions = dashboard.Transactions;

        // Display filtered transactions
        DisplayFilteredTransactions(filteredTransactions);
    }

    private void DisplayFilteredTransactions(List<Transaction> transactions)
    {
        // Implement code to display filtered transactions in the GUI
    }

    private void DisplayRecommendations()
    {
        // Get personalized recommendations from the financial dashboard
        string recommendations = dashboard.GetRecommendations();

        // Update the Label with the recommendations
        recommendationsLabel.Text = "Recommendations:\n" + recommendations;
    }
}




