USE M_Peoples;
GO

--- busca os funcionarios pelo nome
SELECT idFuncionario, nome, sobrenome FROM funcionarios
WHERE nome = 'Catarina';

-- Busca os funcionarios trazendo nome comleto
SELECT CONCAT (nome, '', sobrenome) AS [nome completo]
FROM funcionarios;

-- ordena os funcionarios atraves do nome
-- de maneira crescente e descrecente

SELECT nome, sobrenome FROM funcionarios
ORDER BY sobrenome ASC;
--OU DESC
