-- DDL

-- Cria banco de dados.
CREATE DATABASE Inlock_Games_Tarde;

-- Usa o banco de dados InLock_Games_Tarde.
USE Inlock_Games_Tarde;

-- Cria tabela de estudios.
CREATE TABLE Estudios(
	IdEstudio INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR(255)	
);

-- Cria tabela de jogos.
CREATE TABLE Jogos (
	IdJogo INT PRIMARY KEY IDENTITY,
	IdEstudio INT FOREIGN KEY REFERENCES Estudios,
	NomeJogo VARCHAR (255),
	DataLancamento DATE,
	Valor FLOAT
);

-- Cria tabela de tipo de usuarios.
CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(255),
);

-- Cria tabela de usuarios.
CREATE TABLE Usuarios(
	IdUsuarios INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario,
	Email VARCHAR (255),
	Senha VARCHAR (255),
);