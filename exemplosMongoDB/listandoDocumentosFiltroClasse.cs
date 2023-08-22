using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class listandoDocumentosFiltroClasse
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
            
            Console.WriteLine("Listando Documentos Autor = Machado de Assis...");

            var filtro = new BsonDocument
            {
                {"Autor", "Machado de Assis" }
            };

            var listaLivros = await conexaoBiblioteca.Livros.Find(filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da lista.");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Autor = Machado de Assis - classe...");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Ano maior ou igual a 1999...");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Ano a partir de 1999 e mais de 300 páginas...");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos somente de Ficção Científica...");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.AnyEq(x => x.Assunto, "Ficção Científica");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }




        }
    }
}
