
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
    Emprestimo? emprestimo = sistema.Buscar(id);

    if(emprestimo!=null)
    {
        emprestimo.Cliente.AlterarNome(nome);
    }

    return emprestimo;
});








app.MapGet("/", () => "Iniciando");

app.MapGet("/status", ()=>"Site Rodando");


app.MapGet("/AlterarValor", () => "Alterando Valor");

app.MapGet("/PagarJuros", () => "Pagando Juros");

app.MapGet("/RiscarNome", () => "Riscando Nome");

app.MapGet("/Sair", () => "Saindo do Sistema");

app.Run();
