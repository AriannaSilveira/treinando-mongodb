using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class excluindoDocumento
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

            Console.WriteLine("Procurando Documentos de Machado de Assis...");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }
            Console.WriteLine("Fim");
            Console.WriteLine("");
            Console.WriteLine("");

            await conexaoBiblioteca.Livros.DeleteManyAsync(condicao);

            Console.WriteLine("");
            Console.WriteLine("Registro alterado!");
            Console.WriteLine("");

            Console.WriteLine("Procurando Documento  de Machado de Assis...");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Dom Casmurro");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }
            Console.WriteLine("Fim");


        }
    }
}
