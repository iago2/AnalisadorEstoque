using System;
using System.Collections.Generic;
using System.Text;

namespace AnalisadorEstoque
{
    class Produto
    {
        public int ID { get; set; }
        public string PRODUTO { get; set; }
        public string CATEGORIA { get; set; }
        public decimal PRECO {  get; set; }

        public int QUANTIDADE { get; set; }
    }
}
