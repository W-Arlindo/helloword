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
}