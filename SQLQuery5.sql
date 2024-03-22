CREATE TABLE Settings (
    SettingID INT PRIMARY KEY,
    SalaryBeginDate DATETIME,
    SalaryEndDate DATETIME,
    SalaryCycleDays INT,
    NumberOfLeaves INT,
    GovernmentTax DECIMAL(10,2)
);
 SELECt * FROM Settings
