using Puzzle_28.Components;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

// Block the content folder
app.Use(async (HttpContext context, RequestDelegate next) =>
{

	if (context.Request.Path.ToString().Contains("/content", StringComparison.CurrentCultureIgnoreCase))
	{
		context.Response.StatusCode = (int)HttpStatusCode.NotFound;
		return;
	}

	await next(context);

});


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
