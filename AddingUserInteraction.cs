using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private FinancialDashboard dashboard;
    private TextBox descriptionTextBox;
    private TextBox amountTextBox;
    private TextBox dateTextBox;

    public MainForm()
    {
        // Initialize the financial dashboard
        dashboard = new FinancialDashboard();

        // Set up form components
        Label descriptionLabel = new Label();
        descriptionLabel.Text = "Description:";
        descriptionLabel.Location = new System.Drawing.Point(20, 20);

        descriptionTextBox = new TextBox();
        descriptionTextBox.Location = new System.Drawing.Point(120, 20);
        descriptionTextBox.Width = 200;

        Label amountLabel = new Label();
        amountLabel.Text = "Amount:";
        amountLabel.Location = new System.Drawing.Point(20, 60);

        amountTextBox = new TextBox();
        amountTextBox.Location = new System.Drawing.Point(120, 60);
        amountTextBox.Width = 200;

        Label dateLabel = new Label();
        dateLabel.Text = "Date (YYYY-MM-DD):";
        dateLabel.Location = new System.Drawing.Point(20, 100);

        dateTextBox = new TextBox();
        dateTextBox.Location = new System.Drawing.Point(120, 100);
        dateTextBox.Width = 200;

        Button addButton = new Button();
        addButton.Text = "Add Transaction";
        addButton.Location = new System.Drawing.Point(20, 140);
        addButton.Click += AddButton_Click;

        Button saveButton = new Button();
        saveButton.Text = "Save Transactions";
        saveButton.Location = new System.Drawing.Point(140, 140);
        saveButton.Click += SaveButton_Click;

        Button loadButton = new Button();
        loadButton.Text = "Load Transactions";
        loadButton.Location = new System.Drawing.Point(260, 140);
        loadButton.Click += LoadButton_Click;

        // Add components to the form
        Controls.Add(descriptionLabel);
        Controls.Add(descriptionTextBox);
        Controls.Add(amountLabel);
        Controls.Add(amountTextBox);
        Controls.Add(dateLabel);
        Controls.Add(dateTextBox);
        Controls.Add(addButton);
        Controls.Add(saveButton);
        Controls.Add(loadButton);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        // Parse user input and add transaction to dashboard
        string description = descriptionTextBox.Text;
        decimal amount = decimal.Parse(amountTextBox.Text);
        DateTime date = DateTime.Parse(dateTextBox.Text);
        dashboard.AddTransaction(description, amount, date);

        // Display the updated financial dashboard
        MessageBox.Show("Transaction added successfully!");
        dashboard.DisplayDashboard();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        // Save transactions to a file
        dashboard.SaveTransactions("transactions.txt");
        MessageBox.Show("Transactions saved successfully!");
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        // Load transactions from a file
        dashboard.LoadTransactions("transactions.txt");
        MessageBox.Show("Transactions loaded successfully!");
        dashboard.DisplayDashboard();
    }
}




