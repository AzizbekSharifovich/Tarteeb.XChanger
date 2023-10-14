//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tarteeb.XChanger.Brokers;
using Tarteeb.XChanger.Services.Foundations.ProccesingService;
using Tarteeb.XChanger.Services.Orchestrations;
using Tarteeb.XChanger.Services.Orchestrations.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IOrchestrationService, OrchestrationService>();
builder.Services.AddSingleton<ISpreadsheetProccesingService, SpreadsheetProccesingService>();
builder.Services.AddSingleton<ISpreadSheetBroker, SpreadSheetBroker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
