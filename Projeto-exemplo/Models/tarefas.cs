class Tarefas
{
    public int Id{get; private set;}
    public string Titulo{get; private set;}
    public string Descricao{get; private set;}

    public Tarefas(int id, string titulo, string descricao)
    {
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
        Id=id;
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
}