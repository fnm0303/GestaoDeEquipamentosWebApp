using GestaoDeEquipamentos.WebApp.Compartilhado.Apresentacao;
using GestaoDeEquipamentos.WebApp.Compartilhado.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

//Configurar a INFRAESTRUTURA (arquivos, banco de dados, logs, cachês, etc..)
builder.Services.AdicionarCamadaInfraEstrutura();

//Configura MVC / APRESENTAÇÃO
builder.Services.AdicionarCamadaApresentacao();

var app = builder.Build();

//Middleware
app.UseRouting();
app.MapDefaultControllerRoute();

app.UseStaticFiles();

//Execução do SERVIDOR
app.Run();
