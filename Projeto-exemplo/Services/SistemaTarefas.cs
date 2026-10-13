using System;
using Tarefas.Models;

namespace Tarefas.Services;

class Sistema
{
    List<Tarefa> tarefas = new();
    public void CadastrarTarefas()
    {
        int id;
        string titulo,descricao;

        adicionarlista(new Tarefa(id,titulo, descricao));
    }
    void adicionarlista(Tarefa t)
    {
        tarefas.Add(t);
    }
}