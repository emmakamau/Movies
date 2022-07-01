var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


/*
app.UseHttpsRedirection(); : Redirects HTTP requests to HTTPS.
app.UseStaticFiles(); : Enables static files, such as HTML, CSS, images, and JavaScript to be served. For more information, see Static files in ASP.NET Core.
app.UseRouting(); : Adds route matching to the middleware pipeline. For more information, see Routing in ASP.NET Core
app.MapRazorPages();: Configures endpoint routing for Razor Pages.
app.UseAuthorization(); : Authorizes a user to access secure resources. This app doesn't use authorization, therefore this line could be removed.
app.Run(); : Runs the app.
*/