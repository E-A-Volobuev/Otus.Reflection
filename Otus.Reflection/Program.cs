using Otus.Reflection.Services;
using Microsoft.Extensions.DependencyInjection;
using Otus.Reflection;
using Microsoft.Extensions.Hosting;
using Otus.Reflection.Interfaces;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<StartApp>();
builder.Services.AddScoped<ISerializeByNewtonsoftJsonService, SerializeByNewtonsoftJsonService>();
builder.Services.AddScoped<ICustomSerializeService, CustomSerializeService>();
builder.Services.AddScoped<ICsvFileService, CsvFileService>();

using IHost host = builder.Build();

await host.RunAsync();


