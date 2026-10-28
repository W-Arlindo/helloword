using System;
using MYAPI.Models;

namespace MYAPI.Services;

class BuscarDados{

    string caminho ="Emprestimos.txt";

    List<Emprestimo> emprestimos = new();

    bool Verificar(string caminho)
    {
        if (File.Exists(caminho))
        {
            return true;
        }
        return false;
    }
    void organizarlista()
    {
        int save=1;
        Cliente clientetemp = new Cliente("A",1,1);
        Emprestimo EmprestimoTemp = new Emprestimo(clientetemp);

        string[] emprestimos = File.ReadAllLines(caminho);

        foreach (var item in emprestimos)
            {
                if (save == 9)
                {
                    save = 1;
                }

                if (save == 1)
                {
                    clientetemp = new("a", 1,1);
                    EmprestimoTemp = new(clientetemp);
                }

                if (save <= 8)
                {
                    switch (save)
                    {
                        case 1:
                            EmprestimoTemp.AddNumero(item);
                            break;

                        case 2:
                            EmprestimoTemp.Cliente.AddNome(item);
                            break;

                        case 3:
                            EmprestimoTemp.Cliente.AddValor(item);
                            break;

                        case 4:
                            EmprestimoTemp.Cliente.AddJuros(item);
                            break;

                        case 5:
                            EmprestimoTemp.AddStatus(item);
                            break;
                        case 6:
                            EmprestimoTemp.AddDataEmprestimo(item);
                            break;
                        case 7:
                            EmprestimoTemp.AddDataVencimento(item);
                            break;
                        case 8:
                            EmprestimoTemp.AddMesReagendado(item);
                            break;
                    }
                }
                if ((save % 8) == 0)
                {
                    this.emprestimos.Add(EmprestimoTemp);
                }
                save++;
            }
    }
    public List<Emprestimo>? BuscarArquivo()
    {
        if (Verificar(caminho))
        {
            organizarlista();
            return emprestimos;
        }
        return null;
    }
}