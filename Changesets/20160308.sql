USE [persis]
GO

/****** Object:  Table [dbo].[td_material]    Script Date: 08.03.2016 19:45:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[td_material](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_td_material_id]  DEFAULT (newid()),
	[name] [nvarchar](max) NOT NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_td_material_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_td_material] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



/****** Object:  Table [dbo].[td_detail]    Script Date: 08.03.2016 19:46:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[td_detail](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_td_detail_id]  DEFAULT (newid()),
	[name] [nvarchar](max) NOT NULL,
	[is_deleted] [bit] NOT NULL CONSTRAINT [DF_td_detail_is_deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_td_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[td_detail]  WITH CHECK ADD  CONSTRAINT [FK_td_detail_detail_product] FOREIGN KEY([id])
REFERENCES [dbo].[td_detail] ([id])
GO

ALTER TABLE [dbo].[td_detail] CHECK CONSTRAINT [FK_td_detail_detail_product]
GO


/****** Object:  Table [dbo].[td_product]    Script Date: 08.03.2016 19:46:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[td_product](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_td_product_id]  DEFAULT (newid()),
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_td_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/****** Object:  Table [dbo].[t_material_operations]    Script Date: 08.03.2016 19:50:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_material_operations](
	[id] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_t_material_operations_id]  DEFAULT (newid()),
	[material_id] [uniqueidentifier] NOT NULL,
	[count] [numeric](18, 0) NOT NULL,
	[operation_date] [datetime] NOT NULL CONSTRAINT [t_material_date_add]  DEFAULT (getdate()),
 CONSTRAINT [PK_t_material_operations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[t_material_operations]  WITH CHECK ADD  CONSTRAINT [FK_t_material_operations_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[td_material] ([id])
GO

ALTER TABLE [dbo].[t_material_operations] CHECK CONSTRAINT [FK_t_material_operations_material]
GO





/****** Object:  Table [dbo].[t_material_detail]    Script Date: 08.03.2016 19:47:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_material_detail](
	[material_id] [uniqueidentifier] NOT NULL,
	[detail_id] [uniqueidentifier] NOT NULL,
	[material_count] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_t_material_detail] PRIMARY KEY CLUSTERED 
(
	[material_id] ASC,
	[detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[t_material_detail]  WITH CHECK ADD  CONSTRAINT [FK_t_material_detail_detail] FOREIGN KEY([detail_id])
REFERENCES [dbo].[td_detail] ([id])
GO

ALTER TABLE [dbo].[t_material_detail] CHECK CONSTRAINT [FK_t_material_detail_detail]
GO

ALTER TABLE [dbo].[t_material_detail]  WITH CHECK ADD  CONSTRAINT [FK_t_material_detail_material] FOREIGN KEY([material_id])
REFERENCES [dbo].[td_material] ([id])
GO

ALTER TABLE [dbo].[t_material_detail] CHECK CONSTRAINT [FK_t_material_detail_material]
GO


/****** Object:  Table [dbo].[t_detail_product]    Script Date: 08.03.2016 19:48:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_detail_product](
	[detail_id] [uniqueidentifier] NOT NULL,
	[product_id] [uniqueidentifier] NOT NULL,
	[detail_count] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_t_detail_product] PRIMARY KEY CLUSTERED 
(
	[detail_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[t_detail_product]  WITH CHECK ADD  CONSTRAINT [FK_t_detail_product_detail] FOREIGN KEY([detail_id])
REFERENCES [dbo].[td_detail] ([id])
GO

ALTER TABLE [dbo].[t_detail_product] CHECK CONSTRAINT [FK_t_detail_product_detail]
GO

ALTER TABLE [dbo].[t_detail_product]  WITH CHECK ADD  CONSTRAINT [FK_t_detail_product_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[td_product] ([id])
GO

ALTER TABLE [dbo].[t_detail_product] CHECK CONSTRAINT [FK_t_detail_product_product]
GO




/****** Object:  Index [IX_t_detail_product_detail]    Script Date: 08.03.2016 19:48:44 ******/
CREATE NONCLUSTERED INDEX [IX_t_detail_product_detail] ON [dbo].[t_detail_product]
(
	[detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


/****** Object:  Index [IX_t_detail_product_product]    Script Date: 08.03.2016 19:48:56 ******/
CREATE NONCLUSTERED INDEX [IX_t_detail_product_product] ON [dbo].[t_detail_product]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



/****** Object:  Index [IX_t_material_detail_detail]    Script Date: 08.03.2016 19:49:21 ******/
CREATE NONCLUSTERED INDEX [IX_t_material_detail_detail] ON [dbo].[t_material_detail]
(
	[detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


/****** Object:  Index [IX_t_material_detail_material]    Script Date: 08.03.2016 19:49:34 ******/
CREATE NONCLUSTERED INDEX [IX_t_material_detail_material] ON [dbo].[t_material_detail]
(
	[material_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


/****** Object:  Index [IDX_t_material_operations_material_is]    Script Date: 08.03.2016 19:51:00 ******/
CREATE NONCLUSTERED INDEX [IDX_t_material_operations_material_is] ON [dbo].[t_material_operations]
(
	[material_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

