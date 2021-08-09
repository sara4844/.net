CREATE PROCEDURE [dbo].[GetArtists]
AS
    BEGIN
	    SELECT [artistID]
              ,[dateCreation]
              ,[title]
              ,[biography]
              ,[imageURL]
              ,[heroURL]
        FROM [dbo].[Artist]
END
GO