-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE Usuario (
UserName VARCHAR(10) PRIMARY KEY,
Password VARCHAR(10)
)

CREATE TABLE Cuidador (
codCuidador INTEGER PRIMARY KEY,
nomeCuidador VARCHAR(30),
UserName VARCHAR(10),
FOREIGN KEY(UserName) REFERENCES Usuario (UserName)
)

CREATE TABLE Tratamento (
codPaciente INTEGER,
dataInicial DATETIME,
codDesafio INTEGER,
codRemedio INTEGER,
codEfeito1 INTEGER,
codEfeito2 INTEGER,
codEfeito3 INTEGER,
Observacao Text,
PRIMARY KEY(codPaciente,dataInicial,codDesafio,codRemedio)
)

CREATE TABLE Paciente (
codPaciente INTEGER PRIMARY KEY,
nomePaciente VARCHAR(30),
UserName VARCHAR(10),
FOREIGN KEY(UserName) REFERENCES Usuario (UserName)
)

CREATE TABLE DesafioSaude (
codDesafio INTEGER PRIMARY KEY,
nomeDesafio VARCHAR(40)
)

CREATE TABLE Familiar (
codFamiliar INTEGER PRIMARY KEY,
nomeFamiliar VARCHAR(30),
UserName VARCHAR(10),
FOREIGN KEY(UserName) REFERENCES Usuario (UserName)
)

CREATE TABLE ContratoCuidador (
codPaciente INTEGER,
codCuidador INTEGER,
dataInicial DATETIME,
dataFinal DATETIME,
horaEntrada1 Time,
horaSaida1 time,
horaEntrada2 Time,
horaSaida2 Time,
PRIMARY KEY(codPaciente,codCuidador,dataInicial),
FOREIGN KEY(codPaciente) REFERENCES Paciente (codPaciente),
FOREIGN KEY(codCuidador) REFERENCES Cuidador (codCuidador)
)

CREATE TABLE EfeitoAdverso (
codEfeito INTEGER PRIMARY KEY,
descEfeito VARCHAR(30)
)

CREATE TABLE Remedio (
codRemedio INTEGER PRIMARY KEY,
farmaco VARCHAR(40),
detentor VARCHAR(40),
medicamento VARCHAR(40),
registroANS VARCHAR(10),
concentracao VARCHAR(20),
formaFarmaceutica VARCHAR(20)
)

ALTER TABLE Tratamento ADD FOREIGN KEY(codPaciente) REFERENCES Paciente (codPaciente)
ALTER TABLE Tratamento ADD FOREIGN KEY(codDesafio) REFERENCES DesafioSaude (codDesafio)
ALTER TABLE Tratamento ADD FOREIGN KEY(codRemedio) REFERENCES Remedio (codRemedio)
ALTER TABLE Tratamento ADD FOREIGN KEY(codEfeito1) REFERENCES EfeitoAdverso (codEfeito)
ALTER TABLE Tratamento ADD FOREIGN KEY(codEfeito2) REFERENCES EfeitoAdverso (codEfeito)
ALTER TABLE Tratamento ADD FOREIGN KEY(codEfeito3) REFERENCES EfeitoAdverso (codEfeito)
