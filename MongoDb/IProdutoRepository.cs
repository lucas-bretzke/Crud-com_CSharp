using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    internal interface IProdutoRepository
    {
        public Task<Produto> Insert(Produto produto);

        public Task<Produto> Update(Produto produto);
        
        public Task Delete(string nomeProduto);

        public Task<List<Produto>> Read();

        public Task<Produto> GetByName(string nomeProduto);
    }
}
