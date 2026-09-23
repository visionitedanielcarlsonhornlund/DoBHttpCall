using DoBHttpCall.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ClientId: {builder.Configuration["Bisnode:ClientId"]}");
Console.WriteLine($"Secret finns: {!string.IsNullOrEmpty(builder.Configuration["Bisnode:ClientSecret"])}");

builder.Services.AddHttpClient<IDoBHttpClient, DoBHttpClient>();
using var host = builder.Build();
var bisnodeClient = host.Services.GetRequiredService<IDoBHttpClient>();

var company = await bisnodeClient.GetCompanyInformation("5561234567");

Console.WriteLine(company.CompanyInformation?.CompanyName?.RegisteredName?.Name);