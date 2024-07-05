CREATE TABLE salaries(
	employee_id VARCHAR(MAX)NULL,
	basic_salary DECIMAL(10,2)NULL,
	NumberOfHolidays INT NULL,
	NumberOfAbsent INT NULL,
	OvertimeHours INT NULL,
	BasePay INT NULL,
	GrossPay INT NULL,
	NoPayValue INT NULL,
	allowance FLOAT(53)NULL,
	RemainingLeaves VARCHAR(MAX)  NULL,
	monthly_salary DECIMAL(18) NULL
);

SELECT * FROM salaries