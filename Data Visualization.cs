// Add reference to System.Windows.Forms.DataVisualization
using System.Windows.Forms.DataVisualization.Charting;

public class MainForm : Form
{
    // Add a Chart control
    private Chart chart;

    public MainForm()
    {
        // Initialize the financial dashboard
        dashboard = new FinancialDashboard();

        // Set up form components...

        // Initialize and configure the Chart control
        chart = new Chart();
        chart.Size = new System.Drawing.Size(400, 300);
        chart.Location = new System.Drawing.Point(20, 180);
        chart.ChartAreas.Add(new ChartArea());
        chart.Series.Add(new Series());
        chart.Series[0].ChartType = SeriesChartType.Pie;

        // Add the Chart control to the form
        Controls.Add(chart);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        // Parse user input and add transaction to dashboard...

        // Update the chart
        UpdateChart();
    }

    private void UpdateChart()
    {
        // Clear previous data
        chart.Series[0].Points.Clear();

        // Add new data based on current transactions
        decimal totalIncome = 0;
        decimal totalExpenses = 0;
        foreach (var transaction in dashboard.Transactions)
        {
            if (transaction.Amount > 0)
                totalIncome += transaction.Amount;
            else
                totalExpenses += Math.Abs(transaction.Amount);
        }

        // Add data points to the chart
        chart.Series[0].Points.AddXY("Income", totalIncome);
        chart.Series[0].Points.AddXY("Expenses", totalExpenses);
    }
}




