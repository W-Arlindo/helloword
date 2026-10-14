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
        string titulo,descricao;

        titulo = MenuTarefas.ReceberTitulo();
        descricao = MenuTarefas.ReceberDescricao();

        

        adicionarlista(new Tarefa(tarefas,titulo, descricao));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }
}