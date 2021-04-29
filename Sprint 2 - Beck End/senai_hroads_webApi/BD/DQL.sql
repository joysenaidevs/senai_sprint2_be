USE SENAI_HROADS_MANHA;

SELECT * FROM Classe;

SELECT * FROM Personagem;

SELECT * FROM Habilidade;

SELECT * FROM TipoHabilidade;

SELECT * FROM ClasseHabilidade;

SELECT * FROM Usuario;

SELECT * FROM TipoUsuario;

SELECT Nome
FROM Classe;

SELECT COUNT(IdHabilidade) AS QuantidadeDeHabilidade
FROM Habilidade;

SELECT IdPersonagem, Personagem.Nome, Personagem.IdClasse, Classe.Nome AS NomeDaClasse, CapacicadeMaximaMana, CapacicadeMaximaVida FROM Personagem
INNER JOIN Classe
ON Personagem.IdClasse = Classe.IdClasse;

SELECT Habilidade.IdHabilidade 
FROM Habilidade
ORDER BY IdHabilidade ASC;

SELECT Personagem.Nome AS Personagem, Classe.Nome AS Classe FROM Personagem
RIGHT JOIN Classe
ON Classe.IdClasse = Personagem.IdClasse;

select IdUsuario, Email, Senha, TipoUsuario.Titulo from Usuario
inner join TipoUsuario on Usuario.IdUsuario = TipoUsuario.IdTipoUsuario
where Email like 'adm@adm.com';
