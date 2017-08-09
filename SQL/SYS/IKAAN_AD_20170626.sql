/* **************************************************************************************
 * Database		: IKAAN_AD
 * Description	: 데이터베이스
 * CREATEd		: 2016.06.23
 * Author		: Woo Jong Ho 
** *********************************************************************************** */
USE IKAAN
GO

--시스템
CREATE TABLE dbo.ADSystem
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	SystemName		nvarchar(50)		NOT NULL
,	UseYn 			char(1)				NOT NULL
,	Description 	nvarchar(500)			NULL

,	CONSTRAINT PK_ADSystem PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_ADSystem_01 ON dbo.ADSystem (UseYn)
GO

--서버정보
CREATE TABLE dbo.ADServer
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ServerName		varchar(50)			NOT NULL
,	Description 	nvarchar(500)			NULL

,	CONSTRAINT PK_ACServer PRIMARY KEY (ID)
)
GO

--데이터베이스
CREATE TABLE dbo.ADDatabase
(
	ID					int 				NOT NULL IDENTITY(100, 1)
,	CreateDate 			datetime 			NOT NULL
,	CreateBy 			int 				NOT NULL
,	CreateByName		nvarchar(50)		NOT NULL
,	UpdateDate			datetime 				NULL
,	UpdateBy 			int 					NULL
,	UpdateByName		nvarchar(50)			NULL

,	DatabaseName		varchar(50)			NOT NULL
,	DbmsType			varchar(20)			NOT NULL
,	ServerId			int 				NOT NULL
,	ConnectionString	varchar(100)			NULL
,	Description 		nvarchar(500)			NULL

,	CONSTRAINT PK_ADDatabase PRIMARY KEY (ID)
)
GO

--스키마
CREATE TABLE dbo.ADSchema
(
	ID					int 				NOT NULL IDENTITY(100, 1)
,	CreateDate 			datetime 			NOT NULL
,	CreateBy 			int 				NOT NULL
,	CreateByName		nvarchar(50)		NOT NULL
,	UpdateDate			datetime 				NULL
,	UpdateBy 			int 					NULL
,	UpdateByName		nvarchar(50)			NULL

,	SchemaName			varchar(50)			NOT NULL
,	DatabaseId			int 				NOT NULL
,	Description 		nvarchar(500)			NULL

,	CONSTRAINT PK_ADSchema PRIMARY KEY (ID)
)
GO

--테이블
CREATE TABLE dbo.ADTable
(
	ID					int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 			datetime 			NOT NULL
,	CreateBy 			int 				NOT NULL
,	CreateByName		nvarchar(50)		NOT NULL
,	UpdateDate			datetime 				NULL
,	UpdateBy 			int 					NULL
,	UpdateByName		nvarchar(50)			NULL

,	DatabaseId			int 				NOT NULL
,	SchemaId			int 				NOT NULL
,	TableName			varchar(50)			NOT NULL
,	Description 		nvarchar(500)			NULL
,	UseYn				char(1)				NOT NULL

,	CONSTRAINT PK_ADTable PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_ADTable_01 ON dbo.ADTable (UseYn)
GO
CREATE INDEX IX_ADTable_02 ON dbo.ADTable (DatabaseId)
GO
CREATE INDEX IX_ADTable_03 ON dbo.ADTable (SchemaId)
GO

--컬럼
CREATE TABLE dbo.ADColumn
(
	ID					int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 			datetime 			NOT NULL
,	CreateBy 			int 				NOT NULL
,	CreateByName		nvarchar(50)		NOT NULL
,	UpdateDate			datetime 				NULL
,	UpdateBy 			int 					NULL
,	UpdateByName		nvarchar(50)			NULL

,	TableId				int 				NOT NULL
,	PhysicalName		varchar(50)			NOT NULL
,	LogicalName			nvarchar(100)		NOT NULL
,	Description 		nvarchar(500)			NULL
,	DataType			varchar(50)				NULL
,	NullYn				char(1)				NOT NULL
,	PkYn				char(1)				NOT NULL
,	FkYN				char(1)				NOT NULL
,	IdentityYn			char(1)				NOT NULL
,	DefaultValue		nvarchar(100)			NULL
,	SortOrder			int 				NOT NULL

,	CONSTRAINT PK_ADColumn PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_ADColumn_01 ON dbo.ADColumn (TableId)
GO




