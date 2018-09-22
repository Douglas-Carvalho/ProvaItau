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
    Id_motivoAvariaEquipamentoUtilizadoAtendimento INT,
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

CREATE PROCEDURE StpView_VerificaAtendimentoChamado

    @NumeroChamado INT

AS
BEGIN

    IF (SELECT COUNT(*) 
        FROM AtendimentoChamadoInstalacao Atendimento
        INNER JOIN ChamadoInstalacao Chamado
            ON Chamado.Id = Atendimento.Id_chamadoInstalacao
        WHERE Chamado.NumeroChamado = @NumeroChamado) <> 0 BEGIN

            IF (SELECT COUNT(*) FROM AtendimentoChamadoInstalacao Atendimento
                INNER JOIN ChamadoInstalacao Chamado 
                ON Chamado.Id = Atendimento.Id_chamadoInstalacao
                INNER JOIN EquipamentoUtilizadoAtendimentoChamadoInstalacao Instalacao
                    ON Instalacao.Id_atendimentoChamadoInstalacao = Atendimento.Id
                LEFT OUTER JOIN MotivoAvariaEquipamento Motivo
                    ON Motivo.Id = Instalacao.Id_motivoAvariaEquipamentoUtilizadoAtendimento
                WHERE 
                    Chamado.NumeroChamado = @NumeroChamado
                    AND Instalacao.Id_motivoAvariaEquipamentoUtilizadoAtendimento IS NULL) <> 0 BEGIN

                SELECT 0

            END ELSE BEGIN

                SELECT 1

            END

    END ELSE BEGIN

        IF(SELECT COUNT(*) FROM ChamadoInstalacao 
            WHERE NumeroChamado = @NumeroChamado) <> 0 BEGIN
            
            SELECT 1
        END ELSE BEGIN 
            
            SELECT 0
        END

    END

END

CREATE PROCEDURE Stp_RegistraAtendimento

@Data DATETIME,
@ChamadoId INT

AS
BEGIN

DECLARE @IdChamado INT = (SELECT Id FROM ChamadoInstalacao WHERE NumeroChamado = @ChamadoId)

INSERT INTO AtendimentoChamadoInstalacao (DataAtendimento, Id_chamadoInstalacao)
VALUES (@Data,  @IdChamado)

SELECT CAST(SCOPE_IDENTITY() as INT)

END

CREATE PROCEDURE Stp_RegistraEquipamentoUtilizado

    @EquipamentoId INT,
    @AtendimentoId INT,
    @MotivoId INT

AS 
BEGIN

    INSERT INTO EquipamentoUtilizadoAtendimentoChamadoInstalacao (Id_cadastroEquipamento, Id_atendimentoChamadoInstalacao, Id_motivoAvariaEquipamentoUtilizadoAtendimento)
    VALUES(@EquipamentoId, @AtendimentoId, (CASE WHEN @MotivoId = 0 THEN NULL ELSE @MotivoId END))

END

Resolução do exericio 2


1 Parte

Seria desenvolvida uma tela com os seguintes inputs:

Numero de chamado do tipo Number, Equipamento do tipo Select, 
Grupo Responsável do tipo Select e Custo do tipo Number.

Quando todos os filtros fossem preenchidos e a view filtrada, neste momento 
um ajax seria chamado que por sua vez chamaria um método da controller onde 
desempenharia todo o processo de consulta ao banco e retorno das 
informações(Seguindo o padrão de arquitetura definida para o exercício 1),
quando o retorno estivesse ok eu retornaria um objeto para view onde eu 
teria os parâmetros para informar se há inconsistências com o chamado ou não.

A apresentação seria montada através de uma regra de view que validaria todos os
status retornados e informaria se houvesse inconsistência quantas seriam e quais 
seriam e caso não haja nenhuma inconsistência apenas uma mensagem de que não haveria 
nenhuma inconsistência. 


2 parte

Ela é responsavel por retornar todos os status de inconsistência caso haja alguma 
no chamado, caso não haja nenhuma inconsistência ela retornara apenas os status de consistente.

A ideia é no futuro criar uma tabela mapeando todos os status para que possa ser
validado com mais facilidade tanto na view quanto no banco.

DECLARE @NumeroChamado INT = 1
DECLARE @IdEquipamento INT = 1
DECLARE @IdResponsavel INT = 1
DECLARE @VlrCusto FLOAT = 50
DECLARE @StatusChamado VARCHAR(MAX) = NULL


-- VALIDA SE O CHAMADO EXISTE
IF(SELECT COUNT(*) FROM ChamadoInstalacao WHERE NumeroChamado = @NumeroChamado) <> 0 BEGIN

    SET @StatusChamado = '1'

    -- VALIDA SE EXISTE ATENDIMENTO PARA ESTE CHAMADO
    IF (SELECT COUNT(*) 
        FROM AtendimentoChamadoInstalacao Atendimento
        INNER JOIN ChamadoInstalacao Chamado
            ON Chamado.Id = Atendimento.Id_chamadoInstalacao
        WHERE Chamado.NumeroChamado = @NumeroChamado) <> 0 BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '2')

    END ELSE BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '3')

        SELECT @StatusChamado

        RETURN;

    END

    -- VALIDA SE O EQUIPAMENTO PASSADO EXISTE EM ALGUM ATENDIMENTO DO CHAMADO ATUAL
    IF (SELECT 
           COUNT(*) 
        FROM AtendimentoChamadoInstalacao Instalacao
        INNER JOIN ChamadoInstalacao Chamado
            ON Chamado.Id = Instalacao.Id_chamadoInstalacao
        INNER JOIN EquipamentoUtilizadoAtendimentoChamadoInstalacao Equipamento
            ON Equipamento.Id_atendimentoChamadoInstalacao = Instalacao.Id
        WHERE   Chamado.NumeroChamado = @NumeroChamado 
            AND Equipamento.Id_cadastroEquipamento = @IdEquipamento) <> 0 BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '4')

    END ELSE BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '5')

    END

    -- VALIDA SE O RESPONSAVEL PASSADO EXISTE EM ALGUM ATENDIMENTO DO CHAMADO ATUAL    
    IF (SELECT 
           COUNT(*) 
        FROM AtendimentoChamadoInstalacao Instalacao
        INNER JOIN ChamadoInstalacao Chamado
            ON Chamado.Id = Instalacao.Id_chamadoInstalacao
        INNER JOIN EquipamentoUtilizadoAtendimentoChamadoInstalacao Equipamento
            ON Equipamento.Id_atendimentoChamadoInstalacao = Instalacao.Id
        INNER JOIN MotivoAvariaEquipamento Motivo 
            ON Equipamento.Id_motivoAvariaEquipamentoUtilizadoAtendimento = Motivo.Id
        WHERE   Chamado.NumeroChamado = @NumeroChamado 
            AND Motivo.Id_ResponsavelOrigemAvariaEquipamento = @IdResponsavel) <> 0 BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '6')

    END ELSE BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '7')

    END

    -- VALIDA SE O CUSTO PASSADO EXISTE EM ALGUM ATENDIMENTO DO CHAMADO ATUAL    
    IF (SELECT 
           COUNT(*) 
        FROM AtendimentoChamadoInstalacao Instalacao
        INNER JOIN ChamadoInstalacao Chamado
            ON Chamado.Id = Instalacao.Id_chamadoInstalacao
        INNER JOIN EquipamentoUtilizadoAtendimentoChamadoInstalacao Equipamento
            ON Equipamento.Id_atendimentoChamadoInstalacao = Instalacao.Id
        INNER JOIN CadastroEquipamento CEquipamento 
            ON Equipamento.Id_cadastroEquipamento = CEquipamento.Id
        WHERE   Chamado.NumeroChamado = @NumeroChamado 
            AND CEquipamento.PrecoEquipamento = @VlrCusto) <> 0 BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '8')

    END ELSE BEGIN

        SET @StatusChamado = CONCAT(@StatusChamado, ',', '9')

    END

END ELSE BEGIN

    SET @StatusChamado = '100'

END

SELECT @StatusChamado
