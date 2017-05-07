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

When Matched And tgt.Age > 100
	Then Delete
When Matched And tgt.Age > 18
	Then Update Set
		tgt.Age = src.Age

;