

SET IDENTITY_INSERT [dbo].[TestRecord] On;
INSERT [dbo].[TestRecord] (Id,RecordTime,Barcode)VALUES(11677458,GETDATE(),'Br11677458');
SET IDENTITY_INSERT [dbo].[TestRecord] Off;

SELECT TOP(1) *
FROM [SunsdaTest].[dbo].[TestRecord]
ORDER BY Id DESC;
