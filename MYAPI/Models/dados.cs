using System;

namespace MYAPI.Models;

class Cliente
{
    public string? Nome { get; private set; }
    public decimal Valor { get; private set; }
    public decimal Juros { get; private set; }

    public Cliente(string? nome, decimal valor, decimal juros)
    {
        Nome=nome;
        Valor=valor;
        Juros=juros;
    }

    //Verificar Nome
    public bool VerificarNome(string? n, out string erro)
    {
        //ver se e um spaco ou null
        if (string.IsNullOrWhiteSpace(n))
        {
            erro = "Digite algum nome";
            return false;
        }
        //ver se e numero
        else if(double.TryParse(n, out double _)){
            erro = "Nome nao pode ser apenar numero";
            return false;
        }
        //Retorna verificacao
        else
        {
            erro = "";
            return true;
        }
    }

    //Verificar Numero
    public bool VerificarNumero(string? v)
    {
        //Verifica se e null ou spaco
        if(string.IsNullOrWhiteSpace(v)){
            return false;
        }
        //Verificar se letra
        else if (!decimal.TryParse(v, out decimal n))
        {
            return false;
        }
        //verifica se e meno ou igual a 0
        else if(n<=0)
        {
            return false;
        }
        //retornar verificao
        else{
            return true;
        }
    }

    public void AlterarNome(string? n, out string erro)
    {
        if (VerificarNome(n, out erro))
        {
            Nome = n;
        }
        else{

            return;
        }
    }
}