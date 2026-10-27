
using MYAPI.Models;
using MYAPI.Services;
using MYAPI.UI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

MenuSistemaAgiota menuSistemaAgiota = new();

SistemaAgiota sistema = new();

//Cadastrar emprestimo
app.MapPost("/CadastrarEmprestimo",(Cliente cliente) =>
{
    sistema.CadastrarCliente(cliente);
});

//Listar emprestimo
app.MapGet("/Emprestimos", () =>
{
    return sistema.ListarEmprestimo();
});

//Buscar Emprestimo
app.MapGet("/Cliente/{id}",(int id) =>
{
    Emprestimo emprestimo = sistema.Buscar(id);
    if(emprestimo == null)
    {
        return Results.NotFound("Emprestimo nao encontrado!!");
    }
    else
    {
        return Results.Ok(emprestimo);
        
        //return Results.Ok(menuSistemaAgiota.Listar(emprestimo));
    }
});

//Alterar Nome
app.MapPut("/Emprestimo/{id}", (int id,string nome) => {
    
    string erro = "";
    
    //Recebe Emprestimo solicitado
    Emprestimo? emprestimo = sistema.Buscar(id);
    

    //verifica e altera;
    if(emprestimo!=null)
    {
        emprestimo.Cliente.AlterarNome(nome,out erro);

        
    }

    
    //retorna o valor alterado
    if(erro == "")
    {
        return Results.Ok(emprestimo);
    }
    else
    {
        return Results.NotFound(erro);
    }
    
});








app.MapGet("/", () => "Iniciando");

app.MapGet("/status", ()=>"Site Rodando");


app.MapGet("/AlterarValor", () => "Alterando Valor");

app.MapGet("/PagarJuros", () => "Pagando Juros");

app.MapGet("/RiscarNome", () => "Riscando Nome");

app.MapGet("/Sair", () => "Saindo do Sistema");

app.Run();
