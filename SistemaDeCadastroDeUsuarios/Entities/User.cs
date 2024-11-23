using SistemaDeCadastroDeUsuarios.Services;
using System.Text;

namespace SistemaDeCadastroDeUsuarios.Entities
{
    internal class User
    {
        public string FirstName { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public long Cpf { get; private set; }
        public int Id { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public User(string firstName, string fullName, string email, string password, long cpf, DateTime dateOfBirth)
        {
            FirstName = firstName;
            FullName = fullName;
            Email = email;
            Password = password;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
            Id = DataProcessing.GenerateId();

        }

        public User(string firstName, string fullName, string email, string password, long cpf, int id, DateTime dateOfBirth)
        {
            FirstName = firstName;
            FullName = fullName;
            Email = email;
            Password = password;
            Cpf = cpf;
            Id = id;
            DateOfBirth = dateOfBirth;
        }

        public void PrintInfo()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo " + FirstName);
            Console.WriteLine();
            Console.WriteLine("Nome: " +  FullName);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("CPF: " + Cpf);
            Console.WriteLine("Data de Nascimento: " + DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("ID: " + Id);
        }

        public override string ToString()
        {
            return $"{FirstName};{FullName};{Email};{Password};{Cpf};{DateOfBirth.ToString("dd/MM/yyyy")};{Id}";
        }
    }
}
