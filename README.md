# Prova Itau

Tecnologias Utilizadas:

DependencyInjector,
Ioc,
Dapper,
DDD,
AutoMapper,
FluentMapper,
.NET Core,
SQL Server

Script SQL:

USE master
GO
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'GlobalPhone'
)
CREATE DATABASE GlobalPhone
GO

USE GlobalPhone
GO

IF OBJECT_ID('dbo.ChamadoInstalacao', 'U') IS NOT NULL
    DROP TABLE dbo.ChamadoInstalacao
GO

CREATE TABLE dbo.ChamadoInstalacao
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    NumeroChamado INT NOT NULL
);
GO

IF OBJECT_ID('dbo.AtendimentoChamadoInstalacao', 'U') IS NOT NULL
    DROP TABLE dbo.AtendimentoChamadoInstalacao
GO

CREATE TABLE dbo.AtendimentoChamadoInstalacao
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    DataAtendimento DATETIME NOT NULL,
    Id_chamadoInstalacao INT NOT NULL,
    CONSTRAINT FK_Chamado_Instalacao FOREIGN KEY(Id_chamadoInstalacao) 
        REFERENCES AtendimentoChamadoInstalacao(Id)
        ON DELETE NO ACTION ON UPDATE NO ACTION 
);
GO

IF OBJECT_ID('dbo.CadastroEquipamento', 'U') IS NOT NULL
    DROP TABLE dbo.CadastroEquipamento
GO

CREATE TABLE dbo.CadastroEquipamento
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    NomeEquipamento VARCHAR(255) NOT NULL,
    PrecoEquipamento FLOAT NOT NULL
);
GO

IF OBJECT_ID('dbo.ResponsavelOrigemAvariaEquipamento', 'U') IS NOT NULL
    DROP TABLE dbo.ResponsavelOrigemAvariaEquipamento
GO

CREATE TABLE dbo.ResponsavelOrigemAvariaEquipamento
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    NomeGrupoResponsavelOrigemAvariaEquipamento VARCHAR(255) NOT NULL
);
GO

IF OBJECT_ID('dbo.MotivoAvariaEquipamento', 'U') IS NOT NULL
    DROP TABLE dbo.MotivoAvariaEquipamento
GO

CREATE TABLE dbo.MotivoAvariaEquipamento
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Id_ResponsavelOrigemAvariaEquipamento INT NOT NULL,
    TextoPadraoMotivoAvariaEquipamento VARCHAR(255) NOT NULL,
    CONSTRAINT FK_Responsavel FOREIGN KEY(Id_ResponsavelOrigemAvariaEquipamento) 
        REFERENCES ResponsavelOrigemAvariaEquipamento(Id)
        ON DELETE CASCADE ON UPDATE NO ACTION 
);
GO

IF OBJECT_ID('dbo.EquipamentoUtilizadoAtendimentoChamadoInstalacao', 'U') IS NOT NULL
    DROP TABLE dbo.EquipamentoUtilizadoAtendimentoChamadoInstalacao
GO

CREATE TABLE dbo.EquipamentoUtilizadoAtendimentoChamadoInstalacao
(
    Id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Id_cadastroEquipamento INT NOT NULL,
    Id_atendimentoChamadoInstalacao INT NOT NULL,
    Id_motivoAvariaEquipamentoUtilizadoAtendimento INT NOT NULL,
    CONSTRAINT FK_Equipamento FOREIGN KEY(Id_cadastroEquipamento) 
        REFERENCES CadastroEquipamento(Id)
        ON DELETE CASCADE ON UPDATE NO ACTION,
    CONSTRAINT FK_Atendimento FOREIGN KEY(Id_atendimentoChamadoInstalacao) 
        REFERENCES AtendimentoChamadoInstalacao(Id)
        ON DELETE CASCADE ON UPDATE NO ACTION ,
    CONSTRAINT FK_Motivo FOREIGN KEY(Id_motivoAvariaEquipamentoUtilizadoAtendimento) 
        REFERENCES MotivoAvariaEquipamento(Id)
        ON DELETE CASCADE ON UPDATE NO ACTION  
);
GO

INSERT INTO ChamadoInstalacao (NumeroChamado) 
VALUES (1)

INSERT INTO ChamadoInstalacao (NumeroChamado) 
VALUES (2)

INSERT INTO ChamadoInstalacao (NumeroChamado) 
VALUES (3)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 1)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 1)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 2)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 2)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 2)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao) 
VALUES (GETDATE(), 3)

INSERT INTO CadastroEquipamento (NomeEquipamento, PrecoEquipamento) 
VALUES ('modem 1', 50.00)

INSERT INTO CadastroEquipamento (NomeEquipamento, PrecoEquipamento) 
VALUES ('modem 2', 35.50)

INSERT INTO CadastroEquipamento (NomeEquipamento, PrecoEquipamento) 
VALUES ('modem 3', 105.55)

INSERT INTO ResponsavelOrigemAvariaEquipamento (NomeGrupoResponsavelOrigemAvariaEquipamento) 
VALUES ('Custo gerado pela transportadora')

INSERT INTO ResponsavelOrigemAvariaEquipamento (NomeGrupoResponsavelOrigemAvariaEquipamento) 
VALUES ('Custo gerado pela empresa responsável pela instalação')

INSERT INTO ResponsavelOrigemAvariaEquipamento (NomeGrupoResponsavelOrigemAvariaEquipamento) 
VALUES ('Custo gerado pelo cliente') 

INSERT INTO MotivoAvariaEquipamento (Id_ResponsavelOrigemAvariaEquipamento, TextoPadraoMotivoAvariaEquipamento)
VALUES (1,'Roteador quebrado')

INSERT INTO MotivoAvariaEquipamento (Id_ResponsavelOrigemAvariaEquipamento, TextoPadraoMotivoAvariaEquipamento)
VALUES (2,'Instalou errado')

INSERT INTO MotivoAvariaEquipamento (Id_ResponsavelOrigemAvariaEquipamento, TextoPadraoMotivoAvariaEquipamento)
VALUES (3,'Cliente quebrou o roteador')
 
INSERT INTO EquipamentoUtilizadoAtendimentoChamadoInstalacao(Id_cadastroEquipamento,Id_atendimentoChamadoInstalacao,Id_motivoAvariaEquipamentoUtilizadoAtendimento) 
VALUES (1,1,1)

INSERT INTO EquipamentoUtilizadoAtendimentoChamadoInstalacao(Id_cadastroEquipamento,Id_atendimentoChamadoInstalacao,Id_motivoAvariaEquipamentoUtilizadoAtendimento) 
VALUES (1,2,2)

INSERT INTO EquipamentoUtilizadoAtendimentoChamadoInstalacao(Id_cadastroEquipamento,Id_atendimentoChamadoInstalacao,Id_motivoAvariaEquipamentoUtilizadoAtendimento) 
VALUES (3,3,3)
