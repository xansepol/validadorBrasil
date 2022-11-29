using System.Text.RegularExpressions;
namespace validadorBrasil
{
    public static class StringExtensions
    {
        public static bool IsPlaca(this string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            return Regex.IsMatch(placa, Keys.REGEX_PLACA, RegexOptions.IgnoreCase);
        }

        public static bool IsCPF(this string cpf)
        {
            if(string.IsNullOrWhiteSpace(cpf) || !Regex.IsMatch(cpf, Keys.REGEX_CPF))
                return false;

            cpf = cpf.PadLeft(11, '0');

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            string tempCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCNPJ(this string cnpj)
        {
            if(string.IsNullOrWhiteSpace(cnpj) || !Regex.IsMatch(cnpj, Keys.REGEX_CNPJ))
                return false;

            cnpj = cnpj.PadLeft(14, '0')    ;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            string tempCnpj = cnpj.Substring(0, 12);

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
                
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

    }
}