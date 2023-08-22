using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class listandoDocumentosOrdem
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

            Console.WriteLine("Listando Documentos Paginas > 100...");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gt(x => x.Paginas, 100);

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            
        }
    }
}
