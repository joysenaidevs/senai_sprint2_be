CREATE DATABASE medicalGroup;

-- nome que deve estar nos script : senai_spmedgroup_01_DDL.sql
-- DDL
USE medicalGroup;
GO

CREATE TABLE tipoUsuarios
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario	VARCHAR (200) UNIQUE NOT NULL -- DIZ QUE O VALOR É UNICO, PARA NAO CADASTRAR DADOS REPETIDOS (UNIQUE)

);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuarios (idTipoUsuario) -- (idTipoUsuario) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,nomeUsuario		VARCHAR (200) NOT NULL
	,email				VARCHAR (200) UNIQUE NOT NULL
	,senha				VARCHAR (200) NOT NULL

);
GO

CREATE TABLE clinicas
(
	idClinica					INT PRIMARY KEY IDENTITY
	,cnpj						CHAR (14) UNIQUE NOT NULL 
	,nomeFantasia				VARCHAR (200) NOT NULL
	,razaoSocial				VARCHAR (200) NOT NULL
	,endereco					VARCHAR (200) UNIQUE NOT NULL
	,horarioFuncionamento		TIME
);
GO

CREATE TABLE prontuarios
(
	idProntuario				INT PRIMARY KEY IDENTITY
	,idUsuario					INT FOREIGN KEY REFERENCES tipoUsuarios (idTipoUsuario) -- (idTipoUsuario) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,nomeProntuario				VARCHAR (200) NOT NULL
	,dataNascimento				DATE
	,telefone					INT NOT NULL
	,rg							CHAR (20) UNIQUE NOT NULL
	,cpf						CHAR (20) UNIQUE NOT NULL
	,endereco					VARCHAR (200) UNIQUE NOT NULL
);
GO

CREATE TABLE especialidades
(
	idEspecialidade				INT PRIMARY KEY IDENTITY
	,nomeEspecialidade			VARCHAR (200) UNIQUE NOT NULL 
);
GO

CREATE TABLE medicos
(
	idMedico				INT PRIMARY KEY IDENTITY
	,idEspecialidade		INT FOREIGN KEY REFERENCES especialidades (idEspecialidade) -- (idEspecialiade) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,idClinica				INT FOREIGN KEY REFERENCES clinicas (idClinica) -- (idClinca) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,idUsuario				INT FOREIGN KEY REFERENCES usuarios (idUsuario) -- (idUsuario) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,nomeMedico				VARCHAR (200)  NOT NULL 
	,email					VARCHAR (200)  NOT NULL 
);
GO

CREATE TABLE consultas
(
	 idConsulta				INT PRIMARY KEY IDENTITY
	,idProntuario			INT FOREIGN KEY REFERENCES prontuarios (idProntuario) -- (idProntuario) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,idMedico				INT FOREIGN KEY REFERENCES medicos (idMedico) -- (idMedico) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,dataConsulta			DATE UNIQUE NOT NULL
	,situacao				VARCHAR (100) NOT NULL
);
GO