using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastroDeUsuarios.Services
{
    static class DataProcessing
    {
        public static bool NameVerification(string name)
        {
            //checar se o nome já foi registrado
            if (name.Length > 1 && name.Contains(" "))
            {
                return true;
            }
            return false;
        }

        public static bool EmailVerification(string email)
        {
            //checar se já foi registrado
            //checar se tem @ e .com
            if (email != null && email.Contains('@') && email.Contains(".com"))
            {
                return true;
            }
            return false;
        }

        public static bool DateVerification(DateTime date)
        {
            //checar se tem mais que 18 anos
            DateTime today = DateTime.Today;
            int idade = today.Year - date.Year;
            if (date > today.AddYears(-idade))
            {
                idade--;
            }
            return idade >= 18;


        }

        public static bool CPFVerification(string cpf)
        {
            
            if (CpfSimplyfier(cpf).ToString().Length == 11)
            {
                return true;
            }
            return false;
        }

        public static bool PasswordVerification(string password)
        {
            //verifica se tem 8 dígitos, pelo menos 1 letra maiúscula, 1 minúscula e 1 número
            if (password.Length >= 8 && password.Any(Char.IsUpper) && password.Any(Char.IsLower) && password.Any(Char.IsNumber))
            {
                return true;
            }
            return false;
        }

        public static int GenerateId()
        {
            Random rnd = new Random();
            int id = rnd.Next(100000, 999999);
            //conferir se o id n é repetido, se for gerar outro até n ser
            return id;
        }

        public static long CpfSimplyfier(string cpf)
        {
            cpf.Replace(".", "");
            cpf.Replace("-", "");
            return long.Parse(cpf);
        }
    }
}
