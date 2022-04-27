using LinkShortenerShtokal.Commands.Base;
using LinkShortenerShtokal.Commands.Url.AddUrl;
using LinkShortenerShtokal.Commands.Url.DeleteUrl;
using LinkShortenerShtokal.Commands.Url.RedirectToOriginalUrl;
using LinkShortenerShtokal.Core.Models;
using LinkShortenerShtokal.Infrastructure.EF;
using LinkShortenerShtokal.Infrastructure.Services;
using LinkShortenerShtokal.Infrastructure.Settings;
using LinkShortenerShtokal.Mapper;
using LinkShortenerShtokal.Queries.Base;
using LinkShortenerShtokal.Queries.ShortenedUrls.GetAllUrlsStatistic;
using LinkShortenerShtokal.StartupTasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));
//DI IOptions<PositionOptions> options
var options = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStringOptions>();
builder.Services.AddSingleton<ConnectionStringOptions>(options);
builder.Services.AddSingleton<ILinkShortenerService, LinkShortenerService>();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<ApplicationContext>((sp, options) => options.UseInternalServiceProvider(sp));

builder.Services.AddTransient<IStartupTask, AutoMigrationStartupTask>();

builder.Services.AddScoped<IRedirectService, RedirectService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddTransient<ICommandHandler<AddUrlCommand, AddUrlResult>, >();

//builder.ConfigureAppConfiguration((builderContext, config) =>
//{
//    var env = builderContext.HostingEnvironment;
//    config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
//    config.SetBasePath(env.ContentRootPath);
//})
//builder.Services.AddTransient<ICommandHandler<AddUrlCommand, AddUrlResult>, AddUrlHandler>();

builder.Services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ICommandHandler<AddUrlCommand, AddUrlResult>, AddUrlHandler>();
builder.Services.AddTransient<ICommandHandler<GetOriginalUrlCommand, GetOriginalUrlCommandResult>, GetOriginalUrlCommandHandler>();
builder.Services.AddTransient<ICommandHandler<GetOriginalUrlCommand, GetOriginalUrlCommandResult>, GetOriginalUrlCommandHandler>();
builder.Services.AddTransient<IQueryHandler<GetAllUrlsStatisticQuery, List<ShortenedUrlDto>>, GetAllUrlsStatisticHandler>();
builder.Services.AddTransient<ICommandHandler<DeleteUrlCommand, DeleteUrlCommandResult>, DeleteUrlHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

var startupTasks = app.Services.GetServices<IStartupTask>();
foreach (var startupTask in startupTasks)
{
    await startupTask.ExecuteAsync();
}

app.Run();
