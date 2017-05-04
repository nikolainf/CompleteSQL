IF OBJECT_ID('tempdb..#TestTable', 'U') IS NOT NULL
DROP TABLE #TestTable

CREATE TABLE #TestTable
(
	Number INT NOT NULL
	, Name VARCHAR(255) NOT NULL
	, Age INT NULL
	, GroupNumber INT NULL
	, GroupName VARCHAR(255) NULL
	, Salary MONEY NULL
)

Merge Into Person as tgt
Using #TestTable as src
	On tgt.Number = src.Number
When Matched
	Then Delete
When Not Matched By Source
	Then Update Set
		tgt.Age = tgt.Age + 1,
		tgt.Salary = tgt.Salary + 25;