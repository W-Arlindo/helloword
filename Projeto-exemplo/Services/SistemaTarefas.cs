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
        int id=0;

        foreach(Tarefa tarefa in tarefas)
        {
            if (tarefa.Id >= id)
            {
                id=tarefa.Id +1;
            }
        }

        adicionarlista(new Tarefa(id,MenuTarefas.ReceberTitulo(), MenuTarefas.ReceberDescricao()));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }

    //Listar tarefas
    public void ListarTarefas()
    {
        Console.WriteLine("= = = Lista de Tarefas = = =");
        foreach(Tarefa tarefa in tarefas)
        {
            Console.WriteLine($"Id: {tarefa.Id}");
            Console.WriteLine($"Tarefa: {tarefa.Titulo}\n");
            Console.WriteLine($"Descricao: \n{tarefa.Descricao}");
            
        }
    }
}