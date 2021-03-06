
USE [AmadeusDB]
GO
/****** Object:  Table [dbo].[Travel]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travel](
	[Id] [int] NULL,
	[StartDate] [date] NULL,
	[Observations] [nvarchar](max) NULL,
	[Email] [nvarchar](30) NULL,
	[Name] [nvarchar](500) NULL,
	[Active] [bit] NULL,
	[Nacionality] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Travel] ([Id], [StartDate], [Observations], [Email], [Name], [Active], [Nacionality]) VALUES (3, CAST(N'2022-04-23' AS Date), N'observations 1', N'alksjdkajsdl@asdsad', N'Passanger 1', 1, 4)
GO
INSERT [dbo].[Travel] ([Id], [StartDate], [Observations], [Email], [Name], [Active], [Nacionality]) VALUES (4, CAST(N'2022-04-03' AS Date), N'observations 2', N'robinson_urquijo@yahoo.es', N'Passanger 2', 1, 0)
GO
INSERT [dbo].[Travel] ([Id], [StartDate], [Observations], [Email], [Name], [Active], [Nacionality]) VALUES (5, CAST(N'2022-04-04' AS Date), N'observations 3', N'robinson_urquijo@yahoo.es', N'Passanger 3', 1, 1)
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateTravel]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CreateTravel]
@StartDate Date, 
@Observations NVARCHAR(MAX), 
@Email NVARCHAR(30), 
@Name NVARCHAR(500),
@Active BIT,
@Nacionality INT
AS
BEGIN
	BEGIN
	DECLARE @Id INT
	SELECT @Id=ISNULL(MAX(Id),0)+1 FROM [dbo].[Travel]
	INSERT INTO [dbo].[Travel] (Id,
			StartDate,  
			Observations, 
			Email,
			[Name],
			Active,
			Nacionality
	) VALUES(@Id,
			@StartDate,  
			@Observations, 
			@Email,
			@Name,
			@Active,
			@Nacionality)
			
	END



END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteTravel]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteTravel]
@Id int
AS
BEGIN
	BEGIN
	DELETE [dbo].[Travel] 
	WHERE Id=@Id
			
	END



END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTravel]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetTravel]
@Id INT
AS
BEGIN
	BEGIN
			SELECT * FROM [dbo].[Travel]
			WHERE Id= @Id
			
	END



END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTravels]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetTravels]

AS
BEGIN
	BEGIN
			SELECT * FROM [dbo].[Travel]
			
	END



END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateTravel]    Script Date: 4/04/2022 10:03:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateTravel]
@Id int,
@StartDate Date, 
@Observations NVARCHAR(MAX), 
@Email NVARCHAR(30), 
@Name NVARCHAR(500),
@Active BIT,
@Nacionality INT
AS
BEGIN
	BEGIN
	UPDATE [dbo].[Travel] 
	SET StartDate= @StartDate,  
		Observations=@Observations, 
		Email=@Email,
		[Name]=@Name,
		Active=@Active,
		Nacionality=@Nacionality
	WHERE Id=@Id
			
	END



END

