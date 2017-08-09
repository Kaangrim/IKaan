/* **************************************************************************************
 * Database		: IKAAN_BIZ
 * Description	: 비즈니스 데이터베이스
 * CREATEd		: 2016.06.23
 * Author		: Woo Jong Ho 
** *********************************************************************************** */
USE IKAAN_BIZ
GO

--모듈정보
CREATE TABLE AAModule
(
	ID				int IDENTITY(1000, 1)	NOT NULL
	
,	ModuleName		nvarchar(100)			NOT NULL
,	Assembly		nvarchar(100)				NULL
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Modules PRIMARY KEY (ModuleId)
)
GO
CREATE INDEX IX_Modules_UseYn ON SAUT.Modules (UseYn)
GO

--화면정보
CREATE TABLE SAUT.Views
(
	ViewId			int						NOT NULL IDENTITY(1000, 1)
	
,	ViewName		nvarchar(100)			NOT NULL
,	ViewType		varchar(4)				NOT NULL
,	ParentViewId	int							NULL REFERENCES SAUT.Views (ViewId)
,	ModuleId		int						NOT NULL REFERENCES SAUT.Modules (ModuleId)
,	Namespace		nvarchar(100)				NULL
,	Instance		nvarchar(100)				NULL
,	WebUrl			nvarchar(100)				NULL
,	SmallIcon		nvarchar(50)				NULL
,	LargeIcon		nvarchar(50)				NULL
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Views PRIMARY KEY (ViewId)			
)
GO
CREATE INDEX IX_Views_ModuleId 		ON SAUT.Views (ModuleId)
GO
CREATE INDEX IX_Views_UseYn 		ON SAUT.Views (UseYn)
GO
CREATE INDEX IX_Views_ParentViewId 	ON SAUT.Views (ParentViewId)
GO

--메뉴정보
CREATE TABLE SAUT.Menus
(
	MenuId			int IDENTITY(100000, 1)	NOT NULL
	
,	MenuName		nvarchar(100)			NOT NULL
,	ParentMenuId	int							NULL REFERENCES SAUT.Menus (MenuId)
,	MenuType		char(1)					NOT NULL --0: 기본메뉴(Tree), 1:별도구성(Bar형식)
,	SortSeq			int						NOT NULL
,	MenuPath		nvarchar(1000)				NULL
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Menus PRIMARY KEY (MenuId)			
)
GO
CREATE INDEX IX_Menus_ParentMenuId 	ON SAUT.Menus (ParentMenuId)
GO
CREATE INDEX IX_Menus_UseYn 		ON SAUT.Menus (UseYn)
GO

--메뉴, 화면 매핑
IF OBJECT_ID('SAUT.MenuViews') IS NOT NULL DROP TABLE SAUT.MenuViews
GO
CREATE TABLE SAUT.MenuViews
(
	MenuId			int						NOT NULL REFERENCES SAUT.Menus (MenuId)
,	ViewId			int						NOT NULL REFERENCES SAUT.Views (ViewId)

,	ViewParams		nvarchar(100)				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_MenuViews PRIMARY KEY (MenuId)
)
GO
CREATE INDEX IX_MenuViews_MenuId ON SAUT.MenuViews (MenuId)
GO
CREATE INDEX IX_MenuViews_ViewId ON SAUT.MenuViews (ViewId)
GO

--권한정보
CREATE TABLE SAUT.Roles
(
	RoleId			int IDENTITY(1000, 1)	NOT NULL
	
,	RoleName		nvarchar(100)			NOT NULL
,	ParentRoleId	int							NULL REFERENCES SAUT.Roles (RoleId)
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Roles PRIMARY KEY (RoleId)		
)
GO
CREATE INDEX IX_Roles_ParentRoleId 	ON SAUT.Roles (ParentRoleId)
GO
CREATE INDEX IX_Roles_UseYn 		ON SAUT.Roles (UseYn)
GO

--사용자정보
CREATE TABLE SAUT.Users
(
	UserId			int IDENTITY(100000, 1)	NOT NULL
	
,	UserName		nvarchar(50)			NOT NULL
,	LoginId			nvarchar(50)				NULL
,	Password		nvarchar(100)				NULL
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Users PRIMARY KEY (UserId)		
)
GO
CREATE INDEX IX_Users_UseYn 	ON SAUT.Users (UseYn)
GO
CREATE INDEX IX_Users_LoginId 	ON SAUT.Users (LoginId)
GO

--사용자 비밀번호 변경이력
CREATE TABLE SAUT.UserPasswordHistory
(
	HistoryId		int IDENTITY(1, 1)		NOT NULL
	
,	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)
,	OldPassword		nvarchar(100)				NULL
,	NewPassword		nvarchar(100)				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_UserPasswordHistory PRIMARY KEY (HistoryId)	
)
GO
CREATE INDEX IX_UserPasswordHistory_UserId ON SAUT.UserPasswordHistory (UserId)
GO

--사용자권한 매핑
CREATE TABLE SAUT.UserRoles
(
	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)
,	RoleId			int						NOT NULL REFERENCES SAUT.Roles (RoleId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_UserRoles PRIMARY KEY (UserId, RoleId)	
)
GO
CREATE INDEX IX_UserRoles_UserId 	ON SAUT.UserRoles (UserId)
GO
CREATE INDEX IX_UserRoles_RoleId 	ON SAUT.UserRoles (RoleId)
GO
CREATE INDEX IX_UserRoles_UseYn 	ON SAUT.UserRoles (UseYn)
GO

--로그인로그
if object_id(N'SAUT.LoginLog') is NOT NULL drop TABLE SAUT.LoginLog
GO
CREATE TABLE SAUT.LoginLog
(
	LogId			int IDENTITY(1, 1)		NOT NULL
	
,	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)
,	LoginId			nvarchar(50)				NULL
,	Version			nvarchar(100)				NULL
,	MainSkin		nvarchar(50)				NULL
,	GridSkin		nvarchar(50)				NULL
,	IpAddress		nvarchar(50)				NULL
,	MacAddress		nvarchar(50)				NULL
,	LoginDtime		datetime				NOT NULL
,	LogoutDtime		datetime					NULL
,	Status			char(1)						NULL

,	CONSTRAINT PK_LoginLog PRIMARY KEY (LogId)
)
GO
CREATE INDEX IX_LoginLog_UserId ON SAUT.LoginLog (UserId)
GO

--사용자그룹
CREATE TABLE SAUT.Groups
(
	GroupId			int IDENTITY(1000, 1)	NOT NULL
	
,	GroupName		nvarchar(100)			NOT NULL
,	ParentGroupId	int							NULL REFERENCES SAUT.Groups (GroupId)
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Groups PRIMARY KEY (GroupId)	
)
GO
CREATE INDEX IX_Groups_ParentGroupId 	ON SAUT.Groups (ParentGroupId)
GO
CREATE INDEX IX_Groups_UseYn 			ON SAUT.Groups (UseYn)
GO

--사용자그룹별 사용자 목록
CREATE TABLE SAUT.GroupUsers
(
	GroupId			int						NOT NULL REFERENCES SAUT.Groups (GroupId)
,	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_GroupUsers PRIMARY KEY (GroupId, UserId)	
)
GO
CREATE INDEX IX_GroupUsers_GroupId 	ON SAUT.GroupUsers (GroupId)
GO
CREATE INDEX IX_GroupUsers_UserId 	ON SAUT.GroupUsers (UserId)
GO
CREATE INDEX IX_GroupUsers_UseYn 	ON SAUT.GroupUsers (UseYn)
GO

--사용자그룹별 권한 매핑
CREATE TABLE SAUT.GroupRoles
(
	GroupId			int						NOT NULL REFERENCES SAUT.Groups (GroupId)
,	RoleId			int						NOT NULL REFERENCES SAUT.Roles (RoleId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_GroupRoles PRIMARY KEY (GroupId, RoleId)	
)
GO
CREATE INDEX IX_GroupRoles_GroupId 	ON SAUT.GroupRoles (GroupId)
GO
CREATE INDEX IX_GroupRoles_RoleId 	ON SAUT.GroupRoles (RoleId)
GO
CREATE INDEX IX_GroupRoles_UseYn 	ON SAUT.GroupRoles (UseYn)
GO

--그룹별 메뉴 매핑
if object_id('SAUT.GroupMenus') is NOT NULL Drop TABLE SAUT.GroupMenus
GO
CREATE TABLE SAUT.GroupMenus
(
	GroupId			int						NOT NULL REFERENCES SAUT.Groups (GroupId)
,	MenuId			int						NOT NULL REFERENCES SAUT.Menus (MenuId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_GroupMenus PRIMARY KEY (GroupId, MenuId)	
)
GO
CREATE INDEX IX_GroupMenus_GroupId 	ON SAUT.GroupMenus (GroupId)
GO
CREATE INDEX IX_GroupMenus_MenuId 	ON SAUT.GroupMenus (MenuId)
GO
CREATE INDEX IX_GroupMenus_UseYn 	ON SAUT.GroupMenus (UseYn)
GO

--메뉴사용로그
CREATE TABLE SAUT.MenuOpenLog
(
	LogId		int IDENTITY(1, 1)		NOT NULL
	
,	MenuId			int						NOT NULL REFERENCES SAUT.Menus (MenuId)
,	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)
,	OpenDtime		datetime					NULL
,	CloseDtime		datetime					NULL
,	Status			char(1)					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_MenuOpenLog PRIMARY KEY (LogId)	
)
GO
CREATE INDEX IX_MenuOpenLog_MenuId ON SAUT.MenuOpenLog (MenuId)
GO
CREATE INDEX IX_MenuOpenLog_UserId ON SAUT.MenuOpenLog (UserId)
GO

--북마크
CREATE TABLE SAUT.Bookmark
(
	UserId			int						NOT NULL REFERENCES SAUT.Users (UserId)
,	MenuId			int						NOT NULL REFERENCES SAUT.Menus (MenuId)

,	SortSeq			int							NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Bookmark PRIMARY KEY (UserId, MenuId)	
)
GO
CREATE INDEX IX_Bookmark_MenuId ON SAUT.Bookmark (MenuId)
GO
CREATE INDEX IX_Bookmark_UserId ON SAUT.Bookmark (UserId)
GO

--툴바버튼
CREATE TABLE SAUT.Buttons
(
	ButtonId		int IDENTITY(1000, 1)	NOT NULL
	
,	ButtonName		nvarchar(50)			NOT NULL
,	Instance		nvarchar(50)			NOT NULL
,	UseYn			dbo.Yn					NOT NULL
,	Description		dbo.Description				NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_Buttons PRIMARY KEY (ButtonId)
)
GO

--화면 버튼설정
CREATE TABLE SAUT.ViewButtons
(
	ViewId			int						NOT NULL REFERENCES SAUT.Views (ViewId)
,	ButtonId		int						NOT NULL REFERENCES SAUT.Buttons (ButtonId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_ViewButtons PRIMARY KEY (ViewId, ButtonId)
)
GO
CREATE INDEX IX_ViewButtons_ViewId 		ON SAUT.ViewButtons (ViewId)
GO
CREATE INDEX IX_ViewButtons_ButtonId 	ON SAUT.ViewButtons (ButtonId)
GO

--뷰 권한
if object_id('SAUT.ViewRoles') is NOT NULL drop TABLE SAUT.ViewRoles
GO
CREATE TABLE SAUT.ViewRoles
(
	ViewId			int						NOT NULL REFERENCES SAUT.Views (ViewId)
,	RoleId			int						NOT NULL REFERENCES SAUT.Roles (RoleId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_ViewRoles PRIMARY KEY (ViewId, RoleId)
)
GO
CREATE INDEX IX_ViewRoles_ViewId 	ON SAUT.ViewRoles (ViewId)
GO
CREATE INDEX IX_ViewRoles_RoleId 	ON SAUT.ViewRoles (RoleId)
GO
CREATE INDEX IX_ViewRoles_UseYn 	ON SAUT.ViewRoles (UseYn)
GO

--화면, 권한그룹, 버튼 사용여부
CREATE TABLE SAUT.ViewRoleButtons
(
	ViewId			int						NOT NULL REFERENCES SAUT.Views (ViewId)
,	RoleId			int						NOT NULL REFERENCES SAUT.Roles (RoleId)
,	ButtonId		int						NOT NULL REFERENCES SAUT.Buttons (ButtonId)

,	UseYn			dbo.Yn					NOT NULL

,	InsertDtime		datetime				NOT NULL
,	InsertUserId	int						NOT NULL
,	UpdateDtime		datetime					NULL
,	UpdateUserId	int							NULL

,	CONSTRAINT PK_ViewRoleButtons PRIMARY KEY (ViewId, RoleId, ButtonId)
)
GO
CREATE INDEX IX_ViewRoleButtons_ViewId 		ON SAUT.ViewRoleButtons (ViewId)
GO
CREATE INDEX IX_ViewRoleButtons_RoleId 		ON SAUT.ViewRoleButtons (RoleId)
GO
CREATE INDEX IX_ViewRoleButtons_ButtonId 	ON SAUT.ViewRoleButtons (ButtonId)
GO
CREATE INDEX IX_ViewRoleButtons_UseYn 		ON SAUT.ViewRoleButtons (UseYn)
GO

--도움말
CREATE TABLE SAUT.Helps
(
	HelpId			int IDENTITY(1000000, 1)	NOT NULL
,	HelpName		nvarchar(100)				NOT NULL
,	HelpType		char(2)						NOT NULL
,	Content 		nvarchar(max)					NULL
,	ContentByRte	nvarchar(max)					NULL

,	InsertDtime		datetime					NOT NULL
,	InsertUserId	int							NOT NULL
,	UpdateDtime		datetime						NULL
,	UpdateUserId	int								NULL

,	CONSTRAINT PK_Helps PRIMARY KEY (HelpId)
)
GO

CREATE INDEX IX_Helps_HelpType ON SAUT.Helps (HelpType)
GO

--화면별 도움말
CREATE TABLE SAUT.ViewHelps
(
	ViewId			int 						NOT NULL REFERENCES SAUT.Views (ViewId)
,	HelpId			int							NOT NULL REFERENCES SAUT.Helps (HelpID)

,	InsertDtime		datetime					NOT NULL
,	InsertUserId	int							NOT NULL
,	UpdateDtime		datetime						NULL
,	UpdateUserId	int								NULL

,	CONSTRAINT PK_ViewHelps PRIMARY KEY (ViewId, HelpId)
)
GO
CREATE UNIQUE INDEX IX_ViewHelps_ViewId ON SAUT.ViewHelps (ViewId)
GO
CREATE INDEX IX_ViewHelps_HelpId ON SAUT.ViewHelps (HelpId)
GO

/* ************************************************************************************************
	기본데이터 생성
** ***********************************************************************************************/
declare @moduleId	int
insert into SAUT.Modules (ModuleName, Assembly, UseYn, InsertDtime, InsertUserId) values ('메인화면모듈', 'JW.PMS.Win.exe'		, 'Y', GetDate(), 100000)
insert into SAUT.Modules (ModuleName, Assembly, UseYn, InsertDtime, InsertUserId) values ('기본화면모듈', 'JW.PMS.Win.View.dll'	, 'Y', GetDate(), 100000)
set @moduleId = scope_identity();

--화면관리
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('모듈'			, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'ModulesListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('화면'			, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'ViewsListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('메뉴'			, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'MenusListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('사용자그룹'	, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'GroupsListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('권한그룹'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'RolesListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('툴바'			, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'ButtonsListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('사용자'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'UsersListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('권한설정'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'GroupRoleListView'	, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('북마크'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'BookmarkListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('로그인로그'	, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'LoginLogListView'		, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('메뉴사용현황'	, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'MenuOpenLogListView'	, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('용어사전'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'DictionaryListView'	, 'Y', getdate(), 100000);
insert into SAUT.Views (ViewName, ModuleId, ViewType, Namespace, Instance, UseYn, InsertDtime, InsertUserId) values ('공통코드'		, @moduleId, 'VIEW'	,'JW.PMS.Win.View.Auth', 'CodesListView'		, 'Y', getdate(), 100000);
GO

declare @parentMenuId	int

insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('시스템관리', NULL, '1', 1, 'Y', getdate(), 100000);
set @parentMenuId = SCOPE_IDENTITY();

insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('모듈관리'		, @parentMenuId, '1', 1001, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('화면관리'		, @parentMenuId, '1', 1002, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('메뉴관리'		, @parentMenuId, '1', 1003, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('그룹관리'		, @parentMenuId, '1', 1004, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('권한관리'		, @parentMenuId, '1', 1005, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('툴바관리'		, @parentMenuId, '1', 1006, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('사용자관리'	, @parentMenuId, '1', 1007, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('권한설정'		, @parentMenuId, '1', 1008, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('북마크관리'	, @parentMenuId, '1', 1009, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('로그인로그'	, @parentMenuId, '1', 1010, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('메뉴사용현황'	, @parentMenuId, '1', 1011, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('용어사전관리'	, @parentMenuId, '1', 1012, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('공통코드관리'	, @parentMenuId, '1', 1013, 'Y', getdate(), 100000);

insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('비즈니스', NULL, '0', 2, 'Y', getdate(), 100000);
set @parentMenuId = SCOPE_IDENTITY();

insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('기초코드관리', @parentMenuId, '0', 2001, 'Y', getdate(), 100000);
insert into SAUT.Menus (MenuName, ParentMenuId, MenuType, SortSeq, UseYn, InsertDtime, InsertUserId) values ('프로젝트관리', @parentMenuId, '0', 2002, 'Y', getdate(), 100000);
GO

INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100001, 1000, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100002, 1001, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100003, 1002, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100004, 1003, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100005, 1004, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100006, 1005, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100007, 1006, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100008, 1007, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100009, 1008, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100010, 1009, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100011, 1010, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100012, 1011, getdate(), 100000);
INSERT INTO SAUT.MenuViews (MenuId, ViewId, InsertDtime, InsertUserId) Values (100013, 1012, getdate(), 100000);
GO

insert into SAUT.Roles (RoleName, ParentRoleId, UseYn, InsertDtime, InsertUserId) values ('전체권한', NULL, 'Y', getdate(), 100000)
GO

insert into SAUT.Users (UserName, UseYn, LoginId, Password, InsertDtime, InsertUserId) values ('관리자', 'Y', 'admin', 'admin', getdate(), 100000)
GO

insert into SAUT.UserRoles (UserId, RoleId, UseYn, InsertDtime, InsertUserId) values (100000, 1000, 'Y', getdate(), 100000)
GO

insert into SAUT.Groups (GroupName, ParentGroupId, UseYn, InsertDtime, InsertUserId) values ('시스템그룹', NULL, 'Y', GetDate(), 100000)
GO

insert into SAUT.GroupUsers (GroupId, UserId, UseYn, InsertDtime, InsertUserId) values (1000, 100000, 'Y', getdate(), 100000)
GO

insert into SAUT.GroupRoles (GroupId, RoleId, UseYn, InsertDtime, InsertUserId) values (1000, 1000, 'Y', getdate(), 100000)
GO

--버튼
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('신규'		, 'barButtonNew'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('저장'		, 'barButtonSave'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('저장 후 신규'	, 'barButtonSaveAndNew'		, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('저장 후 종료'	, 'barButtonSaveAndClose'	, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('복사'		, 'barButtonCopy'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('삭제'		, 'barButtonDelete'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('확정'		, 'barButtonConfirm'		, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('취소'		, 'barButtonCancel'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('파일변환'		, 'barButtonExport'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('다운로드'		, 'barButtonDownload'		, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('인쇄'		, 'barButtonPrint'			, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('북마크'		, 'barButtonBookmark'		, 'Y', getdate(), 100000);
insert into SAUT.Buttons (ButtonName, Instance, UseYn, InsertDtime, InsertUserId) values ('종료'		, 'barButtonClose'			, 'Y', getdate(), 100000);
GO
