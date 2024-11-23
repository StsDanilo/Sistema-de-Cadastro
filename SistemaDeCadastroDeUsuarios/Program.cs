using SistemaDeCadastroDeUsuarios.Entities;
using SistemaDeCadastroDeUsuarios.Services;

namespace SistemaDeCadastroDeUsuarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueExecution = true;
            while (continueExecution)
            {
                Actions.InitializeDatabase();

                Console.WriteLine("Deseja cadastrar, acessar ou excluir uma conta?");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "cadastrar":
                        Actions.Register();
                        break;
                    case "acessar":
                      //  Actions.Access();
                        break;
                    case "excluir:":

                        break;
                    default:
                        Console.WriteLine("Comando Inválido");
                        break;
                }

                Console.WriteLine("Deseja encerrar o atendimento?(s/n)");
                char simOuNao = char.Parse(Console.ReadLine());
                if (simOuNao == 'n')
                {
                    continueExecution = false;
                }
                else
                {
                    continueExecution = true;
                }

            }
        }
    }
}
