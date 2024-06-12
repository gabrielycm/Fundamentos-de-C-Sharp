using System.Text.RegularExpressions;

namespace ConsoleApp;

public class Exercicios
{

    enum TipoOperacaoMatematica
    {  
       soma,
       multiplicar,
       subtrair,
       dividir,
       media
    }

    public void sejaBemVindo ()
    {
        Console.WriteLine("Digite seu nome");
        var nome = Console.ReadLine();
        Console.WriteLine($"Olá, {nome}! Seja muito bem-vindo!");
    }

    public void NomeSobrenome()
    {
        Console.WriteLine("Digite seu nome");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite seu Sobrenome");
        var sobrenome = Console.ReadLine();
        Console.WriteLine($"Olá, {nome} {sobrenome}! Seja muito bem-vindo!");
    }

    static double Soma(double a, double b)
    {
        return a + b;
    }

    static double Multiplicar(double a, double b)
    {
        return a * b;
    }

    static double Subtrair(double a, double b)
    {
        return a - b;
    }

    static double Dividir(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Divisão por zero não é permitida.");
            return double.NaN; // Retorna "Not a Number" se a divisão por zero for tentada
        }
        return a / b;
    }

    static double Media(double a, double b)
    {
        return (a + b) / 2;
    }

    public void OperacoesMatematicas()
    {
        Console.WriteLine("Digite um numero");
        var valor1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Digite outro numero");
        var valor2 = double.Parse(Console.ReadLine());
        Console.WriteLine($"Valores fornecidos: {valor1}, {valor2}");
        
        var dicionario = new Dictionary<TipoOperacaoMatematica, Func<double, double, double>>
            {
                {TipoOperacaoMatematica.soma, Soma},
                {TipoOperacaoMatematica.multiplicar, Multiplicar},
                {TipoOperacaoMatematica.subtrair, Subtrair},
                {TipoOperacaoMatematica.dividir, Dividir},
                {TipoOperacaoMatematica.media, Media}
            };

        Console.WriteLine("Digite a operação desejada (soma, multiplicar, subtrair, dividir, media):");
        var operacaoStr = Console.ReadLine();

        if (Enum.TryParse(operacaoStr, true, out TipoOperacaoMatematica operacao) && dicionario.TryGetValue(operacao, out var funcao))
        {
            var resultado = funcao(valor1, valor2);
            Console.WriteLine($"Resultado da operação {operacao}: {resultado}");
        }
    }

    public void ContadorCaracteres()
    {
        Console.WriteLine("Digite uma ou mais palavras");
        var valor1 = Console.ReadLine();
        Console.WriteLine($"Você digitou {valor1.Length}");

    }

    public void PlacaValida()
    {
        Console.WriteLine("Digite a placa do veículo");
        var input = Console.ReadLine();

        if (input.Length == 7 && Regex.IsMatch(input, @"^[a-zA-Z]{3}\d{4}$"))
        {
            Console.WriteLine("Verdadeiro");
        }
        else
        {
            Console.WriteLine("Falso");
        }
    }

    public static void ExibirData()
    {
        DateTime agora = DateTime.Now;

        Console.WriteLine("Escolha o formato desejado:");
        Console.WriteLine("1. Formato completo");
        Console.WriteLine("2. Apenas a data (dd/mm/yyyy)");
        Console.WriteLine("3. Apenas a hora (HH:mm:ss)");
        Console.WriteLine("4. Data com o mês por extenso");

        Console.Write("Opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("Formato completo: " + agora.ToString("F"));
                break;
            case "2":
                Console.WriteLine("Apenas a data (dd/mm/yyyy): " + agora.ToString("dd/MM/yyyy"));
                break;
            case "3":
                Console.WriteLine("Apenas a hora (HH:mm:ss): " + agora.ToString("HH:mm:ss"));
                break;
            case "4":
                Console.WriteLine("Data com o mês por extenso: " + agora.ToString("dd 'de' MMMM 'de' yyyy"));
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}
