using System;
using Tarefas.Models;
using Tarefas.UI;

namespace Tarefas.Services;

class Sistema
{
    MenuSistemaTarefas MenuTarefas = new();

    List<Tarefa> tarefas = new();

    public void CadastrarTarefas()
    {
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
}