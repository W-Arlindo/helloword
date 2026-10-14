using System;
using Tarefas.Services;
using Tarefas.UI;

namespace Tarefas;

class Programa
{
    static void Main()
    {
        Menu menu = new();

        bool programa=true;

        do
        {
            programa = menu.__init__();
        }while(programa);
    }
}