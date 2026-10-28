using System;

namespace MYAPI.Models;

public record CadastrarCliente
{
    public string nome {get;set;} ="";
    public decimal valor {get;set;}
    public decimal juros {get;set;}
}
class Cliente
{
    public string? Nome { get; private set; }
    public decimal Valor { get; private set; }
    public decimal Juros { get; private set; }

    public Cliente(string? nome, decimal valor, decimal juros,out string erro)
    {
        if (VerificarNome(nome,out erro))
        {
            Nome = nome;
        }
        else{
            throw new ArgumentException("Nome invalido");
        }

        if (VerificarNumero(valor,out erro))
        {
            Valor = valor;
        }
        else
        {
            throw new ArgumentException("Valor invalido");
        }
        
        if (VerificarNumero(juros,out erro))
        {
            Juros = valor / 100;
        }
        else
        {
            throw new ArgumentException("Juros invalido");
        }
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
    public bool VerificarNumero(decimal v,out string erro)
    {
        //verifica se e meno ou igual a 0
        if(v<=0)
        {
            erro = "numero negativo x ";
            return false;
        }
        //retornar verificao
        else{
            erro = "";
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

    public void AlterarValor(decimal n,out string erro)
    {
        if (VerificarNumero(n,out erro))
        {
            Valor = n;
        }
        else{
            return;
        }
    }
}