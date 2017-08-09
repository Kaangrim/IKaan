
	--모듈추가
  INSERT INTO dbo.AAModule
  (
	CreateDate, CreateBy, CreateByName,
	ModuleName, Assembly, UseYn
  )
  SELECT GetDate(), 1000, 'SYSTEM', '시스템', 'IKaan.Biz.View.Sys.dll', 'Y'
  GO

  --메뉴추가
  INSERT INTO DBO.AAMenu
  (
	CreateDate, CreateBy, CreateByName,
	MenuName, ParentID, MenuType, SortOrder, UseYn
  )
  SELECT GetDate(), 1000, 'SYSTEM', '모듈관리', 100000, '0', 0, 'Y'
  GO

	--화면추가
  INSERT INTO DBO.AAView
  (
	CreateDate, CreateBy, CreateByName,
	ViewName, ViewType, ParentID, ModuleID, Namespace, Instance, UseYn
  )
  SELECT GetDate(), 1000, 'SYSTEM', '화면관리', '2', null, 1000, 'IKaan.Biz.View.Sys.Forms', 'AAViewForm', 'Y'
  SELECT @@IDENTITY
  GO

  
  --메뉴화면매핑
  INSERT INTO dbo.AAMenuView
  (
	CreateDate, CreateBy, CreateByName,
	MenuID, ViewID
  )
  SELECT GetDate(), 1000, 'SYSTEM', 100002, 1004
  GO

  --검증
  SELECT	AA.ID			as MenuID
		,	AA.MenuName		as MenuName
		,	CC.ID			as ViewID
		,	CC.ViewName		as ViewName
		,	CC.ViewType		as ViewType
		,	EE.Assembly		as Assembly
		,	CC.Namespace	as Namespace
		,	CC.Instance		as Instance
	FROM	dbo.AAMenu AA WITH (NOLOCK)	
			LEFT JOIN
				dbo.AAMenuView BB WITH (NOLOCK)
					ON AA.ID = BB.MenuID
			LEFT JOIN
				dbo.AAView CC WITH (NOLOCK)
					ON BB.ViewID = CC.ID
			LEFT JOIN
				dbo.AAModule EE WITH (NOLOCK)
					ON CC.ModuleID = EE.ID
	WHERE	AA.ID = 100011


	SELECT	AA.ID			as MenuID
					,	AA.MenuName		as MenuName
					,	CC.ID			as ViewID
					,	CC.ViewName		as ViewName
					,	CC.ViewType		as ViewType
					,	EE.Assembly		as Assembly
					,	CC.Namespace	as Namespace
					,	CC.Instance		as Instance
				FROM	dbo.AAMenu AA WITH (NOLOCK)	
						INNER JOIN
							dbo.AAMenuView BB WITH (NOLOCK)
								ON AA.ID = BB.MenuID
						INNER JOIN
							dbo.AAView CC WITH (NOLOCK)
								ON BB.ViewID = CC.ID
						INNER JOIN
							dbo.AAModule EE WITH (NOLOCK)
								ON CC.ModuleID = EE.ID
				WHERE	AA.ID = 100002