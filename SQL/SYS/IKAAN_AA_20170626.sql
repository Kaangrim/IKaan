/* **************************************************************************************
 * Database		: IKAAN
 * Description	: ���Ѱ� ����(Authority and AuthenticatiON)
 * CREATEd		: 2016.06.23
 * Author		: Woo Jong Ho 
** *********************************************************************************** */
use IKAAN
GO

--�������
IF OBJECT_ID('dbo.AAModule') IS NOT NULL 
	DROP TABLE dbo.AAModule
GO

CREATE TABLE dbo.AAModule
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	ModuleName		nvarchar(100)		NOT NULL
,	Assembly		nvarchar(100)			NULL
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAModule PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_AAModule_01 ON dbo.AAModule (UseYn)
GO

--ȭ������
IF OBJECT_ID('dbo.AAView') IS NOT NULL 
	DROP TABLE dbo.AAView
GO

CREATE TABLE dbo.AAView
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	ViewName		nvarchar(100)		NOT NULL
,	ViewType		varchar(4)			NOT NULL
,	ParentId		int						NULL REFERENCES AAView (ID)
,	Namespace		nvarchar(100)			NULL
,	Instance		nvarchar(100)			NULL
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAView PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_AAView_01 	ON dbo.AAView (UseYn)
GO
CREATE INDEX IX_AAView_02 	ON dbo.AAView (ParentId)
GO

--���, ȭ�� ����
IF OBJECT_ID('dbo.AAViewModule') IS NOT NULL 
	DROP TABLE dbo.AAViewModule
GO

CREATE TABLE dbo.AAViewModule
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ViewId			int					NOT NULL REFERENCES dbo.AAView (ID)
,	ModuleId		int					NOT NULL REFERENCES dbo.AAModule (ID)

,	CONSTRAINT PK_AAViewModule PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAViewModule ON dbo.AAViewModule (ViewId, ModuleId)
GO
CREATE INDEX IX_AAViewModule_01 ON dbo.AAViewModule (ViewId)
GO
CREATE INDEX IX_AAViewModule_02 ON dbo.AAViewModule (ModuleId)
GO

--�޴�����
IF OBJECT_ID('dbo.AAMenu') IS NOT NULL 
	DROP TABLE dbo.AAMenu
GO

CREATE TABLE dbo.AAMenu
(
	ID				int 				NOT NULL IDENTITY(100000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	MenuName		nvarchar(100)		NOT NULL
,	ParentId		int						NULL REFERENCES dbo.AAMenu (ID)
,	MenuType		char(1)				NOT NULL --0: �⺻�޴�(Tree), 1:��������(Bar����)
,	SortOrder		int					NOT NULL
,	MenuPath		nvarchar(1000)			NULL
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAMenu PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_AAMenu_01 	ON dbo.AAMenu (ParentId)
GO
CREATE INDEX IX_AAMenu_02	ON dbo.AAMenu (UseYn)
GO

--�޴�, ȭ�� ����
IF OBJECT_ID('dbo.AAMenuView') IS NOT NULL 
	DROP TABLE dbo.AAMenuView
GO

CREATE TABLE dbo.AAMenuView
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	MenuId			int					NOT NULL REFERENCES dbo.AAMenu (ID)
,	ViewId			int					NOT NULL REFERENCES dbo.AAView (ID)

,	Parameter		nvarchar(100)			NULL

,	CONSTRAINT PK_AAMenuView PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAMenuView ON dbo.AAMenuView (MenuId, ViewId)
GO
CREATE INDEX IX_AAMenuView_01 ON dbo.AAMenuView (MenuId)
GO
CREATE INDEX IX_AAMenuView_02 ON dbo.AAMenuView (ViewId)
GO

--��������
IF OBJECT_ID('dbo.AARole') IS NOT NULL 
	DROP TABLE dbo.AARole
GO

CREATE TABLE dbo.AARole
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	RoleName		nvarchar(100)		NOT NULL
,	ParentId		int						NULL REFERENCES dbo.AARole (ID)
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AARole PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_AARole_01 	ON dbo.AARole (ParentId)
GO
CREATE INDEX IX_AARole_02	ON dbo.AARole (UseYn)
GO

--���������
IF OBJECT_ID('dbo.AAUser') IS NOT NULL 
	DROP TABLE dbo.AAUser
GO

CREATE TABLE dbo.AAUser
(
	ID				int 				NOT NULL IDENTITY(100000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	UserName		nvarchar(50)		NOT NULL
,	LoginId			nvarchar(50)			NULL
,	Password		varbinary				NULL
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAUser PRIMARY KEY (ID)		
)
GO
CREATE INDEX IX_AAUser_01 	ON dbo.AAUser (UseYn)
GO
CREATE INDEX IX_AAUser_02 	ON dbo.AAUser (LoginId)
GO

--����� ��й�ȣ �����̷�
IF OBJECT_ID('dbo.AAUserPasswordHist') IS NOT NULL 
	DROP TABLE dbo.AAUserPasswordHist
GO

CREATE TABLE dbo.AAUserPasswordHist
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	OldPassword		varbinary				NULL
,	NewPassword		varbinary				NULL

,	CONSTRAINT PK_AAUserPasswordHist PRIMARY KEY (ID)	
)
GO
CREATE INDEX IX_AAUserPasswordHist_01 ON dbo.AAUserPasswordHist (UserId)
GO

--����ڱ��� ����
IF OBJECT_ID('dbo.AAUserRole') IS NOT NULL 
	DROP TABLE dbo.AAUserRole
GO

CREATE TABLE dbo.AAUserRole
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	RoleId			int					NOT NULL REFERENCES dbo.AARole (ID)

,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAUserRole PRIMARY KEY (ID)	
)
GO
CREATE UNIQUE INDEX IX_AAUserRole 	ON dbo.AAUserRole (UserId, RoleId)
GO
CREATE INDEX IX_AAUserRole_01 	ON dbo.AAUserRole (UserId)
GO
CREATE INDEX IX_AAUserRole_02 	ON dbo.AAUserRole (RoleId)
GO
CREATE INDEX IX_AAUserRole_03 	ON dbo.AAUserRole (UseYn)
GO

--�α��ηα�
if object_id(N'dbo.AALoginLog') is NOT NULL 
	drop TABLE dbo.AALoginLog
GO
CREATE TABLE dbo.AALoginLog
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	LoginId			nvarchar(50)			NULL
,	Version			nvarchar(100)			NULL
,	MainSkin		nvarchar(50)			NULL
,	GridSkin		nvarchar(50)			NULL
,	IpAddress		nvarchar(50)			NULL
,	MacAddress		nvarchar(50)			NULL
,	Status			char(1)					NULL

,	CONSTRAINT PK_AALoginLog PRIMARY KEY (ID)
)
GO
CREATE INDEX IX_AALoginLog_01 ON dbo.AALoginLog (UserId)
GO
CREATE INDEX IX_AALoginLog_02 ON dbo.AALoginLog (LoginId)
GO

--����ڱ׷�
IF OBJECT_ID('dbo.AAGroup') IS NOT NULL 
	DROP TABLE dbo.AAGroup
GO

CREATE TABLE dbo.AAGroup
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	GroupName		nvarchar(100)		NOT NULL
,	ParentId		int						NULL REFERENCES dbo.AAGroup (ID)
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAGroup PRIMARY KEY (ID)	
)
GO
CREATE INDEX IX_AAGroup_01 	ON dbo.AAGroup (ParentId)
GO
CREATE INDEX IX_AAGroup_02	ON dbo.AAGroup (UseYn)
GO

--����ڱ׷캰 ����� ���
IF OBJECT_ID('dbo.AAUserGroup') IS NOT NULL 
	DROP TABLE dbo.AAUserGroup
GO

CREATE TABLE dbo.AAUserGroup
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	GroupId			int					NOT NULL REFERENCES dbo.AAGroup (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAUserGroup PRIMARY KEY (ID)	
)
GO
CREATE UNIQUE INDEX IX_AAUserGroup 	ON dbo.AAUserGroup (UserId, GroupId)
GO
CREATE INDEX IX_AAUserGroup_01 	ON dbo.AAUserGroup (UserId)
GO
CREATE INDEX IX_AAUserGroup_02 	ON dbo.AAUserGroup (GroupId)
GO
CREATE INDEX IX_AAUserGroup_03 	ON dbo.AAUserGroup (UseYn)
GO

--����ڱ׷캰 ���� ����
IF OBJECT_ID('dbo.AAGroupRole') IS NOT NULL 
	DROP TABLE dbo.AAGroupRole
GO

CREATE TABLE dbo.AAGroupRole
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	GroupId			int					NOT NULL REFERENCES dbo.AAGroup (ID)
,	RoleId			int					NOT NULL REFERENCES dbo.AARole (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAGroupRole PRIMARY KEY (ID)	
)
GO
CREATE UNIQUE INDEX IX_AAGroupRole 	ON dbo.AAGroupRole (GroupId, RoleId)
GO
CREATE INDEX IX_AAGroupRole_01 	ON dbo.AAGroupRole (GroupId)
GO
CREATE INDEX IX_AAGroupRole_02 	ON dbo.AAGroupRole (RoleId)
GO
CREATE INDEX IX_AAGroupRole_03 	ON dbo.AAGroupRole (UseYn)
GO

--�׷캰 �޴� ����
if object_id('dbo.AAGroupMenu') is NOT NULL 
	Drop TABLE dbo.AAGroupMenu
GO
CREATE TABLE dbo.AAGroupMenu
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	GroupId			int					NOT NULL REFERENCES dbo.AAGroup (ID)
,	MenuId			int					NOT NULL REFERENCES dbo.AAMenu (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAGroupMenu PRIMARY KEY (ID)	
)
GO
CREATE UNIQUE INDEX IX_AAGroupMenu 	ON dbo.GroupMenu (GroupId, MenuId)
GO
CREATE INDEX IX_AAGroupMenu_01 	ON dbo.AAGroupMenu (GroupId)
GO
CREATE INDEX IX_AAGroupMenu_02 	ON dbo.AAGroupMenu (MenuId)
GO
CREATE INDEX IX_AAGroupMenu_03 	ON dbo.AAGroupMenu (UseYn)
GO

--�޴����α�
IF OBJECT_ID('dbo.AAMenuOpenLog') IS NOT NULL 
	DROP TABLE dbo.AAMenuOpenLog
GO

CREATE TABLE dbo.AAMenuOpenLog
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	MenuId			int					NOT NULL REFERENCES dbo.AAMenu (ID)
,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	OpenDtime		datetime				NULL
,	CloseDtime		datetime				NULL
,	Status			char(1)				NOT NULL

,	CONSTRAINT PK_AAMenuOpenLog PRIMARY KEY (ID)	
)
GO
CREATE INDEX IX_AAMenuOpenLog_01 ON dbo.AAMenuOpenLog (MenuId)
GO
CREATE INDEX IX_AAMenuOpenLog_02 ON dbo.AAMenuOpenLog (UserId)
GO

--�ϸ�ũ
IF OBJECT_ID('dbo.AABookmark') IS NOT NULL 
	DROP TABLE dbo.AABookmark
GO

CREATE TABLE dbo.AABookmark
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	UserId			int					NOT NULL REFERENCES dbo.AAUser (ID)
,	MenuId			int					NOT NULL REFERENCES dbo.AAMenu (ID)

,	SortOrder		int						NULL

,	CONSTRAINT PK_AABookmark PRIMARY KEY (ID)	
)
GO
CREATE UNIQUE INDEX IX_AABookmark ON dbo.AABookmark (UserId, MenuId)
GO
CREATE INDEX IX_AABookmark_01 ON dbo.AABookmark (MenuId)
GO
CREATE INDEX IX_AABookmark_02 ON dbo.AABookmark (UserId)
GO

--���ٹ�ư
IF OBJECT_ID('dbo.AAButton') IS NOT NULL 
	DROP TABLE dbo.AAButton
GO

CREATE TABLE dbo.AAButton
(
	ID				int 				NOT NULL IDENTITY(1000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL
	
,	ButtonName		nvarchar(50)		NOT NULL
,	Instance		nvarchar(50)		NOT NULL
,	UseYn			char(1)				NOT NULL
,	Description		nvarchar(1000)			NULL

,	CONSTRAINT PK_AAButton PRIMARY KEY (ID)
)
GO

--ȭ�� ��ư����
IF OBJECT_ID('dbo.AAViewButton') IS NOT NULL 
	DROP TABLE dbo.AAViewButton
GO

CREATE TABLE dbo.AAViewButton
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ViewId			int					NOT NULL REFERENCES dbo.AAView (ID)
,	ButtonId		int					NOT NULL REFERENCES dbo.AAButton (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAViewButton PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAViewButton	ON dbo.AAViewButton (ViewId, ButtonId)
GO
CREATE INDEX IX_AAViewButton_01		ON dbo.AAViewButton (ViewId)
GO
CREATE INDEX IX_AAViewButton_02 	ON dbo.AAViewButton (ButtonId)
GO

--�� ����
if object_id('dbo.AAViewRole') is NOT NULL 
	drop TABLE dbo.AAViewRole
GO
CREATE TABLE dbo.AAViewRole
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ViewId			int					NOT NULL REFERENCES dbo.AAView (ID)
,	RoleId			int					NOT NULL REFERENCES dbo.AARole (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAViewRole PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAViewRole 	ON dbo.AAViewRole (ViewId, RoleId)
GO
CREATE INDEX IX_AAViewRole_01 	ON dbo.AAViewRole (ViewId)
GO
CREATE INDEX IX_AAViewRole_02 	ON dbo.AAViewRole (RoleId)
GO
CREATE INDEX IX_AAViewRole_03 	ON dbo.AAViewRole (UseYn)
GO

--ȭ��, ���ѱ׷�, ��ư ��뿩��
IF OBJECT_ID('dbo.AAViewRoleButton') IS NOT NULL 
	DROP TABLE dbo.AAViewRoleButton
GO

CREATE TABLE dbo.AAViewRoleButton
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ViewId			int					NOT NULL REFERENCES dbo.AAView (ID)
,	RoleId			int					NOT NULL REFERENCES dbo.AARole (ID)
,	ButtonId		int					NOT NULL REFERENCES dbo.AAButton (ID)

,	UseYn			char(1)				NOT NULL

,	CONSTRAINT PK_AAViewRoleButton PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAViewRoleButton	ON dbo.AAViewRoleButton (ViewId, RoleId, ButtonId)
GO
CREATE INDEX IX_AAViewRoleButton_01		ON dbo.AAViewRoleButtons (ViewId)
GO
CREATE INDEX IX_AAViewRoleButton_02		ON dbo.AAViewRoleButtons (RoleId)
GO
CREATE INDEX IX_AAViewRoleButton_03 	ON dbo.AAViewRoleButtons (ButtonId)
GO
CREATE INDEX IX_AAViewRoleButton_04 	ON dbo.AAViewRoleButtons (UseYn)
GO

--����
IF OBJECT_ID('dbo.AAHelp') IS NOT NULL 
	DROP TABLE dbo.AAHelp
GO

CREATE TABLE dbo.AAHelp
(
	ID				int 				NOT NULL IDENTITY(1000000, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	HelpName		nvarchar(100)		NOT NULL
,	HelpType		char(2)				NOT NULL
,	Content 		nvarchar(max)			NULL
,	ContentByRte	nvarchar(max)			NULL

,	CONSTRAINT PK_AAHelp PRIMARY KEY (ID)
)
GO

CREATE INDEX IX_AAHelps_01 ON dbo.AAHelp (HelpType)
GO

--ȭ�麰 ����
IF OBJECT_ID('dbo.AAViewHelp') IS NOT NULL 
	DROP TABLE dbo.AAViewHelp
GO

CREATE TABLE dbo.AAViewHelp
(
	ID				int 				NOT NULL IDENTITY(1, 1)
,	CreateDate 		datetime 			NOT NULL
,	CreateBy 		int 				NOT NULL
,	CreateByName	nvarchar(50)		NOT NULL
,	UpdateDate		datetime 				NULL
,	UpdateBy 		int 					NULL
,	UpdateByName	nvarchar(50)			NULL

,	ViewId			int 				NOT NULL REFERENCES dbo.AAView (ID)
,	HelpId			int					NOT NULL REFERENCES dbo.AAHelp (ID)

,	CONSTRAINT PK_AAViewHelp PRIMARY KEY (ID)
)
GO
CREATE UNIQUE INDEX IX_AAViewHelp ON dbo.AAViewHelp (ViewId)
GO
CREATE INDEX IX_AAViewHelp_01 ON dbo.AAViewHelp (HelpId)
GO

