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
        string titulo,descricao;

        titulo = MenuTarefas.ReceberTitulo();
        descricao = MenuTarefas.ReceberDescricao();

        foreach(Tarefa tarefa in tarefas)
        {
            if (tarefa.Id >= id)
            {
                id=tarefa.Id +1;
            }
        }

        adicionarlista(new Tarefa(id,titulo, descricao));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }
}