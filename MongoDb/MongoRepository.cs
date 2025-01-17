using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb___Workshop
{
    public class MongoRepository <T> where T : class
    
    {
        private readonly IMongoCollection<T> _collection;
        public MongoRepository(string collectioName) {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var settings = MongoClientSettings.FromConnectionString(configuration.GetConnectionString("MongoDbConnection"));
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);
            var database = client.GetDatabase("LucasBretzke");
            _collection = database.GetCollection<T>(collectioName);
        }   
        
        public async Task InsertAsync(T entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
                Console.WriteLine("Documento inserido com sucesso!");
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<T>> FindAsync (FilterDefinition<T> filter)
        {

            try
            {
                return await _collection.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }

        }

        public async Task UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
                var result = await _collection.UpdateOneAsync(filter, update);
                if (result.ModifiedCount > 0)
                {
                    Console.WriteLine("Documento atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Documento para atualizar não foi econtrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(FilterDefinition<T> filter)
        {
            try
            {
                await _collection.DeleteOneAsync(filter);
                var result  = await _collection.DeleteManyAsync(filter);
                if (result.DeletedCount > 0)
                {
                    Console.WriteLine("Documento Deletado");
                }
                else
                {
                  Console.WriteLine($"Nenhum documento deletado");
                }
            }
            catch (Exception ex) { 
            Console.WriteLine($"{ex.Message}");
            }      
        }

    }
}
