SELECT * FROM TargetData

SELECT * FROM SourceData


BEGIN TRAN

MERGE INTO TargetData AS tgt
USING SourceData AS src
	ON tgt.Id = src.Id
WHEN MATCHED AND src.SomeDate = '20170202'
 THEN UPDATE
	SET tgt.Data = src.Data
WHEN MATCHED AND tgt.Id> 5 THEN DELETE;


SELECT * FROM TargetData


ROLLBACK TRAN;