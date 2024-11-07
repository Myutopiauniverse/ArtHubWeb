using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrySigninBlazor.Components;
using TrySigninBlazor.Components.Account;
using TrySigninBlazor.Data;
using Microsoft.Extensions.DependencyInjection;
using TrySigninBlazor.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<TrySigninBlazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrySigninBlazorContext") ?? throw new InvalidOperationException("Connection string 'TrySigninBlazorContext' not found.")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapRazorComponents<App>().AddInteractiveServerRenderMode();
    _ = endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
});


app.MapAdditionalIdentityEndpoints();
app.Run();
app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.MapFallbackToFile("index.html");