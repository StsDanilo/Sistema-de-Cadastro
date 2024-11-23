using SistemaDeCadastroDeUsuarios.Entities;
using SistemaDeCadastroDeUsuarios.Services;

namespace SistemaDeCadastroDeUsuarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deseja cadastrar, acessar ou excluir uma conta?");
            string command = Console.ReadLine().ToLower();

            switch(command)
            {
                case "cadastrar":
                    Actions.Register();
                    break;
                case "acessar":

                    break;
                case "excluir:":

                    break;
                default:
                    Console.WriteLine("Comando Inválido");
                    break;
            }
        }
    }
}
