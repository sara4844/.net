CREATE PROCEDURE [dbo].[CreateArtist]
	@title varchar(100),
	@biography varchar(max),
	@imageURL varchar(500),
	@heroURL varchar(500)

AS
BEGIN

INSERT INTO [dbo].[Artist]
           ([dateCreation]
           ,[title]
           ,[biography]
           ,[imageURL]
           ,[heroURL])
     VALUES
           (GETDATE()
           ,@title
           ,@biography
           ,@imageURL
           ,@heroURL)

SELECT CAST(SCOPE_IDENTITY() as int)
END
GO