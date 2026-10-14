using System;

namespace Tarefas.Models;

class Tarefa
{
    public int Id{get; private set;}
    public string Titulo{get; private set;}
    public string Descricao{get; private set;}
    public bool Concluida{get; private set;}

    public Tarefa(List<Tarefa> tarefas, string titulo, string descricao)
    {
        verificarid(tarefas);
        if (verificartitulo(titulo))
        {
            throw new ArgumentException("Titulo invalido!");
        }
        else
        {
            Titulo=titulo;
        }
        if (verificardescricao(descricao))
        {
            throw new ArgumentException("Descricao invalida");
        }
        else
        {
            Descricao=descricao;
        }
        Concluida=false;
    }

    //verificar id
    void verificarid(List<Tarefa> tarefas)
    {
        foreach(Tarefa tarefa in tarefas)
        {
            if (tarefa.Id >= Id)
            {
                Id=tarefa.Id +1;
            }
        }
    }

    //Verifica o Titulo da tarefa
    bool verificartitulo(string t)
    {
        if (string.IsNullOrWhiteSpace(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Verificar o titulo da descricao
    bool verificardescricao(string d)
    {
        if (string.IsNullOrWhiteSpace(d))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //concluir
    public void ConcluirTarefa()
    {
        Concluida=true;
    }
}