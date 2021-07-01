USE medicalGroup;
-- DQL
SELECT idUsuario, nomeTipoUsuario, nomeUsuario,email FROM usuarios
INNER JOIN tipoUsuarios -- JUNTAR COM A TABELA TIPOS USUARIOS
ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario -- A CONDICAO

-- JUNTANDO A TABELA ESPECIALIDADE COM MEDICO
SELECT  nomeEspecialidade, idMedico,nomeMedico FROM especialidades
INNER JOIN medicos
ON especialidades.idEspecialidade = medicos.idEspecialidade

-- JUNTANDO AS TABELAS MEDICOS, CLINICAS E ESPECIALIDADES
SELECT nomeMedico, email, razaoSocial, nomeEspecialidade FROM medicos
INNER JOIN clinicas
ON medicos.idClinica = clinicas.idClinica
INNER JOIN especialidades --fazendo referencia a tabela especidade
ON medicos.idEspecialidade = especialidades.idEspecialidade

-- JUNTANDO A TABELA PRONTUARIO COM USUARIO
SELECT  nomeProntuario AS prontuario, dataNascimento, telefone, rg, cpf , nomeUsuario AS usuario FROM prontuarios
INNER JOIN usuarios
ON prontuarios.idUsuario = usuarios.idUsuario

-- CONSULTAS COM MEDICO E PRONTUARIOS
SELECT nomeMedico, dataConsulta, situacao, nomeProntuario FROM consultas
INNER JOIN medicos
ON consultas.idMedico =  medicos.idMedico
INNER JOIN prontuarios
ON consultas.idProntuario = prontuarios.idProntuario


SELECT nomeUsuario, email FROM usuarios U
INNER JOIN tipoUsuarios TU
ON u.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'joao@email.com' AND senha = 'joao123';
--WHERE idUsuario = 3


SELECT * FROM  clinicas;

SELECT * FROM prontuarios;

SELECT *FROM especialidades;

SELECT * FROM medicos;

SELECT * FROM consultas;

SELECT * FROM tipoUsuarios;


