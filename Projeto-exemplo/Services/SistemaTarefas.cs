using System;
using Tarefas.Models;

namespace Tarefas.Services;

class Sistema
{
    MenuSistemaTarefas MenuTarefas = new();

    List<Tarefa> tarefas = new();

    public void CadastrarTarefas()
    {
        int id;
        string titulo,descricao;

        titulo = MenuTarefas.ReceberTitulo();
        descricao = MenuTarefas.ReceberDescricao();

        adicionarlista(new Tarefa(id,titulo, descricao));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }
}