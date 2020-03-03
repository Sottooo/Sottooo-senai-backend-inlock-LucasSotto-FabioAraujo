-- DQL

-- Usa o banco de dados InLock_Games_Tarde.
USE Inlock_Games_Tarde;

-- Seleciona todos os estudios.
SELECT * FROM Estudios;

-- Seleciona todos os jogos.
SELECT * FROM Jogos;

-- Seleciona todos os usuarios.
SELECT * FROM Usuarios;

-- Seleciona todos os jogos com seus respectivos estudios.
SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, Estudios.IdEstudio, Estudios.NomeEstudio FROM Jogos RIGHT JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio;

-- Procedure para buscar usuario pelo email.
CREATE PROCEDURE BuscaUsuario
@Buscar VARCHAR (20)
AS SELECT * FROM Usuarios WHERE Usuarios.Email LIKE '%' + @Buscar + '%';

EXECUTE BuscaUsuario 'a';

-- Procedure para buscar o jogo pelo Id.
CREATE PROCEDURE BuscaJogoId
@BuscarJogo VARCHAR (20)
AS SELECT * FROM Jogos WHERE Jogos.IdJogo LIKE '%' + @BuscarJogo + '%';

EXECUTE BuscaJogoId '2';

-- Procedure para buscar o estudio pelo Id.
CREATE PROCEDURE BuscaEstudioId
@BuscarEstudio VARCHAR (20)
AS SELECT * FROM Estudios WHERE Estudios.IdEstudio LIKE '%' + @BuscarEstudio + '%';

EXECUTE BuscaEstudioId '3';

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, Jogos.IdEstudio, Estudios.IdEstudio, Estudios.NomeEstudio FROM Jogos RIGHT JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio