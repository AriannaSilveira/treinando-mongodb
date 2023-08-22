using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class acessandoMongoDB
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var doc = new BsonDocument
            {
                {"Título", "Guerra dos Tronos" }
            };
            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);

            //Acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //Acesso ao banco de dados
            IMongoDatabase bancosDados = cliente.GetDatabase("Biblioteca");

            //Acesso à coleção
            IMongoCollection<BsonDocument> colecao = bancosDados.GetCollection<BsonDocument>("Livros");

            //Incluindo documento
            await colecao.InsertOneAsync(doc);
            Console.WriteLine("Documento incluído!");


        }
    }
}
