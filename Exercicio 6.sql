CREATE DATABASE Exercicio6;

CREATE TABLE Categoria (
CodigoCategoria INT IDENTITY(1,1) PRIMARY KEY,
Nome NVARCHAR(225) NOT NULL
);

CREATE TABLE Produto(
CodigoProduto INT IDENTITY(1,1) PRIMARY KEY,
Nome		     NVARCHAR(225) NOT NULL,
Preço			 INT		   NOT NULL,
CodigoCategoria  INT           NOT NULL

FOREIGN KEY (CodigoCategoria) REFERENCES Categoria(CodigoCategoria)

);

