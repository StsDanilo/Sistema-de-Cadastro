using SistemaDeCadastroDeUsuarios.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaDeCadastroDeUsuarios.Services
{
    static class Actions
    {
        static List<User> RegisteredUsers = new List<User>();

        public static void Register()
        {
            Console.Clear();
            string name = "";
            string cpf = "";
            string email = "";
            DateTime dateOfBirth = new DateTime();
            string password = "";

            bool passInTest = false;

            while (!passInTest)
            {
                Console.WriteLine("Nome completo do usuário:");
                name = Console.ReadLine();
                passInTest = DataProcessing.NameVerification(name);
                if (!passInTest) { Console.WriteLine("Nome inválido"); }
            }
            passInTest = false;

            while (!passInTest)
            {
                Console.WriteLine("Data de nascimento:");
                dateOfBirth = DateTime.Parse(Console.ReadLine());
                passInTest = DataProcessing.DateVerification(dateOfBirth);
                if (!passInTest) { Console.WriteLine("Data inválida ou usuário menor de idade"); }
            }
            passInTest = false;

            while (!passInTest)
            {
                Console.WriteLine("Email:");
                email = Console.ReadLine();
                passInTest = DataProcessing.EmailVerification(email);
                if (!passInTest) { Console.WriteLine("Email inválido"); }
            }
            passInTest = false;

            while (!passInTest)
            {
                Console.WriteLine("CPF:");
                cpf = Console.ReadLine();
                passInTest = DataProcessing.CPFVerification(cpf);
                foreach (User thisUser in RegisteredUsers)
                {
                    if (thisUser.Cpf == DataProcessing.CpfSimplyfier(cpf))
                    {
                        passInTest = false;
                    }
                }
                if (!passInTest) { Console.WriteLine("CPF inválido ou já cadastrado"); }
            }
            passInTest = false;

            while (!passInTest)
            {
                Console.Clear();
                Console.WriteLine("Senha:");
                string senha = Console.ReadLine();
                Console.WriteLine("Confirme sua Senha:");
                string senha2 = Console.ReadLine();
                if (senha != senha2)
                {
                    Console.WriteLine("A senha não foi confirmada");
                    Console.ReadLine();

                }
                else if (DataProcessing.PasswordVerification(senha))
                {
                    password = senha;
                    passInTest = true;
                }
                else
                {
                    Console.WriteLine("A senha precisa ter no mínimo 8 dígitos");
                    Console.WriteLine("Sendo eles pelo menos 1 letra maiúscula, 1 minúscula e 1 número");
                    Console.ReadLine();
                }
            }


            string firstName = name.Substring(0, name.IndexOf(" "));
            User user = new User(firstName, name, email, password, DataProcessing.CpfSimplyfier(cpf), dateOfBirth);
            string path = @"E:\.Visual Studio Code Geral\CursoUdemy\C#\SistemaDeCadastroDeUsuarios/database.txt";
            try
            {
                if (File.Exists(path))
                {
                    File.AppendAllText(path, user.ToString() + Environment.NewLine);
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Banco de dados não encontrado");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }


        internal static void InitializeDatabase()
        {
            string path = @"E:\.Visual Studio Code Geral\CursoUdemy\C#\SistemaDeCadastroDeUsuarios/database.txt";
            try
            {
                foreach (string s in File.ReadAllLines(path))
                {
                    string[] line = s.Split(';');
                    User user = new User(line[0], line[1], line[2], line[3], long.Parse(line[4]), int.Parse(line[6]), DateTime.Parse(line[5]));
                    RegisteredUsers.Add(user);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }

        internal static void Access(long cpf, string password)
        {
            bool userFounded = false;
            foreach (User user in RegisteredUsers)
            {
                if (cpf == user.Cpf && password == user.Password)
                {
                    user.PrintInfo();
                    userFounded = true;
                    break;
                }
            }
            if (!userFounded)
            {
                Console.WriteLine("Dados incorretos ou usuário inexistente");
            }
        }

        internal static void Delete(int id, string password)
        {
            bool userFounded = false;
            string path = @"E:\.Visual Studio Code Geral\CursoUdemy\C#\SistemaDeCadastroDeUsuarios/database.txt";
            for (int i = 0; i < RegisteredUsers.Count; i++)
            {
                if (id == RegisteredUsers[i].Id && password == RegisteredUsers[i].Password)
                {
                    RegisteredUsers.RemoveAt(i);
                    if (RegisteredUsers != null)
                    {
                        File.WriteAllText(path, string.Empty);
                        foreach(User user in RegisteredUsers)
                        {
                            File.AppendAllText(path, user.ToString() + Environment.NewLine);
                        }
                    }
                    userFounded = true;
                    Console.WriteLine("Usuário excluído com sucesso");
                    break;
                }
            }
            if (!userFounded)
            {
                Console.WriteLine("Dados incorretos ou usuário inexistente");
            }

        }
    }
}

