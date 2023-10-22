//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tarteeb.XChanger.Brokers;
using Tarteeb.XChanger.Brokers.DateTimes;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Brokers.Storages;
using Tarteeb.XChanger.Services.Foundations.Applicants;
using Tarteeb.XChanger.Services.Foundations.Group;
using Tarteeb.XChanger.Services.Foundations.SpreadSheet;
using Tarteeb.XChanger.Services.Orchestrations;
using Tarteeb.XChanger.Services.Proccesings.Applicants;
using Tarteeb.XChanger.Services.Proccesings.Group;
using Tarteeb.XChanger.Services.Proccesings.SpreadSheet;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddSingleton<IStorageBroker, StorageBroker>();
builder.Services.AddSingleton<IOrchestrationService, OrchestrationService>();
builder.Services.AddSingleton<ISpreadsheetProccesingService, SpreadsheetProccesingService>();
builder.Services.AddSingleton<ISpreadSheetBroker, SpreadSheetBroker>();
builder.Services.AddSingleton<ISpreadsheetService, SpreadsheetService>();
builder.Services.AddSingleton<ILoggingBroker, LoggingBroker>();
builder.Services.AddSingleton<IGroupProccesingService, GroupProccesingService>();
builder.Services.AddSingleton<IGroupService, GroupService>();
builder.Services.AddSingleton<IApplicantProccesingService, ApplicantProccesingService>();
builder.Services.AddSingleton<IApplicantService, ApplicantService>();
builder.Services.AddSingleton<IDateTimeBroker, DateTimeBroker>();

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
