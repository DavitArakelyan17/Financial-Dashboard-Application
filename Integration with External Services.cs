public class FinancialDashboard
{
    // Add method to fetch stock prices from an external API
    public decimal GetStockPrice(string symbol)
    {
        // Implement code to fetch stock price from an external API
        // Example: use HttpClient to make a request to a financial data API
        // Code omitted for brevity
    }
}

public class MainForm : Form
{
    // Add a Label to display stock price
    private Label stockPriceLabel;

    public MainForm()
    {
        // Initialize the financial dashboard

        // Set up form components...

        // Initialize and configure the Label control for stock price
        stockPriceLabel = new Label();
        stockPriceLabel.Text = "Stock Price:";
        stockPriceLabel.Location = new System.Drawing.Point(20, 140);

        // Add the Label control to the form
        Controls.Add(stockPriceLabel);
    }

    private void UpdateStockPrice()
    {
        // Fetch stock price from external API
        decimal stockPrice = dashboard.GetStockPrice("AAPL");

        // Update the Label with the latest stock price
        stockPriceLabel.Text = $"Stock Price: {stockPrice}";
    }
}




