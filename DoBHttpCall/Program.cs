using DoBHttpCall.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");

builder.Services.AddHttpClient<IDoBHttpClient, DoBHttpClient>();
using var host = builder.Build();
var bisnodeClient = host.Services.GetRequiredService<IDoBHttpClient>();

const string registrationNumber = "5561234567";
var company = await bisnodeClient.GetCompanyInformation(registrationNumber);

Console.WriteLine(company.CompanyInformation?.CompanyName?.RegisteredName?.Name);
