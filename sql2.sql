-- Users table to store user information
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Role ENUM('Admin', 'Regular') NOT NULL
);

-- Transactions table to store financial transactions
CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    Description VARCHAR(255) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    TransactionDate DATETIME,
    TransactionType ENUM('Income', 'Expense') NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- SavingsGoals table to store users' saving goals
CREATE TABLE SavingsGoals (
    GoalID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    GoalDescription VARCHAR(255) NOT NULL,
    TargetAmount DECIMAL(10, 2) NOT NULL,
    CurrentAmount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);