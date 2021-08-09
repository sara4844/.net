CREATE PROCEDURE [dbo].[GetSongs]
AS
BEGIN
	SELECT [songID]
      ,[dateCreation]
      ,[albumID]
      ,[artistID]
      ,[title]
      ,[bpm]
      ,[timeSignature]
      ,[multitracks]
      ,[customMix]
      ,[chart]
      ,[rehearsalMix]
      ,[patches]
      ,[songSpecificPatches]
      ,[proPresenter]
  FROM [dbo].[Song]

END
GO