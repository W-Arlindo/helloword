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
            Console.WriteLine("Tarefas concluida!!");
            foreach(Tarefa tarefa in tarefas)
            {
                if (tarefa.Concluida)
                {
                    Console.WriteLine($"\nId: {tarefa.Id}");
                    Console.WriteLine($"Tarefa: {tarefa.Titulo}\n");
                }
            }
            Console.WriteLine("Tarefas pendentes");
            foreach(Tarefa tarefa in tarefas)
            {
                if (!tarefa.Concluida)
                {
                    Console.WriteLine($"\nId: {tarefa.Id}");
                    Console.WriteLine($"Tarefa: {tarefa.Titulo}\n");
                }
            }
        }
    }
    
    //Buscar Tarefas pelo id
    public int BuscarTarefas()
    {
        ListarTarefas();

        Tarefa tarefa=null;
        Console.WriteLine("");
        int id = MenuTarefas.ReceberId();

        Console.WriteLine("= = = Tarefa = = =");
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
        return id;
    }

    //concluir tarefa
    public void ConcluirTarefa()
    {
        int id = BuscarTarefas();

        Console.WriteLine("= = = Concluir Tarefa = = =");
        if((MenuTarefas.Conclusao().ToLower()[0]=='y'|| MenuTarefas.Conclusao().ToLower()[0] == 's')){
            foreach (Tarefa _ in tarefas)
            {
                _.ConcluirTarefa();
            }
        }
    }
}