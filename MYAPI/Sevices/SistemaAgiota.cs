using System;
using System.Xml.Linq;
using MYAPI.Models;

namespace MYAPI.Services;

class SistemaAgiota
{
    private List<Emprestimo> emprestimos;

    public SistemaAgiota()
    {
        TrazerDados entradaarquivo = new();
        
        emprestimos = entradaarquivo.BuscarArquivo();

    }

    //Listar Emprestimos
    internal List<Emprestimo> ListarEmprestimo()
    {
        //enviando lista dos emprestimo 
        return emprestimos;
    }

    //add a lista
    internal void CadastrarCliente(string nome,decimal valor, decimal juros)
    {
        Cliente cliente = new Cliente(nome,valor,juros);
        emprestimos.Add(new Emprestimo(cliente));

    }

    //buscar emprestimo pelo id
    internal Emprestimo? Buscar(int id, out string erro)
    {
        //percorrendo lista de emprestimo
        foreach(Emprestimo emprestimo in emprestimos)
        {
            //verificando id de cada emprestimo
            if (emprestimo.Id == id)
            {
                erro = "";
                return emprestimo;
            }
        }
    erro ="Emprestimo nao encontrado";
    return null;
    }

    //Tirar emprestimo da lista
    internal void RiscarNome(Emprestimo emprestimo, out string erro)
    {

        switch (emprestimo.Status)
        {
            case Emprestimo.StatusPagamento.Pago:
                emprestimos.Remove(emprestimo);   
                erro = "";
            break;

            default:
                erro = "Erro ao remover emprestimo";
                return;
        }
        
    }

    //Quitou a divida completa
    internal void DividaPaga(Emprestimo emprestimo, out string erro)
    {
        switch (emprestimo.Status)
        {
            case Emprestimo.StatusPagamento.Pago:
                erro = "Divida ja paga";
            break;
            default:
                emprestimo.QuitouDivida(out erro);
                break;
        }
    }
    
    //enviar arquivo
    internal void EnviarArquivo()
    {
        EnviarArquivo enviarArquivo = new();

        enviarArquivo.Enviar(emprestimos);

    }
    
}



