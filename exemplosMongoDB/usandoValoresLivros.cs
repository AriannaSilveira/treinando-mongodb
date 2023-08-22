using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class usandoValoresLivros
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

            Livro livro = new Livro();
            livro = valoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura brasileira");
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);
            Livro livro2 = new Livro();
            livro2 = valoresLivro.incluiValoresLivro("A arte da ficção", "David Lodge", 2002, 230, "Didático, Auto ajuda");
            await conexaoBiblioteca.Livros.InsertOneAsync(livro2);

            Console.WriteLine("Documento incluído!");


        }
    }
}
