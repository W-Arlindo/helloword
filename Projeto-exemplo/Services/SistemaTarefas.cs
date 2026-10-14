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
        if(0 == tarefas.Count)
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
        }
        if (tarefa==null)
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
        char c;

        Console.WriteLine("= = = Concluir Tarefa = = =");
        c =MenuTarefas.Conclusao().ToLower()[0];
        if(c=='y'|| c == 's'){
            foreach (Tarefa _ in tarefas)
            {
                if(id == _.Id)
                {
                    _.ConcluirTarefa();
                }
            }
        }
    }

    //Editar tarefas
    public void EditarTarefa()
    {
        char e;

        int id = BuscarTarefas();
        Console.WriteLine("= = = Editar Tarefa = = ="); 

        e=MenuTarefas.EditarTitulo().ToLower()[0];
        if(e=='y'|| e == 's')
        {
            foreach(Tarefa tarefa in tarefas)
            {
                if (id == tarefa.Id)
                {
                    tarefa.EditarTitulo(MenuTarefas.ReceberTitulo());
                }
            }
        }

        e=MenuTarefas.EditarTitulo().ToLower()[0];
        if(e=='y'|| e == 's')
        {
            foreach(Tarefa tarefa in tarefas)
            {
                if (id == tarefa.Id)
                {
                    tarefa.EditarDescricao(MenuTarefas.ReceberDescricao());
                }
            }
        }
        
        Console.WriteLine("\nEdicao concluida");
    }

    //Excluir tarefa
    public void ExcluirTarefa()
    {
        int id = BuscarTarefas();

        foreach(Tarefa tarefa in tarefas)
        {
            if(id == tarefa.Id)
            {
                tarefas.Remove(tarefa);
                Console.WriteLine("\nRemovida com sucesso\n");
            }
        }
    }
}