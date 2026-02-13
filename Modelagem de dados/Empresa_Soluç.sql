CREATE DATABASE Solucoes_express

CREATE TABLE tb_empresa (
Id_empresa	INT				IDENTITY(1,1) PRIMARY KEY
,Nome		NVARCHAR(225)	NOT NULL
,CNPJ		NVARCHAR(14)	NOT NULL

);

CREATE TABLE tb_produtos(
Id_produto		INT					IDENTITY(1,1)	PRIMARY KEY
,Nome			NVARCHAR(225)		NOT NULL
,Categoria		NVARCHAR(225)		NOT NULL
,Preco			DECIMAL (10, 2)		NOT NULL
,Id_empresa		INT					NOT NULL

FOREIGN KEY (Id_empresa) REFERENCES tb_empresa(Id_empresa)
);

CREATE TABLE tb_pedidos(
Id_pedidos INT IDENTITY(1,1) PRIMARY KEY
,data_pedi DATE NOT NULL
,Valor_total DECIMAL(10, 2) NOT NULL
,Id_produto INT NOT NULL
,Id_empresa INT NOT NULL

FOREIGN KEY (Id_empresa) REFERENCES tb_empresa(Id_empresa)
,FOREIGN KEY (Id_produto) REFERENCES tb_produtos(Id_produto)


);

CREATE TABLE tb_clientes(
Id_clientes INT IDENTITY(1,1) PRIMARY KEY
,Nome NVARCHAR(225) NOT NULL
,CPF  NVARCHAR(14) NOT NULL
,CNPJ NVARCHAR(14) NOT NULL
,Telefone NVARCHAR(14) NOT NULL
,Endereco NVARCHAR(225) NOT NULL
,Id_pedidos INT NOT NULL

FOREIGN KEY (Id_pedidos) REFERENCES tb_pedidos(Id_pedidos)

);

CREATE TABLE tb_status(
Id_status INT IDENTITY(1,1) PRIMARY KEY
,Pendente NVARCHAR(225) NULL
,Em_transporte NVARCHAR(225) NULL
,Entregue NVARCHAR(225) NULL
,Id_pedidos INT NOT NULL

FOREIGN KEY (Id_pedidos) REFERENCES tb_pedidos(Id_pedidos)

);

CREATE TABLE rastreamento(
data_entre DATE NOT NULL
,hora TIME NOT NULL
,localização NVARCHAR NOT NULL


FOREIGN KEY (Id_pedidos) REFERENCES tb_pedidos(Id_pedidos),
FOREIGN KEY (Id_status) REFERENCES tb_status(Id_status)

);

CREATE TABLE Entregadores(
Nome NVARCHAR(225) NOT  NULL
,CPF NVARCHAR(14) NOT NULL
,Veiculo NVARCHAR(225) NOT  NULL
,Em_transporte NVARCHAR(225) NOT  NULL


FOREIGN KEY (Id_empresa) REFERENCES tb_empresa(Id_empresa),
FOREIGN KEY (Id_pedidos) REFERENCES tb_pedidos(Id_pedidos)

);



