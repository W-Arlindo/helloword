using System;
using System.Xml.Linq;
using MYAPI.Models;

namespace MYAPI.Services;

public class SistemaAgiota
{
    /*string caminho = "Emprestimos.txt";

    public SistemaAgiota()
    {
        try
        {
            Console.Write("Carregando Arquivo");
            for (int i = 0; i < 3; i++)
            {
                Task.Delay(1);
                Console.Write(". ");
            }

            CarregarArquivo();

            Console.Clear();
            Console.WriteLine("Encontrado!!");
            Task.Delay(063);

            Console.Clear();
        }
        catch
        {
            Console.WriteLine("Nenhum Programa encontrado");
            Task.Delay(50);
            Console.Clear();
            return;
        }
        finally
        {
            Console.WriteLine("Programa iniciado.");
        }
    }

    MenuSistemaAgiota MenuAgiota = new();

    void CarregarArquivo()
    {
        int save = 1;

        if (File.Exists(caminho))
        {
            Cliente ClienteTemp = new("a", "1", "1");
            Emprestimo EmprestimoTemp = new(ClienteTemp);

            string[] Emprestimos = File.ReadAllLines(caminho);
            foreach (var item in Emprestimos)
            {
                if (save == 9)
                {
                    save = 1;
                }

                if (save == 1)
                {
                    ClienteTemp = new("a", "1", "1");
                    EmprestimoTemp = new(ClienteTemp);
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
                            EmprestimoTemp.Cliente.AlterarValor(item);
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
    }
    */
    private List<Emprestimo> emprestimos = new();

    //Listar Emprestimos
    internal List<Emprestimo> ListarEmprestimo()
    {
        //enviando lista dos emprestimo 
        return emprestimos;
    }

    internal void CadastrarCliente(Cliente cliente)
    {
        emprestimos.Add(new Emprestimo(cliente));
    }
   
    /*void adicionarlista(Cliente c)
    {
        emprestimos.Add(new Emprestimo(c));
    }

    public void AlterarNomeCliente()
    {
        ListarClientes();

        Emprestimo EmprestimoTemp;

        Console.WriteLine("= = = ALTERAR NOME = = =");
        try
        {
            EmprestimoTemp = Buscar();
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        try
        {
            EmprestimoTemp.Cliente.AlterarNome(MenuAgiota.ReceberNome());
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void AlterarValor()
    {
        ListarClientes();

        Emprestimo emprestimo;

        Console.WriteLine("= = = ALTERAR VALOR = = =");
        try
        {
            emprestimo = Buscar();
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (NullReferenceException ex ){
            Console.WriteLine(ex.Message);
            return;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        try
        {
            emprestimo.Cliente.AlterarValor(MenuAgiota.ReceberValor());
        }
        catch(FormatException ex){
            Console.WriteLine(ex.Message);
            return;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void QuitouJuros()
    {
        Emprestimo e;

        try
        {
            e = Buscar();
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        e.JurosPago(emprestimos);
    }
    */
    
    //buscar emprestimo pelo id
    internal Emprestimo? Buscar(int id)
    {
        //percorrendo lista de emprestimo
        foreach(Emprestimo emprestimo in emprestimos)
        {
            //verificando id de cada emprestimo
            if (emprestimo.Numero == id)
            {
                return emprestimo;
            }
        }
       
    return null;
    }

    /*public void RiscarNome()
    {
        Emprestimo e;

        try
        {
            e = Buscar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        emprestimos.Remove(e);
        e.OrganizarLista(emprestimos);
    }

    public bool FinalizarPrograma()
    {
        List<string> arquivo = ListaSave();

        File.WriteAllLines(caminho, arquivo);

        return false;
    }
    
    List<string> ListaSave()
    {
        List<List<string>> emprestimosS = new List<List<string>>();
        List<string> arquivo = new List<string>();

        foreach (Emprestimo emprestimo in emprestimos)
        {
            List<string> e = new List<string>();

            e.Add(emprestimo.Numero.ToString());
            e.Add(emprestimo.Cliente.Nome);
            e.Add(emprestimo.Cliente.Valor.ToString());
            e.Add(emprestimo.Cliente.Juros.ToString());
            e.Add(emprestimo.Status.ToString());
            e.Add(emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"));
            e.Add(emprestimo.DataVencimento.ToString("dd/MM/yyyy"));
            e.Add(emprestimo.MesesReagendado.ToString());

            emprestimosS.Add(e);
        }
        foreach (var emprestimo in emprestimosS)
        {
            foreach (string dados in emprestimo)
            {
                arquivo.Add(dados);
            }
        }
        return arquivo;
    }*/
}



/*
 *  ╔══════════════════════════════╗
 *  ≠======≠======⟦ΛR⟧======≠======≠
 *  ║                              ║
 *  ║  > author  : W-Arlindo       ║
 *  ║  > project : ΛR-OF-001       ║
 *  ║  > name    : Sistema Agiota  ║
 *  ║  > stack   : C# / .NET       ║
 *  ║  > status  : development     ║
 *  ║                              ║
 *  ╚══════════════════════════════╝
 */