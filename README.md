# AnalisadorEstoque

Projeto desenvolvido em **C# com .NET** para leitura e análise de dados de estoque utilizando arquivos CSV e LINQ.

## Objetivo

O projeto foi desenvolvido para praticar programação e análise de dados a partir de uma base simples de produtos.

A aplicação lê os dados de um arquivo CSV, transforma os registros em objetos e realiza diferentes análises utilizando LINQ.

## Tecnologias

- C#
- .NET 10
- LINQ
- CSV
- Git e GitHub

## Estrutura dos dados

O arquivo `produtos.csv` possui as seguintes informações:

| Campo | Descrição |
|---|---|
| ID | Identificador do produto |
| PRODUTO | Nome do produto |
| CATEGORIA | Categoria do produto |
| PREÇO | Preço unitário |
| QUANTIDADE | Quantidade disponível em estoque |

## Análises realizadas

O projeto realiza análises como:

- Quantidade de produtos por categoria
- Valor total do estoque
- Produto com maior quantidade em estoque
- Produto com maior valor financeiro em estoque
- Produtos com estoque baixo
- Categoria com maior quantidade em estoque
- Categoria com maior valor financeiro em estoque
- Média de preço dos produtos de Informática

## Exemplo de resultado

```text
Produtos analisados: 8

Valor total do estoque: R$ 5.216,80

Produto com maior quantidade:
MOUSE - 15 unidades

Produtos com estoque baixo:
MONITOR - 3 unidades
TÊNIS - 2 unidades
JAQUETA - 3 unidades

Categoria com maior valor em estoque:
INFORMATICA - R$ 5.216,80
```

## Como executar

1. Clone este repositório.
2. Abra o projeto no Visual Studio.
3. Execute o projeto.
4. O programa utilizará o arquivo `produtos.csv` para realizar as análises.

## Próximos passos

A ideia é evoluir o projeto futuramente, utilizando outras tecnologias para ampliar a análise dos dados:

```text
CSV
 ↓
C# / .NET
 ↓
LINQ
 ↓
SQL Server
 ↓
Power BI
```

## Autor

**Iago Macanhão**

Estudante de Análise e Desenvolvimento de Sistemas.