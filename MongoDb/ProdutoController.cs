using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public class ProdutoController : IControllerBase
    {
        private ProdutoRepository _repository;

        public ProdutoController() { 
        _repository = new ProdutoRepository();  
        }
        public async Task Create()
        {
            try
            {
                Console.WriteLine("Adicionar produto.");
                Console.WriteLine("------------------");

                Produto novoProduto = new Produto
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = Utils.ReadFromConsole("Digite o nome do produto"),
                    Preco = Decimal.Parse(Utils.ReadFromConsole("Digite o preço do produto")),
                };
                await _repository.Insert(novoProduto);
            }
            catch (Exception e) {
             Console.WriteLine(e.Message);            
            }

        }

        public async Task Delete()
        {
            await Read();
            string nome = Utils.ReadFromConsole("Digite o nome do produto");
            await _repository.Delete(nome);
        }

        public async Task Read()
        {
          List<Produto> produtos = await _repository.Read();
          Utils.ExibirComoTabela(produtos);
        }

        public async Task Update()
        {
            await Read();
            string nome = Utils.ReadFromConsole("Digite o nome do produto: ");
            Produto antigo = await _repository.GetByName(nome);

            Produto novoProduto = new Produto
            {
                Id = antigo.Id,
                Nome = Utils.ReadFromConsole($"Digite o novo nome para {antigo.Nome}"),
                Preco = Decimal.Parse(Utils.ReadFromConsole($"Digite o preço para {antigo.Preco}")),
            };
            await _repository.Update(novoProduto);


        }
    }
}
