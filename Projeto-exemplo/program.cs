using System;
using Tarefas.Services;

namespace Tarefas;

class Programa
{
    static void Main()
    {
        Sistema starefas = new();
        starefas.CadastrarTarefas();
    }
}