using Ravendarque.ClimbingCapacity.Web.Clients;

var app = BuildWebApplication(args);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error")
       .UseHsts();
}

app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthorization();

app.MapRazorPages();

app.Run();

static WebApplication BuildWebApplication(string[] strings)
{
    var builder = WebApplication.CreateBuilder(strings);
    builder.Services.AddRazorPages();
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton<ICapacityDataClient, LccCapacityDataClient>();
           //.AddSingleton<ICapacityDataClient, Other>();
    return builder.Build();
}