CREATE PROCEDURE [dbo].[GetArtistDetails]
	@artistID INT
AS
BEGIN

	SELECT	ART.artistID
			,ART.biography
			,ART.dateCreation	as Artist_DateCreation
			,ART.heroURL
			,ART.imageURL		as Artist_ImageURL
			,ART.title			as Artist_Title
			,ALB.albumID
			,ALB.dateCreation	as Album_DateCreation
			,ALB.imageURL		as Album_ImageURL
			,ALB.title			as Album_Title
			,ALB.year
			,SNG.bpm
			,SNG.chart
			,SNG.customMix
			,SNG.dateCreation	as Song_DateCreation
			,SNG.multitracks
			,SNG.patches
			,SNG.proPresenter
			,SNG.rehearsalMix
			,SNG.songID
			,SNG.songSpecificPatches
			,SNG.timeSignature
			,SNG.title			as Song_Title
	FROM	[dbo].[Artist]	ART
	JOIN	[dbo].[Album]	ALB 
	ON		ART.artistID = ALB.artistID 
	JOIN	[dbo].[Song]	SNG
	ON		ART.artistID = SNG.artistID
	AND		ALB.albumID = SNG.albumID
	WHERE	ART.artistID = @artistID

END
GO


