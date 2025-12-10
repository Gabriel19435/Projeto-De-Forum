using Blog_Projeto.Data;
using Blog_Projeto.Services.Posts.Class;
using Blog_Projeto.Services.Posts.Interface;
using Blog_Projeto.Services.Posts.Posts_Repository;
using Blog_Projeto.Services.Profile.Class;
using Blog_Projeto.Services.Profile.Interface;
using Blog_Projeto.Services.Profile.Profile_Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Site_Blog.Service.Profile.Class;
using Site_Blog.Service.Profile.Interface;

var builder = WebApplication.CreateBuilder(args);

//Service
builder.Services.AddScoped<Posts_Service>();
builder.Services.AddScoped<Posts_Facade>();
builder.Services.AddScoped<Profile_Services>();
builder.Services.AddScoped<Profile_Facade>();

//injeçao
//Posts
builder.Services.AddScoped<IDeletePost, DeletePost>();
builder.Services.AddScoped<ICreatePost, CreatePost>();
builder.Services.AddScoped<IEdit, Edit>();
builder.Services.AddScoped<IToList, ToList>();
builder.Services.AddScoped<IFind, Find>();
builder.Services.AddScoped<IFindCompletePost, FindCompletePost>();
builder.Services.AddScoped<ISearch, Search>();
//Users
builder.Services.AddScoped<IRegister, Register>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IUpdate, Update>();
builder.Services.AddScoped<IFindProfile, FindProfile>();
builder.Services.AddScoped<IUserPage, UserPage>();
builder.Services.AddScoped<IDeleteProfile, DeleteProfile>();

builder.Services.AddHttpContextAccessor();

//Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddSqlServer<Blog_Context>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.LoginPath = "/Profile/Login";
        options.LogoutPath = "/Profile/Logout";
        options.SlidingExpiration = true;

        //segurança cookie
        options.Cookie.Name = "SiteBlogCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Lax;

        //expira
        options.Cookie.IsEssential = true;
        options.Cookie.MaxAge = TimeSpan.FromHours(3);
    });

var app = builder.Build();

app.UseAuthentication();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
