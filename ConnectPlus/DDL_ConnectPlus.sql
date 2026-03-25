CREATE DATABASE ConnectPlus
GO

CREATE TABLE tb_TiposContatos (
	ID_TipoContato UNIQUEIDENTIFIER PRIMARY KEY DEFAULT ((NEWID())),
	Titulo		   NVARCHAR(100)	NOT NULL			   

);

CREATE TABLE Contato (
	Id_Contato	UNIQUEIDENTIFIER	PRIMARY KEY DEFAULT ((NEWID())),
	Nome		NVARCHAR(100)		NOT NULL,
	FormaContato	NVARCHAR(255)	NOT NULL,
	foto_perfil		NVARCHAR(150)		NULL,
	id_TipoContato  UNIQUEIDENTIFIER FOREIGN KEY REFERENCES tb_tiposContatos
	(ID_TipoContato)
);

drop database ConnectPlus