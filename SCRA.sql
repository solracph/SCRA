USE [SCRA]
GO
/****** Object:  Schema [Security]    Script Date: 11/21/2018 10:27:51 AM ******/
CREATE SCHEMA [Security]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/21/2018 10:27:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Application]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Code] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contract]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ContractPBP]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractPBP](
	[ContractPBPId] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [int] NOT NULL,
	[PBPId] [int] NOT NULL,
 CONSTRAINT [PK_ContractPBP] PRIMARY KEY CLUSTERED 
(
	[ContractPBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Measure]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measure](
	[MeasureId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Measure] PRIMARY KEY CLUSTERED 
(
	[MeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PBP]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PBP](
	[PBPId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PBP] PRIMARY KEY CLUSTERED 
(
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rule]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rule](
	[RuleId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleApplication]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleApplication](
	[RuleApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_RuleApplication] PRIMARY KEY CLUSTERED 
(
	[RuleApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleContract]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleContract](
	[RuleContractId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[ContractId] [int] NOT NULL,
 CONSTRAINT [PK_RuleContract] PRIMARY KEY CLUSTERED 
(
	[RuleContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleMeasure]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleMeasure](
	[RuleMeasureId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[MeasureId] [int] NOT NULL,
 CONSTRAINT [PK_RuleMeasure] PRIMARY KEY CLUSTERED 
(
	[RuleMeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RulePBP]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RulePBP](
	[RulePBPId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[PBPId] [int] NOT NULL,
 CONSTRAINT [PK_RulePBP] PRIMARY KEY CLUSTERED 
(
	[RulePBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleSegment]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleSegment](
	[RuleSegmentId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[SegmentId] [int] NOT NULL,
 CONSTRAINT [PK_RuleSegment] PRIMARY KEY CLUSTERED 
(
	[RuleSegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RuleTIN]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RuleTIN](
	[RuleTINId] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NOT NULL,
	[TINId] [int] NOT NULL,
 CONSTRAINT [PK_RuleTIN] PRIMARY KEY CLUSTERED 
(
	[RuleTINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityClaim]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityClaim](
	[ClaimId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [varchar](8000) NULL,
	[ClaimValue] [varchar](8000) NULL,
 CONSTRAINT [PK_dbo.SecurityClaim] PRIMARY KEY CLUSTERED 
(
	[ClaimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityExternalLogin]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityExternalLogin](
	[LoginProvider] [varchar](128) NOT NULL,
	[ProviderKey] [varchar](128) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.SecurityExternalLogin] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRole]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRole](
	[RoleId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.SecurityRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityUser]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityUser](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varchar](8000) NULL,
	[SecurityStamp] [varchar](8000) NULL,
 CONSTRAINT [PK_dbo.SecurityUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityUserRole]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityUserRole](
	[RoleId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.SecurityUserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Segment]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Segment](
	[SegmentId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Segment] PRIMARY KEY CLUSTERED 
(
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIN]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIN](
	[TINId] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TIN] PRIMARY KEY CLUSTERED 
(
	[TINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserApplication]    Script Date: 11/21/2018 10:27:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserApplication](
	[UserApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ApplicationId] [int] NOT NULL,
 CONSTRAINT [PK_UserApplication] PRIMARY KEY CLUSTERED 
(
	[UserApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRule]    Script Date: 11/21/2018 10:27:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRule](
	[UserRuleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RuleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRule] PRIMARY KEY CLUSTERED 
(
	[UserRuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201811131533125_InitialCreate', N'HCN.Nightfort.Data.Security.Models.SecurityDbContext', 0x1F8B0800000000000400DD5BDB6EDC36107D2FD07F10F418B8D6DA418BD4D84D90AEEDC4687C81D709FA16D012774D94A21491727751F4CBFAD04FEA2F94D45DBCE8BAEB5D14797148CE70383C331CCDCCFEFBF73FD3776B1F5BCF30A2282033FBE478625B90B88187C86A66C76CF9C31BFBDDDBEFBF9B5E78FEDAFA92AF7B2DD6714A4267F61363E199E350F709FA801EFBC88D021A2CD9B11BF80EF002E77432F9D9393971206761735E9635BD8F09433E4CFEC3FF3B0F880B4316037C1D7810D36C9CCF2C12AED60DF0210D810B67F6C7F9CDF10D5A3DB16510B1E373C0C0F102BA7184D8E638A5B6ADF718012ED902E2A56D014202061897FBEC33850B160564B508F900C00F9B10F2754B8029CCCE73562EEF7AB4C9A9389A5312E6ACDC98B2C0EFC9F0E475A62B47261FA471BBD025D7E605D73ADB8853271A9DD9730C906F5BF24E67731C89558AB6F922444A7D27E447966ED15101168E29F1EFC89AC798C5119C1118B308E023EB2E7EC4C8FD156E1E82DF21999118E3AAB85C603E571BE043775110C2886DEEE1B27A882BCFB69C3AB1235317B432617AD62BC25E9FDAD60D17033C6258E0A2A297050B22F80112180106BD3BC0188CF8B55E7930D1AC2282B421C75F54EEF721469E66BB661689CC823EE7C201CD6DD5B6AEC1FA13242BF634B3F99FB67589D6D0CB4732D69F09E2A6CD89581477DBE90BC0F10EB6BA01CF6895A854A321DBBA873899A44F284CCD3885DAD774FA320AFCFB00E73226A35F17411CB942D440997A00D10AB2BA1053A73486461349B71C6A21827AEF0692C3AEAF7D6C01AE8285F8AB01422793492708F5DCF9822B19BFFCB67780D23F82C8FB08E8D3CE4D3487D982013F7C412B4D6C8B0EB3D3DC1835769A9B7057313E052B44F4625CAC8567063859A288A3CE2A626996F4154F30D24B2766129EB42A5539AA485399D249D1D999D54E35DCABD5D8ECDDBD2552F0E167E4896B76DA29F2C59C7DA7F5431DA82499D9179DBED9892FAA1EF3A5371FF278F40F0B7ADBB91C2634B882411626B80E372C41BD777B12420C417B4E37225C6809154E7FFC692B506DC4D940972D034BE3CDBB00EA3DA5818B92DD753E3B8578FD3417C4B3DAF19EEA54B119AE5F0E231472E0706966F62B45598DEC8B87AA649F1A619DEB892DC3EE969C430C19B4DEBBE9A7F11C501778EA5D713D79F5118E5418890F2E80E7FC8E38F611612AAC1171510870ABEC12658F07404857EC23CF9CC31012F15DD87A37E30428F691D4D6A6A5A953815A33022BD83741436708252452A7D81D68BA48A81960AF64EBEA7CB84AC06A1247F795598A93E550BA9F4E170C1FBAF9A832BF90D9A8BA3F307349DD38A7619C0246D297D9F9A398816BA68909B890595840B3874B468CE0BC804CFAEA2A1F8E3A0215C0D5C9B3C74BA14E01D7429C7F6A29D4D263D2C226FB2452B8A40E4222AE28BCE4A00BF82A0BCD61A18C844EAF66217FA90105529DDEC70AA3EC1E643BAD9FB68326AA1189AA0193CF6EF3DA1541B3CB6A38B0C64FEFE0A0D594827A5093FF6EF3E0154173C36A38A9C6678F38691EFC155EA32C783869C523AF8C3886D2C8F41A84210F8F2BA5926CC45AA47592F90F8BFE05033FE5E1B854533728A42D7662410456509AE55B73492F514499A8CE3C021180CF3D5F59A6FA4883F3C8F7ABB941F5AE729F922F177FA724ED35A3CC87AA6F4BC6EC921FD417AF52520190B1A3D225A52B8041642A39CC031CFBA4B180D1C4277FE0AA6C4C8F5E8B3469314191271DEEC92B2B1728CCB27195DBD49114AC3CD8CABD2AF14D1D259D3064728CA320A4F3411D10A427DBEDC5976979994F3ADA9D539666AFB2C986BAF3A8E7CCABACEA33DD394A89F12A4B69EA602099C5175BC6643D3CEB0FCE167A93FEA5C46755FF2DD9DA069454B3993590346573CDFCFA59D29E5091C6605B0645126DF7C7829ECCA4DE3C1B5855AF3EB3D8C44575522607B5EB0BAA0773EA2DE5A178EF9BC80975EA3685B51A5DD7E378553DA32F294925E4F4BD6432660C46DBA5592639FA56EF5409C2E52505A28A605C0ABAA75900DCDEB4A444C4E912DBCA7D177F973694413F83C9373CC78863B85C700D085A42CAD2D4BE7D3A393995FA9C0EA7E7C8A1D4C39A0F08A5F1684071625BCD3E4828B7B59D6754CD2B26E85B0C51C26C89B45D2457C483EB99FD67427F665DFDF635657164DD46FCD2CFAC89F5D7F816A16710B94F20525B024AC6C31A820631EED779330022DB6977516F6F64EB8B4E594913CA98C6966D31D5B5AD6C0936DA2695DD22A7216AFD5FB614685120CAFAE31B06B6C57A1FAEB15FD17E004CB653291FED69DABC4C5236DF9EA686FA656360B93DEB68536C0794A52C463DC08784F551FD0469CEFD258B938662CA98FE8541F54E432E6FF79D018756DE6CEA06D07E6C4AE5A1D63E801DC1A77054F2FE1DBA078682C69057E9E109BB83C6941DE8B9DFCBE2459708381077B30FBCBCA493E98597BDFA970E0D39FB044AD66CD1BF01E8E021622A811E607B8D5A613664D3EBBF733375CEA4D9B899ED3D06FC66D3182BFF6CEDDE5C63ECAD6962DFA9FB468A78DA9A709AF6EBDFAF636CD769DA46DBD0A3E36E505C39D5A6BCBDB60E55A52F8BB99D7B846AA4CD3733A63FA8E879696A1332540E94704E2E08B5F507292A2A07B779C4BC2BA7F188FA42C4A8FBDCF511B7D0FCD4FF503577596973D94987935A44E1CF45E5F7E1FC9DA26855B210BF1627D0AD3D14C59A2BB20CF2F74A92285F227DAC5F43063CFE8ABC8FF8E73970199F7621A5C94F0F9264B7C8B83E42EF8ADCC62C8C193F32F41F712DCB27DEBDA6FD9336AEBACCD3DB30F985C1368EC0C544FC08F096FC1223EC15725F6AD2040616E241CD0A21E22E992888AC3605A79B80746494A9AF88031EA01F62CE8CDE920578864364E370FD0457C0DD94694F1393F68BA8AB7D7A8EC02A023ECD7894F4FCBF1CC39EBF7EFB1FBD672EC126410000, N'6.1.3-40302')
GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (1, N'Application-1', N'App1')
GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (2, N'Application-2', N'App2')
GO
INSERT [dbo].[Application] ([ApplicationId], [Description], [Code]) VALUES (3, N'Application-3', N'App3')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (1, N'H1045')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (2, N'H2228')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (3, N'H2406')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (4, N'R5420')
GO
INSERT [dbo].[Contract] ([ContractId], [Description]) VALUES (5, N'R7444')
GO
SET IDENTITY_INSERT [dbo].[ContractPBP] ON 

GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (4, 1, 4)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (5, 1, 5)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (6, 1, 6)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (7, 1, 7)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (8, 2, 8)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (9, 2, 9)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (10, 2, 10)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (11, 2, 11)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (12, 2, 12)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (13, 2, 13)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (14, 2, 14)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (15, 2, 15)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (16, 2, 16)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (17, 2, 17)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (18, 3, 18)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (19, 3, 19)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (20, 3, 20)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (21, 3, 21)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (22, 3, 22)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (23, 3, 23)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (24, 4, 24)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (25, 4, 25)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (26, 4, 26)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (27, 4, 27)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (28, 4, 28)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (29, 4, 29)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (30, 4, 30)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (31, 5, 31)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (32, 5, 32)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (33, 5, 33)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (34, 5, 34)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (35, 5, 35)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (36, 5, 36)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (37, 5, 37)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (38, 5, 38)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (39, 5, 39)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (40, 5, 40)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (41, 5, 41)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (42, 5, 42)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (43, 5, 43)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (44, 5, 44)
GO
INSERT [dbo].[ContractPBP] ([ContractPBPId], [ContractId], [PBPId]) VALUES (45, 5, 45)
GO
SET IDENTITY_INSERT [dbo].[ContractPBP] OFF
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (1, N'MA')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (2, N'MRP')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (3, N'ART')
GO
INSERT [dbo].[Measure] ([MeasureId], [Description]) VALUES (4, N'OMW')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (1, N'001')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (2, N'002')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (3, N'003')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (4, N'004')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (5, N'005')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (6, N'006')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (7, N'007')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (8, N'008')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (9, N'009')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (10, N'010')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (11, N'011')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (12, N'012')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (13, N'013')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (14, N'014')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (15, N'015')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (16, N'016')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (17, N'017')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (18, N'018')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (19, N'019')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (20, N'020')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (21, N'021')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (22, N'022')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (23, N'023')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (24, N'024')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (25, N'025')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (26, N'026')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (27, N'027')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (28, N'028')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (29, N'029')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (30, N'030')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (31, N'031')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (32, N'032')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (33, N'033')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (34, N'034')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (35, N'035')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (36, N'036')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (37, N'037')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (38, N'038')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (39, N'039')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (40, N'040')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (41, N'041')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (42, N'042')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (43, N'043')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (44, N'044')
GO
INSERT [dbo].[PBP] ([PBPId], [Description]) VALUES (45, N'045')
GO
SET IDENTITY_INSERT [dbo].[Rule] ON 

GO
INSERT [dbo].[Rule] ([RuleId], [Code], [Description]) VALUES (19, N'R1', N'This is a test Rule 3 - App 1')
GO
INSERT [dbo].[Rule] ([RuleId], [Code], [Description]) VALUES (20, N'R1', N'This is a test Rule 4 - App 1,2,3')
GO
INSERT [dbo].[Rule] ([RuleId], [Code], [Description]) VALUES (34, N'R1', N'This is a test Rule 5 - App 1')
GO
SET IDENTITY_INSERT [dbo].[Rule] OFF
GO
SET IDENTITY_INSERT [dbo].[RuleApplication] ON 

GO
INSERT [dbo].[RuleApplication] ([RuleApplicationId], [RuleId], [ApplicationId]) VALUES (60, 19, 1)
GO
INSERT [dbo].[RuleApplication] ([RuleApplicationId], [RuleId], [ApplicationId]) VALUES (22, 20, 1)
GO
INSERT [dbo].[RuleApplication] ([RuleApplicationId], [RuleId], [ApplicationId]) VALUES (23, 20, 2)
GO
INSERT [dbo].[RuleApplication] ([RuleApplicationId], [RuleId], [ApplicationId]) VALUES (24, 20, 3)
GO
INSERT [dbo].[RuleApplication] ([RuleApplicationId], [RuleId], [ApplicationId]) VALUES (58, 34, 1)
GO
SET IDENTITY_INSERT [dbo].[RuleApplication] OFF
GO
SET IDENTITY_INSERT [dbo].[RuleContract] ON 

GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (126, 19, 2)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (66, 20, 1)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (67, 20, 2)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (68, 20, 3)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (69, 20, 4)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (70, 20, 5)
GO
INSERT [dbo].[RuleContract] ([RuleContractId], [RuleId], [ContractId]) VALUES (128, 34, 2)
GO
SET IDENTITY_INSERT [dbo].[RuleContract] OFF
GO
SET IDENTITY_INSERT [dbo].[RuleMeasure] ON 

GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (86, 19, 2)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (30, 19, 3)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (31, 19, 4)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (32, 20, 1)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (33, 20, 2)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (34, 20, 3)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (35, 20, 4)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (82, 34, 3)
GO
INSERT [dbo].[RuleMeasure] ([RuleMeasureId], [RuleId], [MeasureId]) VALUES (83, 34, 4)
GO
SET IDENTITY_INSERT [dbo].[RuleMeasure] OFF
GO
SET IDENTITY_INSERT [dbo].[RulePBP] ON 

GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (855, 19, 15)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (856, 19, 16)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (857, 19, 17)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (308, 20, 1)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (309, 20, 2)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (310, 20, 3)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (311, 20, 4)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (312, 20, 5)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (313, 20, 6)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (314, 20, 7)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (315, 20, 8)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (316, 20, 9)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (317, 20, 10)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (318, 20, 11)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (319, 20, 12)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (320, 20, 13)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (321, 20, 14)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (322, 20, 15)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (323, 20, 16)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (324, 20, 17)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (325, 20, 18)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (326, 20, 19)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (327, 20, 20)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (328, 20, 21)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (329, 20, 22)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (330, 20, 23)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (331, 20, 24)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (332, 20, 25)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (333, 20, 26)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (334, 20, 27)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (335, 20, 28)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (336, 20, 29)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (337, 20, 30)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (338, 20, 31)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (339, 20, 32)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (340, 20, 33)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (341, 20, 34)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (342, 20, 35)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (343, 20, 36)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (344, 20, 37)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (345, 20, 38)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (346, 20, 39)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (347, 20, 40)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (348, 20, 41)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (349, 20, 42)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (350, 20, 43)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (351, 20, 44)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (352, 20, 45)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (861, 34, 15)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (862, 34, 16)
GO
INSERT [dbo].[RulePBP] ([RulePBPId], [RuleId], [PBPId]) VALUES (863, 34, 17)
GO
SET IDENTITY_INSERT [dbo].[RulePBP] OFF
GO
SET IDENTITY_INSERT [dbo].[RuleSegment] ON 

GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (65, 19, 1)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (66, 19, 3)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (68, 20, 1)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (69, 20, 2)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (70, 20, 3)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (71, 20, 4)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (72, 20, 5)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (73, 20, 6)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (74, 20, 7)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (75, 20, 8)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (76, 20, 9)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (178, 34, 1)
GO
INSERT [dbo].[RuleSegment] ([RuleSegmentId], [RuleId], [SegmentId]) VALUES (179, 34, 3)
GO
SET IDENTITY_INSERT [dbo].[RuleSegment] OFF
GO
SET IDENTITY_INSERT [dbo].[RuleTIN] ON 

GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (51, 19, 3)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (52, 20, 1)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (53, 20, 2)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (54, 20, 3)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (55, 20, 4)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (56, 20, 5)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (57, 20, 6)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (58, 20, 7)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (59, 20, 8)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (60, 20, 9)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (61, 20, 10)
GO
INSERT [dbo].[RuleTIN] ([RuleTINId], [RuleId], [TINId]) VALUES (173, 34, 3)
GO
SET IDENTITY_INSERT [dbo].[RuleTIN] OFF
GO
INSERT [dbo].[SecurityUser] ([UserId], [UserName], [Email], [PasswordHash], [SecurityStamp]) VALUES (N'7ee5adcd-f9df-41f4-b657-75282d36fc72', N'ceperez', N'solracphcu@gmail.com', N'AEV6WvKqxzleWikthQjq/wGoEwRYcXWkRCQDWK3Ekj2CZffLne4SJzah0e+X7WmHYQ==', N'22fd07dd-5977-4228-acc4-aa9ea34d135f')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (1, N'ACO')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (2, N'DNSP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (3, N'FL-N')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (4, N'FL-S')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (5, N'FL-S DSNP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (6, N'FL-S WELLMED')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (7, N'GROUP')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (8, N'TVH')
GO
INSERT [dbo].[Segment] ([SegmentId], [Description]) VALUES (9, N'WELLMED')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (1, N'152454')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (2, N'548444')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (3, N'456845')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (4, N'456344')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (5, N'654745')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (6, N'654647')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (7, N'656134')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (8, N'987538')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (9, N'553845')
GO
INSERT [dbo].[TIN] ([TINId], [Description]) VALUES (10, N'77897')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (1, N'Ana Paula')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (2, N'Juan Perez')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (3, N'Alejandro Fernandez')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (4, N'Alexa Cruz')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (5, N'Dan Duffield')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (6, N'Alysia Adger')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (7, N'Cathern Crew')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (8, N'Joseph Jeanbaptiste')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (9, N'Mandie Mciver')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (10, N'Deetta Donato')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (11, N'Carmela Capasso')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (12, N'Laine Lunt')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (13, N'Latonya Lawerence')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (14, N'Jon Corrie')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (15, N'Peter Pittmon')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (16, N'Ken Kneeland')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (17, N'Eleanora Egerton')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (18, N'Shelley Sheffey')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (19, N'Catina Cattaneo')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (20, N'Tasia Tarkington')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (21, N'Wally Wieczorek')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (22, N'Jule Joye')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (23, N'Enoch Espitia')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (24, N'Kenyetta Kayser')
GO
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (25, N'Doyle Dennis')
GO
SET IDENTITY_INSERT [dbo].[UserApplication] ON 

GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (48, 1, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (58, 1, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (49, 2, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (59, 2, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (50, 3, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (60, 3, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (51, 4, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (52, 5, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (53, 6, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (54, 7, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (55, 8, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (56, 9, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (57, 10, 1)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (61, 10, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (62, 11, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (63, 12, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (64, 13, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (65, 14, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (66, 15, 2)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (67, 16, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (68, 17, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (69, 18, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (70, 19, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (71, 20, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (72, 21, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (73, 22, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (74, 23, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (75, 24, 3)
GO
INSERT [dbo].[UserApplication] ([UserApplicationId], [UserId], [ApplicationId]) VALUES (76, 25, 3)
GO
SET IDENTITY_INSERT [dbo].[UserApplication] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRule] ON 

GO
INSERT [dbo].[UserRule] ([UserRuleId], [UserId], [RuleId]) VALUES (302, 1, 19)
GO
INSERT [dbo].[UserRule] ([UserRuleId], [UserId], [RuleId]) VALUES (303, 1, 20)
GO
INSERT [dbo].[UserRule] ([UserRuleId], [UserId], [RuleId]) VALUES (304, 1, 34)
GO
SET IDENTITY_INSERT [dbo].[UserRule] OFF
GO
/****** Object:  Index [IX_ContractPBP]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[ContractPBP] ADD  CONSTRAINT [IX_ContractPBP] UNIQUE NONCLUSTERED 
(
	[ContractId] ASC,
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleApplication]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RuleApplication] ADD  CONSTRAINT [IX_RuleApplication] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleContract]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RuleContract] ADD  CONSTRAINT [IX_RuleContract] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleMeasure]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RuleMeasure] ADD  CONSTRAINT [IX_RuleMeasure] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[MeasureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RulePBP]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RulePBP] ADD  CONSTRAINT [IX_RulePBP] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[PBPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleSegment]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RuleSegment] ADD  CONSTRAINT [IX_RuleSegment] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[SegmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RuleTIN]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[RuleTIN] ADD  CONSTRAINT [IX_RuleTIN] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[TINId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserApplication]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[UserApplication] ADD  CONSTRAINT [IX_UserApplication] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRule]    Script Date: 11/21/2018 10:27:53 AM ******/
ALTER TABLE [dbo].[UserRule] ADD  CONSTRAINT [IX_UserRule] UNIQUE NONCLUSTERED 
(
	[RuleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContractPBP]  WITH CHECK ADD  CONSTRAINT [FK_ContractPBP_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[ContractPBP] CHECK CONSTRAINT [FK_ContractPBP_Contract]
GO
ALTER TABLE [dbo].[ContractPBP]  WITH CHECK ADD  CONSTRAINT [FK_ContractPBP_PBP] FOREIGN KEY([PBPId])
REFERENCES [dbo].[PBP] ([PBPId])
GO
ALTER TABLE [dbo].[ContractPBP] CHECK CONSTRAINT [FK_ContractPBP_PBP]
GO
ALTER TABLE [dbo].[RuleApplication]  WITH CHECK ADD  CONSTRAINT [FK_RuleApplication_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
ALTER TABLE [dbo].[RuleApplication] CHECK CONSTRAINT [FK_RuleApplication_Application]
GO
ALTER TABLE [dbo].[RuleApplication]  WITH CHECK ADD  CONSTRAINT [FK_RuleApplication_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleApplication] CHECK CONSTRAINT [FK_RuleApplication_Rule]
GO
ALTER TABLE [dbo].[RuleContract]  WITH CHECK ADD  CONSTRAINT [FK_RuleContract_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[RuleContract] CHECK CONSTRAINT [FK_RuleContract_Contract]
GO
ALTER TABLE [dbo].[RuleContract]  WITH CHECK ADD  CONSTRAINT [FK_RuleContract_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleContract] CHECK CONSTRAINT [FK_RuleContract_Rule]
GO
ALTER TABLE [dbo].[RuleMeasure]  WITH CHECK ADD  CONSTRAINT [FK_RuleMeasure_Measure] FOREIGN KEY([MeasureId])
REFERENCES [dbo].[Measure] ([MeasureId])
GO
ALTER TABLE [dbo].[RuleMeasure] CHECK CONSTRAINT [FK_RuleMeasure_Measure]
GO
ALTER TABLE [dbo].[RuleMeasure]  WITH CHECK ADD  CONSTRAINT [FK_RuleMeasure_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleMeasure] CHECK CONSTRAINT [FK_RuleMeasure_Rule]
GO
ALTER TABLE [dbo].[RulePBP]  WITH CHECK ADD  CONSTRAINT [FK_RulePBP_PBP] FOREIGN KEY([PBPId])
REFERENCES [dbo].[PBP] ([PBPId])
GO
ALTER TABLE [dbo].[RulePBP] CHECK CONSTRAINT [FK_RulePBP_PBP]
GO
ALTER TABLE [dbo].[RulePBP]  WITH CHECK ADD  CONSTRAINT [FK_RulePBP_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RulePBP] CHECK CONSTRAINT [FK_RulePBP_Rule]
GO
ALTER TABLE [dbo].[RuleSegment]  WITH CHECK ADD  CONSTRAINT [FK_RuleSegment_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleSegment] CHECK CONSTRAINT [FK_RuleSegment_Rule]
GO
ALTER TABLE [dbo].[RuleSegment]  WITH CHECK ADD  CONSTRAINT [FK_RuleSegment_Segment] FOREIGN KEY([SegmentId])
REFERENCES [dbo].[Segment] ([SegmentId])
GO
ALTER TABLE [dbo].[RuleSegment] CHECK CONSTRAINT [FK_RuleSegment_Segment]
GO
ALTER TABLE [dbo].[RuleTIN]  WITH CHECK ADD  CONSTRAINT [FK_RuleTIN_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[RuleTIN] CHECK CONSTRAINT [FK_RuleTIN_Rule]
GO
ALTER TABLE [dbo].[RuleTIN]  WITH CHECK ADD  CONSTRAINT [FK_RuleTIN_TIN] FOREIGN KEY([TINId])
REFERENCES [dbo].[TIN] ([TINId])
GO
ALTER TABLE [dbo].[RuleTIN] CHECK CONSTRAINT [FK_RuleTIN_TIN]
GO
ALTER TABLE [dbo].[SecurityClaim]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityClaim_dbo.SecurityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SecurityClaim] CHECK CONSTRAINT [FK_dbo.SecurityClaim_dbo.SecurityUser_UserId]
GO
ALTER TABLE [dbo].[SecurityExternalLogin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityExternalLogin_dbo.SecurityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SecurityExternalLogin] CHECK CONSTRAINT [FK_dbo.SecurityExternalLogin_dbo.SecurityUser_UserId]
GO
ALTER TABLE [dbo].[SecurityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityUserRole_dbo.SecurityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[SecurityRole] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SecurityUserRole] CHECK CONSTRAINT [FK_dbo.SecurityUserRole_dbo.SecurityRole_RoleId]
GO
ALTER TABLE [dbo].[SecurityUserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SecurityUserRole_dbo.SecurityUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUser] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SecurityUserRole] CHECK CONSTRAINT [FK_dbo.SecurityUserRole_dbo.SecurityUser_UserId]
GO
ALTER TABLE [dbo].[UserApplication]  WITH CHECK ADD  CONSTRAINT [FK_UserApplication_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
ALTER TABLE [dbo].[UserApplication] CHECK CONSTRAINT [FK_UserApplication_Application]
GO
ALTER TABLE [dbo].[UserApplication]  WITH CHECK ADD  CONSTRAINT [FK_UserApplication_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserApplication] CHECK CONSTRAINT [FK_UserApplication_User]
GO
ALTER TABLE [dbo].[UserRule]  WITH CHECK ADD  CONSTRAINT [FK_UserRule_Rule] FOREIGN KEY([RuleId])
REFERENCES [dbo].[Rule] ([RuleId])
GO
ALTER TABLE [dbo].[UserRule] CHECK CONSTRAINT [FK_UserRule_Rule]
GO
ALTER TABLE [dbo].[UserRule]  WITH CHECK ADD  CONSTRAINT [FK_UserRule_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRule] CHECK CONSTRAINT [FK_UserRule_User]
GO
