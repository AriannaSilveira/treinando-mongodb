using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class listandoDocumentosFiltroBson
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {

            var conexaoBiblioteca = new conectandoMongoDB();
            Console.WriteLine("Listando Documentos...");

            var filtro = new BsonDocument();
            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista.");

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Autor = Machado de Assis...");

            filtro = new BsonDocument
            {
                {"Autor", "Machado de Assis" }
            };

            listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista.");


        }
    }
}
