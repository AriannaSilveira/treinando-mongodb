using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class manipulandoClasses
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //var doc = new BsonDocument
            //{
            //    {"Título", "Guerra dos Tronos" }
            //};
            //doc.Add("Autor", "George R R Martin");
            //doc.Add("Ano", 1999);
            //doc.Add("Páginas", 856);

            //var assuntoArray = new BsonArray();
            //assuntoArray.Add("Fantasia");
            //assuntoArray.Add("Ação");
            //doc.Add("Assunto", assuntoArray);

            //Console.WriteLine(doc);

            //Inicializar variável tipo objeto Livro
            Livro livro = new Livro();
            livro.Titulo = "Sob a redoma";
            livro.Autor = "Stepahn King";
            livro.Ano = 2012;
            livro.Paginas = 679;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção científica");
            listaAssuntos.Add("Terror");
            listaAssuntos.Add("Ação");
            livro.Assunto = listaAssuntos;

            //Acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //Acesso ao banco de dados
            IMongoDatabase bancosDados = cliente.GetDatabase("Biblioteca");

            //Acesso à coleção
            IMongoCollection<Livro> colecao = bancosDados.GetCollection<Livro>("Livros");

            //Incluindo documento
            await colecao.InsertOneAsync(livro);
            Console.WriteLine("Documento incluído!");


        }
    }
}
