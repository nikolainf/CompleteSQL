SELECT * FROM TargetData

SELECT * FROM SourceData


BEGIN TRAN

MERGE INTO TargetData AS tgt
USING SourceData AS src
	ON tgt.Id = src.Id
WHEN MATCHED AND src.SomeDate = '20170202'
 THEN UPDATE
	SET tgt.Data = src.Data
WHEN MATCHED 
 THEN UPDATE
	SET tgt.SomeDate = src.SomeDate;


SELECT * FROM TargetData


ROLLBACK TRAN;