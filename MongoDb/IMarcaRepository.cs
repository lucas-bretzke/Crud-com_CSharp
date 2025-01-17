using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    internal interface IMarcaRepository
    {
        public Task<Marca> Insert(Marca marca);

        public Task<Marca> Update(Marca marca);

        public Task Delete(string nomeMarca);

        public Task<List<Marca>> Read();

        public Task<Marca> GetByName(string nomeMarca);
    }
}
