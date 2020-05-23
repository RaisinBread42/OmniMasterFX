
-- initial roles
IF NOT EXISTS (SELECT * FROM [dbo].[AspNetRoles] WHERE [Name] = 'Admin')
BEGIN

	INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
	VALUES (NEWID(),'Admin','Admin', NEWID());
END
