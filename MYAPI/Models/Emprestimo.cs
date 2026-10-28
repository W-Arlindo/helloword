using System;

namespace MYAPI.Models;

class Emprestimo
{
    public static int Caderno { get; private set; } = 0;

    public enum StatusPagamento { Pendente, Reagendado, Pago }

    public int Numero { get; private set; }
    public Cliente Cliente { get; private set; }
    public StatusPagamento Status { get; private set; }
    public DateTime DataEmprestimo {get; private set;}
    public DateTime DataVencimento {get; private set;}
    public int MesesReagendado{get; private set;}

    public Emprestimo(Cliente cliente)
    {
        Caderno++;
        Numero = Caderno;
        Cliente = cliente;
        Status = StatusPagamento.Pendente;
        DataEmprestimo = DateTime.Now;
        DataVencimento = DataEmprestimo.AddMonths(1);
        
    }

    public void JurosPago(List<Emprestimo> emprestimos, out string erro){
        switch(Status){
            case StatusPagamento.Pendente:
                MesesReagendado++;
                Status = StatusPagamento.Reagendado;
                DataVencimento = DataVencimento.AddMonths(1);
                Console.WriteLine("Primeiro reagendamento");
                erro ="";
            break;

            case StatusPagamento.Pago:
                erro = "Juros ja foi pago"; 
            break;
            
            case StatusPagamento.Reagendado:
                MesesReagendado++;
                DataVencimento = DataVencimento.AddMonths(1);
                Console.WriteLine($"Vai para o {MesesReagendado}Mês");
                erro ="";
            break;

            default:
                erro ="ERRO INESPERADO";
            break;
        }

        OrganizarLista(emprestimos);

    }

    public void OrganizarLista(List<Emprestimo> emprestimos)
    {
        int i=1;
        foreach(var e in emprestimos)
        {
            if (e.Numero!=i)
            {
                e.AddNumero($"{i}");
            }

            i++;
        }
    }

    public decimal CalcularJuros(){
        
        return Cliente.Valor * Cliente.Juros;
    }
   
    public void QuitouDivida(out string erro)
    {
        switch (Status)
        {
            case Emprestimo.StatusPagamento.Pago:
                erro = "Divida ja paga";
            break;

            default:
                erro="";
                Status = Emprestimo.StatusPagamento.Pago;
                Cliente.AddValor("0");Cliente.AddJuros("0");
            break;
        }
    }

    public void AddNumero(string numero){
        Numero = int.Parse(numero);
    }
    public void AddStatus(string status){
        if (status == StatusPagamento.Pendente.ToString()){
            Status = StatusPagamento.Pendente;
        }
        else if(status == StatusPagamento.Pago.ToString()){
            Status = StatusPagamento.Pago;
        }
        else if(status == StatusPagamento.Reagendado.ToString()){
            Status = StatusPagamento.Reagendado;
        }
    }
    public void AddDataEmprestimo(string DataE){
        DataEmprestimo = DateTime.Parse(DataE);
    }
    public void AddDataVencimento(string DataV){
        DataVencimento = DateTime.Parse(DataV);
    }
    public void AddMesReagendado(string MesR){
        MesesReagendado = int.Parse(MesR);
    }
}