/* **************************************************************************************
 * Database		: IKAAN_AC
 * Description	: 시스템 공통
 * CREATEd		: 2016.06.23
 * Author		: Woo Jong Ho 
** *********************************************************************************** */
USE IKAAN
GO

IF OBJECT_ID('dbo.ACDictionary') IS NOT NULL
	DROP TABLE dbo.ACDictionary
GO

--용어사전
CREATE TABLE dbo.ACDictionary
(
	ID				int 				NOT NULL IDENTITY(100000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	LanguageCode	varchar(10)			NOT NULL
,	PhysicalName	varchar(50)			NOT NULL
,	LogicalName 	nvarchar(100)		NOT NULL
,	Description 	nvarchar(500)			NULL

,	CONSTRAINT PK_ACDictionary PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_ACDictionary ON dbo.ACDictionary (LanguageCode, PhysicalName)
GO
CREATE INDEX IX_ACDictionary_01 ON dbo.ACDictionary (LanguageCode)
GO
CREATE INDEX IX_ACDictionary_02 ON dbo.ACDictionary (PhysicalName)
GO

--메시지
IF OBJECT_ID('dbo.ACMessage') IS NOT NULL
	DROP TABLE dbo.ACMessage
GO

CREATE TABLE dbo.ACMessage
(
	ID				int 				NOT NULL IDENTITY(10000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	LanguageCode	varchar(10)			NOT NULL
,	PhysicalName	varchar(50)			NOT NULL
,	LogicalName 	nvarchar(200)		NOT NULL
,	Description 	nvarchar(500)			NULL

,	CONSTRAINT PK_ACMessage PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_ACMessage ON dbo.ACMessage (LanguageCode, PhysicalName)
GO
CREATE INDEX IX_ACMessage_01 ON dbo.ACMessage (LanguageCode)
GO
CREATE INDEX IX_ACMessage_02 ON dbo.ACMessage (PhysicalName)
GO


--공통코드
IF OBJECT_ID('dbo.ACCode') IS NOT NULL
	DROP TABLE dbo.ACCode
GO

CREATE TABLE dbo.ACCode
(
	ID				int 				NOT NULL IDENTITY(1000000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	Code 			varchar(20)			NOT NULL
,	Name			nvarchar(100) 		NOT NULL
,	Value 			nvarchar(100)			NULL
,	ParentCode		varchar(20) 			NULL
,	Description		nvarchar(1000)			NULL
,	UseYn			char(1)				NOT NULL
,	SortOrder		int 				NOT NULL
,	MaxLength		int 				NOT NULL	
	
,	CodeValue01		nvarchar(50)			NULL
,	CodeValue02		nvarchar(50)			NULL
,	CodeValue03		nvarchar(50)			NULL
,	CodeValue04		nvarchar(50)			NULL
,	CodeValue05		nvarchar(50)			NULL
,	CodeValue06		nvarchar(50)			NULL
,	CodeValue07		nvarchar(50)			NULL
,	CodeValue08		nvarchar(50)			NULL
,	CodeValue09		nvarchar(50)			NULL
,	CodeValue10		nvarchar(50)			NULL
 
	CONSTRAINT PK_ACCode PRIMARY KEY CLUSTERED (ID)
)
GO
CREATE UNIQUE INDEX IX_ACCode ON dbo.ACCode (Code, ParentCode)
GO
CREATE INDEX IX_ACCode_01 ON dbo.ACCode (ParentCode)
GO
CREATE INDEX IX_ACCode_02 ON dbo.ACCode (ParentCode, UseYn)
GO