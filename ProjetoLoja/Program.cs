using ProjetoLoja.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. REGISTRAR OS SERVI�OS DE SESS�O
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de inatividade da sess�o (pode ajustar)
    options.Cookie.HttpOnly = true; // Impede que o cookie seja acessado por scripts do lado do cliente
    options.Cookie.IsEssential = true; // Torna o cookie de sess�o essencial para a funcionalidade do aplicativo
});

// REGISTRAR A CONNECTION STRING COMO UM SERVI�O STRING AQUI
builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);

// Registrar Reposit�rios
// injetar os repositorios
builder.Services.AddScoped<ProdutoRepositorio>();
builder.Services.AddScoped<CarrinhoRepositorio>();
builder.Services.AddScoped<ProdutoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// ESTA LINHA � CRUCIAL E DEVE VIR ANTES DE app.UseAuthorization() ou app.MapControllerRoute() <<<
app.UseSession(); //permite a sess�o antes de autorizar

app.UseAuthorization(); //altoriza a navega��o

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
