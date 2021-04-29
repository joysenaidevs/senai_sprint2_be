USE SENAI_HROADS_MANHA;

INSERT INTO Classe(Nome)
VALUES			  ('Bárbaro'),
				  ('Monge'),
				  ('Arcanista'),
				  ('Cruzado'),
				  ('Caçador de Demônios'),
				  ('Necromante'),
				  ('Feiticeiro');

UPDATE Classe
SET Nome = ('Necromancer')
WHERE IdClasse = 6;

INSERT INTO Personagem (IdClasse, Nome, CapacicadeMaximaVida, CapacicadeMaximaMana, DataAtualizacao, DataCriacao)
VALUES				   (	1,	'DeuBug',		100,					80,				GETDATE(),	 '2019-01-18'),
					   (	2,	'BitBug',		70,						100,			GETDATE(),	 '2016-03-17'),
					   (	3,	'Fer8',			75,						60,				GETDATE(),	 '2018-03-18');

UPDATE Personagem
SET Nome = ('Fer7')
WHERE IdClasse = 3;

INSERT INTO TipoHabilidade(Nome)
VALUES		('Ataque'),
			('Defesa'),
			('Cura'),
			('Magia');

INSERT INTO Habilidade(IdTipoHabilidade, Nome)
VALUES				  (		1,		'Lança Mortal'),
					  (		2,		'Escudo Supremo'),
					  (		3,		'Recuperar Vida');

INSERT INTO ClasseHabilidade(IdClasse, IdHabilidade)
VALUES						(	1,			1	   ),
							(	1,			2	   ),
							(	2,			2	   ),
							(   2,			3	   ),
							(	3,			NULL   ),
							(	4,			2	   ),
							(	5,			1	   ),
							(	6,			NULL   ),
							(	7,			3	   );


INSERT INTO TipoUsuario(Titulo)
VALUES ('Administrador'),
	   ('Usuario')


INSERT INTO Usuario(Email, Senha, IdTipoUsuario)
VALUES ('adm@adm.com', 'adm123', 1),
	   ('cliente@cliente.com', 'cliente123', 2)