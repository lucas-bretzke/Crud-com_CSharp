using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public interface IControllerBase
    {
        public  Task Create();
        public Task Read();
        public Task Update();
        public Task Delete();
    }
}
