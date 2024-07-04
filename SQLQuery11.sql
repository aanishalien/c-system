ALTER TABLE salary
ADD employee_id INT,
    basic_salary DECIMAL(10, 2),
    over_time_rate DECIMAL(5, 2), -- Example: DECIMAL with precision 5 and scale 2 for overtime rate
    allowance FLOAT, -- Example: FLOAT for allowance
	RemainingLeaves VARCHAR(MAX);

SELECT * FROM salary