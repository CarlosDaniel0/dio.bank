using System;
using System.Globalization;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private TipoPessoa TipoPessoa {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        public Conta(TipoPessoa tipoPessoa,TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoPessoa = tipoPessoa;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) 
        {  
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1)) 
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) {
            if (this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString() 
        {

            string Resposta = $" {this.TipoPessoa.ToString().PadLeft(7).PadRight(9)}| {this.TipoConta.ToString().PadLeft(7).PadRight(9)}| {this.Nome.PadRight(29)}| R$ {this.Saldo.ToString("N2", new CultureInfo("pt-BR")).PadLeft(7).PadRight(11)}| R$ {this.Credito.ToString("N2", new CultureInfo("pt-BR")).PadLeft(7).PadRight(11)}";    
            return Resposta;
        }
    }
}