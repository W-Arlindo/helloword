
using MYAPI.Models;
using MYAPI.Services;
using MYAPI.UI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

MenuSistemaAgiota menuSistemaAgiota = new();

SistemaAgiota sistema = new();

//Listar emprestimo
app.MapGet("/Emprestimo", () =>
{
    return sistema.ListarEmprestimo();
});

//Buscar Emprestimo
app.MapGet("/Emprestimo/{id}",(int id) =>
{
    string erro ="";

    Emprestimo? emprestimo = sistema.Buscar(id,out erro);

    if(emprestimo == null&&erro!="")
    {
        return Results.NotFound(erro);
    }
    else
    {
        return Results.Ok(emprestimo);
        
    }
});

//Cadastrar emprestimo
app.MapPost("/Emprestimo/Cadastrar",(CadastrarCliente cliente) =>
{
    try{
        sistema.CadastrarCliente(cliente.nome,cliente.valor,cliente.juros);
    }
    catch(ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    
    sistema.EnviarArquivo();
    return Results.NoContent();
});

//Alterar Nome do cliente 
app.MapPut("/Emprestimo/Cliente/AlterarNome/{id}", (int id,string nome) => {
    
    string erro = "";

    //Recebe Emprestimo solicitado
    Emprestimo? emprestimo = sistema.Buscar(id,out erro);

    //verifica e altera;
    if(emprestimo!=null)
    {
        emprestimo.Cliente.AlterarNome(nome,out erro);
    }
    else
    {
        return Results.NotFound(erro);
    }

    
    //retorna o valor alterado
    if(erro == "")
    {
        sistema.EnviarArquivo();
        return Results.Ok(emprestimo);
    }
    else
    {
        return Results.BadRequest(erro);
    }
    
});

//Alterar Valor do Emprestimo
app.MapPut("/Emprestimo/Cliente/AlterarValor/{id}", (int id, decimal valor) =>
{
    string erro = "";

    //Recebe Emprestimo solicitado
    Emprestimo? emprestimo = sistema.Buscar(id,out erro);
    
    //verifica e altera;
    if(emprestimo!=null){
        emprestimo.Cliente.AlterarValor(valor,out erro);
    }
    else
    {
        return Results.NotFound(erro);
    }


    //retorna o valor alterado
    if(erro != "")
    {
        return Results.BadRequest(erro);
    }
    else
    {
        sistema.EnviarArquivo();
        return Results.Ok(emprestimo);
    }

});

//pagou apenas o juros e reagendou para o proximo mes
app.MapPut("/Emprestimo/PagouJuros/{id}", (int id) =>
{
    string erro = "";
    Emprestimo? empres = sistema.Buscar(id,out erro);

    if(empres != null)
    {
        empres.JurosPago(sistema.ListarEmprestimo(),out erro);
    }
    else
    {
        return Results.NotFound(erro);
    }

    if(erro == "")
    {
        sistema.EnviarArquivo();
        return Results.Ok(empres);
    }
    else
    {
        return Results.BadRequest(erro);
    }
});

//Pago divida completa
app.MapPost("/Emprestimo/QuitouDivida/{id}", (int id) =>
{
    string erro ="";
    Emprestimo? emprestimo = sistema.Buscar(id, out erro);

    if (emprestimo == null)
    {
        return Results.NotFound(erro);
    }
    else
    {
        sistema.DividaPaga(emprestimo, out erro);
    }

    if (erro == "")
    {
        sistema.EnviarArquivo();
        return Results.NoContent();
    }
    else
    {
        return Results.BadRequest(erro);
    }
});

//Riscar nome da lista
app.MapDelete("/Emprestimo/Delete/{id}", (int id) =>
{
    string erro ="";
    Emprestimo? emprestimo = sistema.Buscar(id, out erro);

    if (emprestimo == null)
    {
        return Results.NotFound(erro);
    }
    else
    {
        sistema.RiscarNome(emprestimo,out erro);
    }

    if(erro == "")
    {
        sistema.EnviarArquivo();
        return Results.NoContent();
    }
    else
    {
        return Results.BadRequest(erro);
    }
});



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










app.MapGet("/", () => "Iniciando");

app.MapGet("/status", ()=>"Site Rodando");






app.MapGet("/Sair", () => "Saindo do Sistema");

app.Run();
