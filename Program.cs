using AnalisadorEstoque;

string arquivo = "produtos.csv";
int linhaAtual = 0;


List<Produto> listaProdutos = new List<Produto>();


using (var sr = new StreamReader(arquivo))
{
    while (!sr.EndOfStream)
    {
        string resultado = sr.ReadLine();
        string[] buffer = resultado.Split(";");
        linhaAtual++;
       
        if(linhaAtual > 2)
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


var pesquisa = from produto in listaProdutos
               group produto by produto.CATEGORIA into grupo
               orderby grupo.Sum(item => item.PRECO * item.QUANTIDADE) descending
               select new
               {
                   NomeCategoria = grupo.Key,
                   TotalestoqueValor = grupo.Sum(item => item.PRECO * item.QUANTIDADE)
               };


var primeiro = pesquisa.First();


Console.WriteLine($"Categoria: {primeiro.NomeCategoria} | Valor: {primeiro.TotalestoqueValor}");










