using System;
using MYAPI.Models;

namespace MYAPI.Services;

abstract class Dados{
    public string Caminho = "Emprestimos.txt";
}

class TrazerDados:Dados{

    bool Verificar(string caminho)
    {
        if (File.Exists(caminho))
        {
            return true;
        }
        throw new InvalidOperationException("Arquivo nao encontrado");
    }
    
    void organizarlista(List<Emprestimo> emprestimos)
    {
        string[] arquivoemprestimos;

        if (Verificar(Caminho))
        {
            arquivoemprestimos = File.ReadAllLines(Caminho);
            Estruturar(emprestimos,arquivoemprestimos);
        }
    }
    
    void Estruturar(List<Emprestimo> Emprestimos,string[] arquivoemprestimos)   
    {
        int save=0;

        Cliente clientetemp=new("A",1,1);
        Emprestimo EmprestimoTemp = new(clientetemp);

        if((arquivoemprestimos.Length-1)%8==0){
            foreach (var linha in arquivoemprestimos)
            {
                if (save == 0)
                {
                    EmprestimoTemp.AddContador(linha);
                }
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
                        EmprestimoTemp.AddNumero(linha);
                        break;

                        case 2:
                            EmprestimoTemp.Cliente.AddNome(linha);
                            break;

                        case 3:
                            EmprestimoTemp.Cliente.AddValor(linha);
                            break;

                        case 4:
                            EmprestimoTemp.Cliente.AddJuros(linha);
                            break;

                        case 5:
                            EmprestimoTemp.AddStatus(linha);
                            break;

                        case 6:
                            EmprestimoTemp.AddDataEmprestimo(linha);
                            break;

                        case 7:
                            EmprestimoTemp.AddDataVencimento(linha);
                            break;

                        case 8:
                            EmprestimoTemp.AddMesReagendado(linha);
                            break;
                    }
                }
                if ((save % 8) == 0)
                {
                    Emprestimos.Add(EmprestimoTemp);
                }
                save++;
            }
        }
        else
        {
            throw new InvalidOperationException("Arquivo corronpido");
        }

    }
    
    public List<Emprestimo>? BuscarArquivo()
    {
        List<Emprestimo> emprestimos=new();

        organizarlista(emprestimos);
        
        return emprestimos;
    }
}

class EnviarArquivo:Dados
{
    public void Enviar(List<Emprestimo> emprestimos)
    {
        List<string> arquivo = ArquivoPronta(emprestimos);

        File.WriteAllLines(Caminho, arquivo);

    }
    
    List<string> ArquivoPronta(List<Emprestimo> emprestimos)
    {
        List<List<string>> emprestimosS = new List<List<string>>();
        List<string> arquivo = new List<string>();

        Estruturar(emprestimos, emprestimosS);
        
        Preparar(emprestimosS,arquivo);
        
        return arquivo;
    }
    
    void Preparar(List<List<string>> emprestimosS, List<string> arquivo)
    {
        arquivo.Add(Emprestimo.Contador.ToString());
        foreach (var emprestimo in emprestimosS)
        {
            foreach (string dados in emprestimo)
            {
                arquivo.Add(dados);
            }
        }
    }
    
    void Estruturar(List<Emprestimo> emprestimos, List<List<string>> emprestimosS)
    {
        foreach (Emprestimo emprestimo in emprestimos)
        {
            List<string> e = new List<string>();

            e.Add(emprestimo.Id.ToString());
            e.Add(emprestimo.Cliente.Nome);
            e.Add(emprestimo.Cliente.Valor.ToString());
            e.Add(emprestimo.Cliente.Juros.ToString());
            e.Add(emprestimo.Status.ToString());
            e.Add(emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"));
            e.Add(emprestimo.DataVencimento.ToString("dd/MM/yyyy"));
            e.Add(emprestimo.MesesReagendado.ToString());

            emprestimosS.Add(e);
        }
    }
}