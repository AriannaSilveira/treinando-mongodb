using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class alterandoDocumentoClasse
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

            Console.WriteLine("Procurando e alterar Documento Dom Casmurro...");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Dom Casmurro");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
                
            }

            Console.WriteLine("");
            Console.WriteLine("");


            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
            await conexaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);

            Console.WriteLine("");
            Console.WriteLine("Registro alterado!");
            Console.WriteLine("");

            Console.WriteLine("Procurando Documento Dom Casmurro...");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Dom Casmurro");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());

            }


        }
    }
}
