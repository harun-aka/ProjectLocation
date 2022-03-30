SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[OpeningTime] [time](0) NOT NULL,
	[ClosingTime] [time](0) NOT NULL,
	[TimeZonesId] [int] NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 30.03.2022 12:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeZoneInfo]    Script Date: 30.03.2022 12:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeZoneInfo](
	[Id] [nvarchar](50) NOT NULL,
	[DiplayName] [nvarchar](50) NOT NULL,
	[StandardName] [nvarchar](50) NOT NULL,
	[baseUtcOffset] [time](0) NOT NULL,
	[SupportsDaylightSavingTime] [bit] NOT NULL,
 CONSTRAINT [PK_TimeZoneInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeZones]    Script Date: 30.03.2022 12:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeZones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TimeZoneInfoId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TimeZones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 30.03.2022 12:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OperationClaimId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30.03.2022 12:02:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PasswordHash] [varbinary](500) NOT NULL,
	[PasswordSalt] [varbinary](500) NOT NULL,
	[Status] [bit] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 
GO
INSERT [dbo].[Locations] ([Id], [Name], [Address], [OpeningTime], [ClosingTime], [TimeZonesId]) VALUES (1, N'string', N'string', CAST(N'09:00:58' AS Time), CAST(N'15:00:58' AS Time), 1)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Address], [OpeningTime], [ClosingTime], [TimeZonesId]) VALUES (2, N'string', N'string', CAST(N'08:53:21' AS Time), CAST(N'14:53:21' AS Time), 1)
GO
INSERT [dbo].[Locations] ([Id], [Name], [Address], [OpeningTime], [ClosingTime], [TimeZonesId]) VALUES (3, N'string', N'string', CAST(N'08:08:09' AS Time), CAST(N'08:08:09' AS Time), 1)
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (1, N'admin')
GO
INSERT [dbo].[OperationClaims] ([Id], [Name]) VALUES (2, N'user')
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
INSERT [dbo].[TimeZoneInfo] ([Id], [DiplayName], [StandardName], [baseUtcOffset], [SupportsDaylightSavingTime]) VALUES (N'Turkey Standard Time', N'(UTC+03:00) Istanbul', N'Turkey Standard Time', CAST(N'03:00:00' AS Time), 1)
GO
SET IDENTITY_INSERT [dbo].[TimeZones] ON 
GO
INSERT [dbo].[TimeZones] ([Id], [Name], [TimeZoneInfoId]) VALUES (1, N'(UTC+03:00)GMT +03:00', N'Turkey Standard Time')
GO
SET IDENTITY_INSERT [dbo].[TimeZones] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserOperationClaims] ([Id], [UserId], [OperationClaimId]) VALUES (2, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (1, N'Admin', N'User', N'admin.user@location.com', 0xC2120FB05161AA4834CF72E3986F3CD5144DF8D050C6413CE1398EAD4EDBA7A662A152247D4001E43ECFF189A375B0C5D9D2F50998001246B0D3722A52890E25, 0x831F37A2D5554F949ADE8802350A95AB138D973082263ACF695DD9DDD2E49DC2ED48D005958D0830BED48C91CBD6A94B65C5D2C10BE0C98F764195943EBC28A4CC6BCD1991C5B35BE9E0278E1B1F3B57C844951D57F925CD88ED870A1C038B7B6FA46F4ADFFFED32EBB683072914494BCF1FEBF727AF3C12E65CACCF6AA6F24C, 1)
GO
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [PasswordHash], [PasswordSalt], [Status]) VALUES (2, N'User', N'User', N'user.user@location.com', 0x84096134F5D77D428D754BE69C1F71CAE85A686C2968F4A637D79B806DFB68194A5B08DF1DA5E6F222D39AD86D664BF67A33DB8D3F6A2F214CB71F89EC942B42, 0x434A71BB53B010D0C98C833DB79D464971D4D41931412601B7C8397225F099118F78AAF90CFB6C8EE0AA05B5756CB932EBAC64BC34972AF2FCA3F7C7A3E55A7B5EE95F34A0ABB27D98B3E42913D34173A19EF3024184082C93A7127918CA095C6337424D12F30E9F0C4471D6735C7FDEA10D9479935F70332BD26ABCA4B828BB, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
