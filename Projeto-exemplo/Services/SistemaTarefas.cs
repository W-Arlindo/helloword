using System;
using Tarefas.Models;
using Tarefas.UI;

namespace Tarefas.Services;

class Sistema
{
    MenuSistemaTarefas MenuTarefas = new();

    List<Tarefa> tarefas = new();

    //Cadastrando tarefas
    public void CadastrarTarefas()
    {
        Console.WriteLine("= = = Criando Tarefas = = =");
        int id=1;

        

        adicionarlista(new Tarefa(tarefas,MenuTarefas.ReceberTitulo(), MenuTarefas.ReceberDescricao()));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }

    //Listar tarefas
    public void ListarTarefas()
    {
        Console.WriteLine("= = = Lista de Tarefas = = =");
        if(tarefas == null)
        {
            Console.WriteLine("Lista vazia!");
        }
        else
        {
            foreach(Tarefa tarefa in tarefas)
            {
                Console.WriteLine($"Id: {tarefa.Id}");
                Console.WriteLine($"Tarefa: {tarefa.Titulo}\n");
            }
        }
    }
    //Buscar Tarefas pelo id
    public void BuscarTarefas()
    {
        ListarTarefas();

        Tarefa tarefa=null;
        Console.WriteLine("");
        int id = MenuTarefas.ReceberId();

        Console.WriteLine("= = = Lista de Tarefas = = =");
        foreach (Tarefa t in tarefas)
        {
            if (id == t.Id)
            {
                tarefa = t;
            }
            else
            {
                id = 0;
            }
        }
        if (id == 0)
        {
            Console.WriteLine("Id invalido!");
        }
        else
        {
            Console.WriteLine($"Titulo: {tarefa.Titulo}");
            Console.WriteLine($"Descricao: \n{tarefa.Descricao}");
        }
    }
}