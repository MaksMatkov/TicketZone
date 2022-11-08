INSERT INTO [fbd].[T_User]
           ([Name]
           ,[Email]
           ,[Password]
           ,[IsApproved]
           ,[Last_Visited]
           ,[FK_Role])
     VALUES
           ('admin'
           ,'admin@admin.com'
           ,'adminadmin'
           ,1
           ,getdate()
           ,2),
		   ('user'
           ,'user@user.com'
           ,'useruser'
           ,1
           ,getdate()
           ,1)
GO


