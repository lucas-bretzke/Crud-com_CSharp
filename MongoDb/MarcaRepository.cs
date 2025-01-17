using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public class MarcaRepository : IMarcaRepository
    {

        private MongoRepository<Marca> _mongo;

        public MarcaRepository()
        {
            _mongo = new MongoRepository<Marca>("Marcas");
        }
        public async Task Delete(string nomeMarca)
        {
            var filter = Builders<Marca>.Filter.Eq(q => q.Nome, nomeMarca);
            await _mongo.DeleteAsync(filter);
        }

        public async Task<Marca> GetByName(string nomeMarca)
        {
            var filter = Builders<Marca>.Filter.Eq(p => p.Nome, nomeMarca);
            List<Marca> marcas = await _mongo.FindAsync(filter);
            return marcas.FirstOrDefault();
        }

        public async Task<Marca> Insert(Marca marca)
        {
            await _mongo.InsertAsync(marca);
            return marca;
        }

        public async Task<List<Marca>> Read()
        {
            var filtro = Builders<Marca>.Filter.Empty;
            return await _mongo.FindAsync(filtro);
        }

        public async Task<Marca> Update(Marca marca)
        {
            var filtro = Builders<Marca>.Filter.Eq(marca => marca.Id, marca.Id);
            var update = Builders<Marca>.Update.Set(p => p.Nome, marca.Nome);
            await _mongo.UpdateAsync(filtro, update);
            return marca;
        }
    }
}
