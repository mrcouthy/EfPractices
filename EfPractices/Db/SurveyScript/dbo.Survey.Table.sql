/****** Object:  Table [dbo].[Survey]    Script Date: 6/19/2016 1:55:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[SurveyId] [int] IDENTITY(1,1) NOT NULL,
	[UniqueId] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
	[OrganizationId] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedOn] [datetime] NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedOn] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL 
)
GO
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (1, N'001', N'New Era Survey', N'This is test', N'58039997.png', 2, N'Admin', CAST(0x0000A606001D6A78 AS DateTime), N'admin', CAST(0x0000A61301455A27 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (2, N'SRVCOD', N'New Survey by Salil', N'this is a test survey', N'', 2, N'Admin', CAST(0x0000A60E002329F8 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (3, N'SURV002', N'New Test Survey', N'this is a test survey', N'', 2, N'Admin', CAST(0x0000A612017DD1E5 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (4, N'AP001', N'Test Survey - Alok', N'Sample test data', N'images.png', 2, N'admin', CAST(0x0000A618017DB4E4 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (5, N'AL001', N'Test Survey - Alok', N'Test survey', N'', 2, N'admin', CAST(0x0000A6190051DF6F AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (6, N'AL001', N'Test Survey - Alok', N'Test survey', N'', 2, N'admin', CAST(0x0000A619005205B3 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (7, N'AL001', N'Test Survey - Alok', N'Test survey', N'', 2, N'admin', CAST(0x0000A6190054D855 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (8, N'AL001', N'Test Survey - Alok', N'Test survey', N'', 2, N'admin', CAST(0x0000A61C008EB991 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (9, N'AP002', N'Test Survey - Alok Patel', N'Test Survey - Alok Patel', N'', 1, N'admin', CAST(0x0000A61B0149E3CC AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (10, N'100', N'utsav test0927', N'testing ', NULL, 2, N'admin', CAST(0x0000A61B01555158 AS DateTime), N'admin', CAST(0x0000A61B015A4B77 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (11, N'AP003', N'Test Survey - Alok Patel', N'Test Survey', N'', 3, N'admin', CAST(0x0000A61B015A917B AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (12, N'AP006', N'Test Survey - AP', N'', N'Dashboard.jpg', 2, N'admin', CAST(0x0000A629015A57DB AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (14, N'Demo Survey 2', N'Demo Survey', N'Demo Survey', N'Dashboard.jpg', 2, N'admin', CAST(0x0000A629017B1A00 AS DateTime), N'admin', CAST(0x0000A629017B6B02 AS DateTime), NULL, NULL, 0, 0)
INSERT [dbo].[Survey] ([SurveyId], [UniqueId], [Name], [Description], [Logo], [OrganizationId], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [DeletedBy], [DeletedOn], [IsActive], [IsDeleted]) VALUES (15, N'5555', N'Hosehold Survey', N'Takes note from each household.', N'', 3, N'admin', CAST(0x0000A62A001078B6 AS DateTime), NULL, NULL, NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Survey] OFF
 