SELECT * FROM TargetData

SELECT * FROM SourceData


BEGIN TRAN

MERGE INTO TargetData AS tgt
USING SourceData AS src
	ON tgt.Id = src.Id
WHEN NOT MATCHED BY TARGET AND src.SomeDate = '2017-02-17 23:16:24' AND 1 = 1
 THEN INSERT(Data, SomeDate)
	VALUES(src.Data, src.SomeDate)

;



SELECT * FROM TargetData


ROLLBACK TRAN;