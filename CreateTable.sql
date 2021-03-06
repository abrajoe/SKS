USE [SKS]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [bigint] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](max) NOT NULL,
	[Lastname] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementTyp]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementTyp](
	[MeasurementTypID] [int] IDENTITY(1,1) NOT NULL,
	[Minimum] [bigint] NOT NULL,
	[Maximum] [bigint] NOT NULL,
	[Unit] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MesswertTyp] PRIMARY KEY CLUSTERED 
(
	[MeasurementTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurement]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurement](
	[MeasurementID] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [float] NOT NULL,
	[Time] [datetime] NOT NULL,
	[SiteID] [bigint] NOT NULL,
	[MeasurementTypID] [int] NOT NULL,
 CONSTRAINT [PK_Messwert] PRIMARY KEY CLUSTERED 
(
	[MeasurementID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] IDENTITY(1,1) NOT NULL,
	[TechnicianID] [bigint] NOT NULL,
	[PersonID] [bigint] NOT NULL,
 CONSTRAINT [PK_Kunde] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technician]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technician](
	[TechnicianID] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonID] [bigint] NOT NULL,
 CONSTRAINT [PK_Techniker] PRIMARY KEY CLUSTERED 
(
	[TechnicianID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 10/18/2012 13:47:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[Serialnumber] [nvarchar](max) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[SiteID] [bigint] NOT NULL,
 CONSTRAINT [PK_Anlage] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Kunde_Person]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Kunde_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Kunde_Person]
GO
/****** Object:  ForeignKey [FK_Kunde_Techniker]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Kunde_Techniker] FOREIGN KEY([TechnicianID])
REFERENCES [dbo].[Technician] ([TechnicianID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Kunde_Techniker]
GO
/****** Object:  ForeignKey [FK_Messwert_Anlage]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Measurement]  WITH CHECK ADD  CONSTRAINT [FK_Messwert_Anlage] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Site] ([SiteID])
GO
ALTER TABLE [dbo].[Measurement] CHECK CONSTRAINT [FK_Messwert_Anlage]
GO
/****** Object:  ForeignKey [FK_Messwert_MesswertTyp]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Measurement]  WITH CHECK ADD  CONSTRAINT [FK_Messwert_MesswertTyp] FOREIGN KEY([MeasurementTypID])
REFERENCES [dbo].[MeasurementTyp] ([MeasurementTypID])
GO
ALTER TABLE [dbo].[Measurement] CHECK CONSTRAINT [FK_Messwert_MesswertTyp]
GO
/****** Object:  ForeignKey [FK_Anlage_Kunde]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Site]  WITH CHECK ADD  CONSTRAINT [FK_Anlage_Kunde] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Site] CHECK CONSTRAINT [FK_Anlage_Kunde]
GO
/****** Object:  ForeignKey [FK_Techniker_Person]    Script Date: 10/18/2012 13:47:44 ******/
ALTER TABLE [dbo].[Technician]  WITH CHECK ADD  CONSTRAINT [FK_Techniker_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[Technician] CHECK CONSTRAINT [FK_Techniker_Person]
GO
