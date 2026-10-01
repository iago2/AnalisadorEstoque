using AnalisadorEstoque;

string arquivo = "produtos.csv";
int linhaAtual = 0;

List<Produto> listaProdutos = new List<Produto>();

// ==========================
// LEITURA DO CSV
// ==========================

using (var sr = new StreamReader(arquivo))
{
    while (!sr.EndOfStream)
    {
        string resultado = sr.ReadLine();
        string[] buffer = resultado.Split(";");
        linhaAtual++;

        if (linhaAtual > 2)
        {
            int ID = int.Parse(buffer[0]);
            decimal preco = decimal.Parse(buffer[3]);
            int quantidade = int.Parse(buffer[4]);

            Produto produto = new Produto();

            produto.ID = ID;
            produto.PRODUTO = buffer[1];
            produto.CATEGORIA = buffer[2];
            produto.PRECO = preco;
            produto.QUANTIDADE = quantidade;

            listaProdutos.Add(produto);
        }
    }
}

// ==========================
// CABEÇALHO
// ==========================

Console.WriteLine("========================================");
Console.WriteLine("       ANALISADOR DE ESTOQUE");
Console.WriteLine("========================================");

Console.WriteLine($"Produtos analisados: {listaProdutos.Count}");


// ==========================
// 1. PRODUTOS DE INFORMÁTICA
// ==========================

var produtosInformatica = from produto in listaProdutos
                          where produto.CATEGORIA == "Informatica"
                          select produto;

Console.WriteLine(
    $"\nProdutos de Informática: {produtosInformatica.Count()}"
);


// ==========================
// 2. VALOR TOTAL DO ESTOQUE
// ==========================

var valorTotalEstoque =
    listaProdutos.Sum(produto => produto.PRECO * produto.QUANTIDADE);

Console.WriteLine(
    $"Valor total do estoque: R$ {valorTotalEstoque:N2}"
);


// ==========================
// 3. PRODUTO COM MAIOR QUANTIDADE
// ==========================

var maiorQuantidade = listaProdutos
    .OrderByDescending(produto => produto.QUANTIDADE)
    .First();

Console.WriteLine("\nProduto com maior quantidade:");
Console.WriteLine(
    $"{maiorQuantidade.PRODUTO} - {maiorQuantidade.QUANTIDADE} unidades"
);


// ==========================
// 4. PRODUTO COM MAIOR VALOR EM ESTOQUE
// ==========================

var maiorValorEstoque = listaProdutos
    .OrderByDescending(produto => produto.PRECO * produto.QUANTIDADE)
    .First();

Console.WriteLine("\nProduto com maior valor em estoque:");
Console.WriteLine(
    $"{maiorValorEstoque.PRODUTO} - R$ {maiorValorEstoque.PRECO * maiorValorEstoque.QUANTIDADE:N2}"
);


// ==========================
// 5. PRODUTOS COM ESTOQUE BAIXO
// ==========================

var estoqueBaixo = from produto in listaProdutos
                   where produto.QUANTIDADE <= 3
                   select produto;

Console.WriteLine("\nProdutos com estoque baixo:");

foreach (var produto in estoqueBaixo)
{
    Console.WriteLine(
        $"{produto.PRODUTO} - {produto.QUANTIDADE} unidades"
    );
}


// ==========================
// 6. CATEGORIA COM MAIOR QUANTIDADE
// ==========================

var categoriaMaiorQuantidade =
    from produto in listaProdutos
    group produto by produto.CATEGORIA into grupo
    orderby grupo.Sum(item => item.QUANTIDADE) descending
    select new
    {
        Categoria = grupo.Key,
        TotalQuantidade = grupo.Sum(item => item.QUANTIDADE)
    };

var primeiraCategoriaQuantidade = categoriaMaiorQuantidade.First();

Console.WriteLine("\nCategoria com maior quantidade em estoque:");
Console.WriteLine(
    $"{primeiraCategoriaQuantidade.Categoria} - {primeiraCategoriaQuantidade.TotalQuantidade} unidades"
);


// ==========================
// 7. CATEGORIA COM MAIOR VALOR
// ==========================

var categoriaMaiorValor =
    from produto in listaProdutos
    group produto by produto.CATEGORIA into grupo
    orderby grupo.Sum(item => item.PRECO * item.QUANTIDADE) descending
    select new
    {
        NomeCategoria = grupo.Key,
        TotalEstoqueValor = grupo.Sum(item => item.PRECO * item.QUANTIDADE)
    };

var primeiraCategoriaValor = categoriaMaiorValor.First();

Console.WriteLine("\nCategoria com maior valor em estoque:");
Console.WriteLine(
    $"{primeiraCategoriaValor.NomeCategoria} - R$ {primeiraCategoriaValor.TotalEstoqueValor:N2}"
);


// ==========================
// 8. MÉDIA DE PREÇO - INFORMÁTICA
// ==========================

var mediaInformatica =
    produtosInformatica.Average(item => item.PRECO);

Console.WriteLine("\nMédia de preço dos produtos de Informática:");
Console.WriteLine($"R$ {mediaInformatica:N2}");


// ==========================
// FINAL
// ==========================

Console.WriteLine("\n========================================");
Console.WriteLine("          ANÁLISE CONCLUÍDA");
Console.WriteLine("========================================");