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

                Console.Clear();
                Console.WriteLine("Deseja cadastrar, acessar ou excluir uma conta?");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "cadastrar":
                        Actions.Register();
                        break;
                    case "acessar":
                        Console.WriteLine("Digite o CPF do usuário da conta que deseja acessar:");
                        long cpf = long.Parse(Console.ReadLine());
                        Console.WriteLine("Digite sua senha:");
                        string password = Console.ReadLine();
                        Actions.Access(cpf, password);
                        break;
                    case "excluir":
                        Console.WriteLine("Digite o ID do usuário da conta que deseja acessar:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite sua senha:");
                        password = Console.ReadLine();
                        Actions.Delete(id, password);
                        break;
                    default:
                        Console.WriteLine("Comando Inválido");
                        break;
                }

                Console.WriteLine("Deseja encerrar o atendimento?(s/n)");
                char simOuNao = char.Parse(Console.ReadLine());
                if (simOuNao == 'n')
                {
                    continueExecution = true;
                }
                else
                {
                    continueExecution = false;
                }

            }
        }
    }
}
