//Script para criar a tabela de PessoaFisica
CREATE TABLE Pessoa(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    NomeCompleto NVARCHAR(100) NOT NULL,
    DataNascimento DATE NOT NULL,
    ValorRenda DECIMAL(10, 2) NOT NULL,
    CPF NVARCHAR(11) NOT NULL UNIQUE
);