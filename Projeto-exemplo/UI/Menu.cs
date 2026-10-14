using System;
using Tarefas.Services;

namespace Tarefas.UI;

class MenuSistemaTarefas
{
    public string ReceberTitulo()
    {
        Console.Write("Titulo da tarefa: ");
        return Console.ReadLine();
    }
    public string ReceberDescricao()
    {
        Console.Write("Descricao: ");
        return Console.ReadLine();
    }
    public int ReceberId()
    {
        Console.WriteLine("Id Tarefa: ");
        return int.Parse(Console.ReadLine());
    }
    public string Conclusao()
    {
        Console.Write("Concluir Tarefa: (s y/n)");
        return Console.ReadLine();
    }
    public string EditarTitulo()
    {
        Console.Write("Editar Titulo: (s y/n)");
        return Console.ReadLine();
    }
}

class Menu
{
    Sistema starefas = new();

    bool programa=true;
    
    void menu()
    {        
        int op;

        Console.WriteLine("= = = Menu Tarefas = = =");
        Console.WriteLine("1 - Cadastra Tarefa");
        Console.WriteLine("2 - Listar Tarefas");
        Console.WriteLine("3 - Buscar Tarefa");
        Console.WriteLine("4 - Editar Tarefa");
        Console.WriteLine("5 - Excluir Tarefa");
        Console.WriteLine("6 - Marca Tarefa Concluida");
        Console.WriteLine("0 - Sair");

        if(!int.TryParse(Console.ReadLine(), out op))
        {
            throw new ArgumentException("Opcao invalida");
        }
        switch (op)
        {
            case 1:
                starefas.CadastrarTarefas();
            break;
            case 2:
                starefas.ListarTarefas();
            break;
            case 3:
                starefas.BuscarTarefas();
            break;
            case 4:
                starefas.EditarTarefa();
            break;
            case 5:
                starefas.ExcluirTarefa();
            break;
            case 6:
                starefas.ConcluirTarefa();
            break;
            case 0:
                programa=false;
            break;
        }
    }
    public bool __init__()
    {
        menu();
        return programa;
    }
}