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
}