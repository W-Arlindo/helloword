using System;
using MYAPI.Models;

namespace MYAPI.UI;

class MenuSistemaAgiota
{
    Cliente c = new Cliente("menu", 1,1);


    internal object Listar(Emprestimo c){
        return new{
            Numero = c.Numero,
            Nome = c.Cliente.Nome,
            Valor = c.Cliente.Valor,
            Juros = c.Cliente.Juros,
            DataEmprestimo = c.DataEmprestimo.ToString("dd/MM/yyyy"),
            DataVencimento = c.DataVencimento.ToString("dd/MM/yyyy")
            };
    }

}