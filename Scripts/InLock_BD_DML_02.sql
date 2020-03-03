-- DML

-- Usa o banco de dados InLock_Games_Tarde.
USE Inlock_Games_Tarde;

-- Insere valores na tabela tipo usuario.
INSERT INTO TipoUsuario (Titulo)
VALUES		('Administrador'), ('Cliente');

-- Insere valores na tabela de usuarios.
INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1), ('cliente@cliente.com', 'cliente', 2);

-- Insere valores na tabela de jogos.
INSERT INTO Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES ('Diablo 3', '� um jogo que cont�m bastante a��o e � viciante , seja voc� um novato ou um f�', '15/05/2012', 99.00 , 1),
       ('Red Dead Redemption 2', 'Jogo eletr�nico de a��o e aventura westen.', '26/10/2018', 120.00, 2);

-- Insere valores na tabela de estudios.
INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix');
