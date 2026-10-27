var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/VerCaderno", () => "Visualizando Caderno");

app.MapGet("/CadastrarEmprestimo", () => "Cadastrando Empréstimo");

app.MapGet("/AlterarNome", () => "Alterando Nome");

app.MapGet("/AlterarValor", () => "Alterando Valor");

app.MapGet("/PagarJuros", () => "Pagando Juros");

app.MapGet("/RiscarNome", () => "Riscando Nome");

app.MapGet("/Sair", () => "Saindo do Sistema");

app.Run();
