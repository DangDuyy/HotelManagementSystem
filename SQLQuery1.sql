CREATE TABLE [dbo].[timekeeping] (
    [Id]           INT            NOT NULL,
    [employee_id]  NCHAR (20)     NULL,
    [fname]        NCHAR (20)     NULL,
    [lname]        NCHAR (20)     NULL,
    [checkintime]  DATETIME       NULL,
    [checkouttime] DATETIME       NULL,
    [date]         DATE           NULL,
    [status]       NVARCHAR (150) NULL,
    [salary]       INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[report] (
    [Id]           INT  NOT NULL,
    [tongdoanhthu] INT  NULL,
    [booking]      INT  NULL,
    [booked]       INT  NULL,
    [service]      INT  NULL,
    [salary]       INT  NULL,
    [feeother]     INT  NULL,
    [doanhthurong] INT  NULL,
    [date]         DATE NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[std] (
    [Id]       NCHAR (10) NULL,
    [fname]    NCHAR (10) NULL,
    [lname]    NCHAR (10) NULL,
    [position] NCHAR (35) NULL,
    [gender]   NCHAR (10) NULL,
    [bdate]    DATETIME   NULL,
    [username] NCHAR (10) NOT NULL,
    [password] NCHAR (10) NULL,
    [phone]    NCHAR (10) NULL,
    [address]  NCHAR (20) NULL,
    [picture]  IMAGE      NULL,
    [email]    NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
);

CREATE TABLE [dbo].[BookRoom] (
    [bookingId]      NCHAR (50)     NOT NULL,
    [cus_Id]         NCHAR (50)     NULL,
    [room_Id]        NCHAR (50)     NULL,
    [roomtype]       NCHAR (50)     NULL,
    [bedtype]        NCHAR (50)     NULL,
    [checkindate]    DATE           NULL,
    [checkoutdate]   DATE           NULL,
    [selectedsevice] NVARCHAR (500) NULL,
    [promo]          NCHAR (100)    NULL,
    [total]          INT            NULL,
    [totalcus]       INT            NULL,
    [deposit]        INT            NULL,
    PRIMARY KEY CLUSTERED ([bookingId] ASC)
);

CREATE TABLE [dbo].[chia_ca] (
    [shift]     NVARCHAR (50) NULL,
    [monday]    NVARCHAR (50) NULL,
    [tuesday]   NVARCHAR (50) NULL,
    [wednesday] NVARCHAR (50) NULL,
    [thursday]  NVARCHAR (50) NULL,
    [friday]    NVARCHAR (50) NULL,
    [saturday]  NVARCHAR (50) NULL,
    [sunday]    NVARCHAR (50) NULL
);

CREATE TABLE [dbo].[chia_ca_ManagerRecept] (
    [shift]     NVARCHAR (50) NULL,
    [monday]    NVARCHAR (50) NULL,
    [tuesday]   NVARCHAR (50) NULL,
    [wednesday] NVARCHAR (50) NULL,
    [thursday]  NVARCHAR (50) NULL,
    [friday]    NVARCHAR (50) NULL,
    [saturday]  NVARCHAR (50) NULL,
    [sunday]    NVARCHAR (50) NULL
);

CREATE TABLE [dbo].[customer] (
    [Id]      INT        NOT NULL,
    [fname]   NCHAR (10) NULL,
    [lname]   NCHAR (10) NULL,
    [phone]   NCHAR (10) NULL,
    [address] NCHAR (20) NULL,
    [email]   NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[discount] (
    [discount_id]   INT        NOT NULL,
    [discount_name] NCHAR (30) NULL,
    [discount_des]  NCHAR (30) NULL,
    [rate]          INT        NULL,
    PRIMARY KEY CLUSTERED ([discount_id] ASC)
);

CREATE TABLE [dbo].[room] (
    [id]       INT        NOT NULL,
    [roomtype] NCHAR (30) NULL,
    [bebtype]  NCHAR (30) NULL,
    [price]    INT        NULL,
    [status]   INT        NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[sevice] (
    [Id]          INT        NOT NULL,
    [sevice_name] NCHAR (30) NULL,
    [des]         NCHAR (30) NULL,
    [cost]        INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
