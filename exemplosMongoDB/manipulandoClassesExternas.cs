using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class manipulandoClassesExternas
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {

            //Inicializar variável tipo objeto Livro
            Livro livro = new Livro();
            livro.Titulo = "Star Wars Legends";
            livro.Autor = "Timothy Zahn";
            livro.Ano = 2010;
            livro.Paginas = 245;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção científica");
            listaAssuntos.Add("Ação");
            livro.Assunto = listaAssuntos;

            ////Acesso ao servidor do MongoDB
            //string stringConexao = "mongodb://localhost:27017";
            //IMongoClient cliente = new MongoClient(stringConexao);

            ////Acesso ao banco de dados
            //IMongoDatabase bancosDados = cliente.GetDatabase("Biblioteca");

            ////Acesso à coleção
            //IMongoCollection<Livro> colecao = bancosDados.GetCollection<Livro>("Livros");

            //Acessando o banco de dados através da classe de conexão
            var conexaoBiblioteca = new conectandoMongoDB();

            //Incluindo documento
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);
            Console.WriteLine("Documento incluído!");


        }
    }
}
