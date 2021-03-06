USE [RentalPortalOrder]
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([EquipmentId], [Name], [StockCount], [EquipmentType], [DateCreated]) VALUES (1, N'Caterpillar bulldozer', 5, 0, CAST(N'2019-11-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [StockCount], [EquipmentType], [DateCreated]) VALUES (3, N'KamAZ truck', 3, 1, CAST(N'2019-11-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [StockCount], [EquipmentType], [DateCreated]) VALUES (4, N'Komatsu crane', 10, 0, CAST(N'2019-11-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [StockCount], [EquipmentType], [DateCreated]) VALUES (5, N'Volvo steamroller', 2, 1, CAST(N'2019-11-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Equipment] ([EquipmentId], [Name], [StockCount], [EquipmentType], [DateCreated]) VALUES (6, N'Bosch jackhammer', 1, 2, CAST(N'2019-11-04T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Equipment] OFF
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([SettingId], [Name], [Value]) VALUES (1, N'oneTimeRentalFee', N'100')
INSERT [dbo].[Settings] ([SettingId], [Name], [Value]) VALUES (2, N'premiumDailyFee', N'60')
INSERT [dbo].[Settings] ([SettingId], [Name], [Value]) VALUES (3, N'regularDailyFee', N'40')
SET IDENTITY_INSERT [dbo].[Settings] OFF
