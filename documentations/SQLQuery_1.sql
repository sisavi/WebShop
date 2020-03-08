CREATE DATABASE "sisavi_softupdate_delete"

use "sisavi_softupdate_delete"
drop table Product;

CREATE TABLE Basket(
    BasketId INT not null ,
    DelAt DATETIME2 ,
    CreatedAt DATETIME2 NOT NULL,
    BasketName VARCHAR(50) NOT NULL,
    PRIMARY KEY (BasketId, DelAt)

);

CREATE TABLE Product(
    ProductId INT not null ,
    DelAt DATETIME2 ,
    CreatedAt DATETIME2 NOT NULL DEFAULT Current_timestamp,
    ProductName VARCHAR(50) NOT NULL,
    ProductDescription VARCHAR(128),
    ProductCode VARCHAR(64) NOT NULL,
    PRIMARY KEY (ProductId, DelAt)
);

CREATE TABLE ProductInBasket(
    ProductInBasketId int not NULL,
    BasketId int NOT NULL,
    BasketDelAt DATETIME2,
    ProductId int Not null,
    ProductDelAt DATETIME2,
    Quantity int not NULL,
    DelAt DATETIME2 NOT NULL ,
    AddedAt DATETIME2 NOT NULL,
    CONSTRAINT FK_Basket FOREIGN KEY (BasketId, BasketDelAt) REFERENCES Basket(BasketId, DelAt),
    FOREIGN KEY (ProductId, ProductDelAt) REFERENCES Product(ProductId, DelAt),
    PRIMARY KEY (ProductInBasketId, DelAt)

);


INSERT into Product(DelAt, ProductName, ProductDescription, ProductCode) VALUES ('3000-01-01', 'Voodi', 'Puit voodi vahatatud vineerist', 'VV0001' );


SELECT * from Product;
