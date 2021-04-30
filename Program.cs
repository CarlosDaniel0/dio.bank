using System;
using System.Collections.Generic;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        
        private static void InserirConta() 
        {
            Console.WriteLine();
            Console.WriteLine("======== Inserir nova conta ========");

            Console.WriteLine("Escolha uma Natureza");
            Console.WriteLine("\t1 - Física\n\t2 - Jurídica");
            Console.Write("Sua Opção: ");
            int entradaTipoPessoa = int.Parse(Console.ReadLine());

            int entradaTipoConta = 2;
            if (entradaTipoPessoa != 2)
            {
                Console.WriteLine("Escolha um Tipo de Conta");
                Console.WriteLine("\t1 - Poupança\n\t2 - Corrente\n\t3 - Poupança + Corrente\n\t4 - Salário");
                Console.Write("Sua Opção: ");
                entradaTipoConta = int.Parse(Console.ReadLine());
            }
            
            Console.Write("Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Saldo inicial: R$ ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            double entradaCredito = 0;
            if (entradaTipoConta == 2 || entradaTipoConta == 3 || entradaTipoConta == 4)
            {
                Console.Write("Crédito: R$ ");
                entradaCredito = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Conta novaConta = new Conta(
                tipoPessoa: (TipoPessoa)entradaTipoPessoa,
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo, 
                credito: entradaCredito, 
                nome: entradaNome);
            double.IsNegative(-43);
            listaContas.Add(novaConta);

        }

        public static void ListarContas() 
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t----------- Listar contas -----------");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("+---------------------------+");
                Console.WriteLine("| Nenhuma conta cadastrada. |");
                Console.WriteLine("+---------------------------+");
            }

            Console.WriteLine("+---+----------+----------+------------------------------+---------------+---------------+");
            Console.WriteLine("| # |  Pessoa  |   Conta  |             Nome             |     Saldo     |    Crédito    |" );
            for (int i = 0; i < listaContas.Count; i++) {
                Conta conta = listaContas[i];
                Console.WriteLine("| {0} |{1}|", i, conta);
                
            }
            Console.WriteLine("+---+----------+----------+------------------------------+---------------+---------------+");
            Console.WriteLine();
            Console.WriteLine("Aperte Qualquer tecla para continuar...");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.WriteLine();
            Console.WriteLine("----------- Sacar ------------");

            Console.Write("Número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor Sacado: R$");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine();
            Console.WriteLine("---------- Depositar -----------");
            Console.Write("Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Valor do Depósito: R$ ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

 
        private static void Transferir()
        {
            Console.Write("Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Valor da Transferência: R$");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    InserirConta();
                    break;
                    case "2":
                    ListarContas();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    Sacar();
                    break;
                    case "5":
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }
                opcaoUsuario = ObterOpcaoUsuario();
            } 
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("+--------- DIO Bank --------+");
            Console.WriteLine("| Informe a opção desejada: |");

            Console.WriteLine("| 1 - Inserir nova conta    |");
            Console.WriteLine("| 2 - Listar contas         |");
            Console.WriteLine("| 3 - Transferir            |");
            Console.WriteLine("| 4 - Sacar                 |");
            Console.WriteLine("| 5 - Depositar             |");
            Console.WriteLine("| C - Limpar Tela           |");
            Console.WriteLine("| X - Sair                  |");
            Console.WriteLine("+---------------------------+");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

// Personalizar em breve
