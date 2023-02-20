CREATE TABLE [dbo].[MenuTable] (
    [FoodName] VARCHAR (50) NOT NULL,
    [Category] VARCHAR (50) NULL,
    [Price]    REAL         NULL,
    PRIMARY KEY CLUSTERED ([FoodName] ASC)
);

CREATE TABLE [dbo].[SalesHistoryTable] (
    [Day]   INT  NOT NULL,
    [Sales] REAL NOT NULL,
    [Tips]  REAL NOT NULL,
    PRIMARY KEY CLUSTERED ([Day] ASC)
);

CREATE TABLE [dbo].[SalesPerDayTable] (
    [CustomerName]    VARCHAR (50) NOT NULL,
    [TotalBeforeTips] REAL         NOT NULL,
    [Tips]            REAL         NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerName] ASC)
);

CREATE TABLE [dbo].[TableFive] (
    [Table Number] INT           NOT NULL,
    [FoodName]     VARCHAR (50)  NOT NULL,
    [Price]        REAL          NOT NULL,
    [Detail]       VARCHAR (100) NULL
);

CREATE TABLE [dbo].[TableFour] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL
);

CREATE TABLE [dbo].[TableOne] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([TableNumber] ASC)
);

CREATE TABLE [dbo].[TableSeven] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL
);

CREATE TABLE [dbo].[TableSix] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL
);

CREATE TABLE [dbo].[TableThree] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL
);

CREATE TABLE [dbo].[TableTwo] (
    [TableNumber] INT           NOT NULL,
    [FoodName]    VARCHAR (50)  NOT NULL,
    [Price]       REAL          NOT NULL,
    [Detail]      VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([TableNumber] ASC)
);

CREATE TABLE [dbo].[WaiterTable] (
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC)
);

INSERT INTO WaiterTable 
VALUES ('ChiuChaoHao', 'BirdFish7686');
INSERT INTO WaiterTable
VALUES ('MagdaAlex', 'CatDog8582');
INSERT INTO WaiterTable
VALUES ('MayugaDennis', 'MonkMode8387');

INSERT INTO MenuTable
VALUES ('Bacon Burger', 'Burgers', '12.99');
INSERT INTO MenuTable
VALUES ('Cheese Burger', 'Burgers', '10.99');
INSERT INTO MenuTable
VALUES ('Classic Fries', 'Sides', '4.99');
INSERT INTO MenuTable
VALUES ('Diet Soda', 'Drinks', '3.99');
INSERT INTO MenuTable
VALUES ('Large Fries', 'Sides', '6.99');
INSERT INTO MenuTable
VALUES ('Poutine', 'Sides', '6.99');
INSERT INTO MenuTable
VALUES ('Regular Soda', 'Drinks', '3.99');
INSERT INTO MenuTable
VALUES ('Salad', 'Sides', '5.99');
INSERT INTO MenuTable
VALUES ('Vegan Burger', 'Burgers', '13.99');
INSERT INTO MenuTable
VALUES ('Water', 'Drinks', '3.99');