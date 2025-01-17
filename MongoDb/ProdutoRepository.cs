using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public class ProdutoRepository : IProdutoRepository
    {

        private MongoRepository<Produto> _mongo;

        public ProdutoRepository()
        {
            _mongo = new MongoRepository<Produto>("Produtos");
        }
        public async Task Delete(string nomeProduto)
        {
            var filter = Builders<Produto>.Filter.Eq(q => q.Nome, nomeProduto);
        await _mongo.DeleteAsync(filter);
        }

        public async Task<Produto> GetByName(string nomeProduto)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Nome, nomeProduto);
            List<Produto> produtos = await _mongo.FindAsync(filter);
            return produtos.FirstOrDefault();
        }

        public async Task<Produto> Insert(Produto produto)
        {
            await _mongo.InsertAsync(produto);
            return produto;
        }

        public async Task<List<Produto>> Read()
        {
            var filtro = Builders<Produto>.Filter.Empty;
            return await _mongo.FindAsync(filtro);
        }

        public async Task<Produto> Update(Produto produto)
        {
            var filtro = Builders<Produto>.Filter.Eq(produto => produto.Id, produto.Id);
            var update = Builders<Produto>.Update.Set(p => p.Nome, produto.Nome).Set(p => p.Preco, produto.Preco);
            await _mongo.UpdateAsync(filtro, update);
            return produto;
        }
    }
}
