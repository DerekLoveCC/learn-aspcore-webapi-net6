USE [Walks]
GO
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [Lat], [Long], [Population]) VALUES (N'1ad7c230-13e0-464e-9d2e-13df4af4b648', N'code2-changed', N'name2-changed', 21, 21, 21, 21)
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [Lat], [Long], [Population]) VALUES (N'6e539bc5-e296-4cba-b056-5e83f6a695f9', N'code1', N'name1', 1, 1, 1, 1)
INSERT [dbo].[Regions] ([Id], [Code], [Name], [Area], [Lat], [Long], [Population]) VALUES (N'b2b1aecd-8846-4e04-b1be-b5b28f345323', N'code3', N'name2', 3, 3, 3, 3)
INSERT [dbo].[WalkDifficulty] ([Id], [Code]) VALUES (N'2a830f16-205f-4041-91ed-2d4bacff6779', N'WalkDifficulty3')
INSERT [dbo].[WalkDifficulty] ([Id], [Code]) VALUES (N'23bcb536-6131-4da5-8bc8-70804cc0dc83', N'WalkDifficulty2')
INSERT [dbo].[WalkDifficulty] ([Id], [Code]) VALUES (N'2997f574-63bb-4edd-bc14-d539c927614b', N'WalkDifficulty1')
INSERT [dbo].[Walks] ([Id], [Name], [Length], [RegionId], [WalkDifficultyId]) VALUES (N'fa855f4d-c5ad-4b42-ac8b-667af3a9500d', N'walksname1', 1, N'1ad7c230-13e0-464e-9d2e-13df4af4b648', N'2a830f16-205f-4041-91ed-2d4bacff6779')
INSERT [dbo].[Walks] ([Id], [Name], [Length], [RegionId], [WalkDifficultyId]) VALUES (N'd2616470-2dba-4a89-82a4-9176ad559633', N'walksname2', 2, N'6e539bc5-e296-4cba-b056-5e83f6a695f9', N'23bcb536-6131-4da5-8bc8-70804cc0dc83')
INSERT [dbo].[Walks] ([Id], [Name], [Length], [RegionId], [WalkDifficultyId]) VALUES (N'b873e828-e611-4f3d-8ac5-9d51fb06e16f', N'testWalkCreation', 110, N'1ad7c230-13e0-464e-9d2e-13df4af4b648', N'2a830f16-205f-4041-91ed-2d4bacff6779')
INSERT [dbo].[Walks] ([Id], [Name], [Length], [RegionId], [WalkDifficultyId]) VALUES (N'2c69e7a6-9d23-4ee1-96f8-de7130354aee', N'walksname3', 3, N'b2b1aecd-8846-4e04-b1be-b5b28f345323', N'2997f574-63bb-4edd-bc14-d539c927614b')