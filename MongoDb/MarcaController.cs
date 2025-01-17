using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public class MarcaController : IControllerBase
    {
        private MarcaRepository _repository;

        public MarcaController()
        {
            _repository = new MarcaRepository();
        }
        public async Task Create()
        {
            try
            {
                Console.WriteLine("Adicionar marca.");
                Console.WriteLine("------------------");

                Marca novaMarca = new Marca
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = Utils.ReadFromConsole("Digite o nome da marca"),
                };
                await _repository.Insert(novaMarca);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task Delete()
        {
            await Read();
            string nome = Utils.ReadFromConsole("Digite o nome da marca");
            await _repository.Delete(nome);
        }

        public async Task Read()
        {
            List<Marca> marcas = await _repository.Read();
            Utils.ExibirComoTabela(marcas);
        }

        public async Task Update()
        {
            await Read();
            string nome = Utils.ReadFromConsole("Digite o nome da marca: ");
            Marca antigo = await _repository.GetByName(nome);

            Marca novaMarca = new Marca
            {
                Id = antigo.Id,
                Nome = Utils.ReadFromConsole($"Digite o novo nome para {antigo.Nome}"),
            };
            await _repository.Update(novaMarca);


        }
    }
}
