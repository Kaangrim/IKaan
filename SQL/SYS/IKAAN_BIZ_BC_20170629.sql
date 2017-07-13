/* **************************************************************************************
 * Database		: IKAAN_BIZ_BC
 * Description	: 비즈니스 공통
 * CREATEd		: 2016.06.23
 * Author		: Woo Jong Ho 
** *********************************************************************************** */
USE IKAAN_BIZ
GO

--공통코드
IF OBJECT_ID('dbo.BCCode') IS NOT NULL
	DROP TABLE dbo.BCCode
GO

CREATE TABLE dbo.BCCode
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
 
	CONSTRAINT PK_BCCode PRIMARY KEY CLUSTERED (ID)
)
GO
CREATE UNIQUE INDEX IX_BCCode ON dbo.BCCode (Code, ParentCode)
GO
CREATE INDEX IX_BCCode_01 ON dbo.BCCode (ParentCode)
GO
CREATE INDEX IX_BCCode_02 ON dbo.BCCode (ParentCode, UseYn)
GO