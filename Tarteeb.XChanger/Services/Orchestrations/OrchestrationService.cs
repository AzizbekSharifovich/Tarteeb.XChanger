//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.Groups;
using Tarteeb.XChanger.Services.Proccesings.Applicants;
using Tarteeb.XChanger.Services.Proccesings.Group;
using Tarteeb.XChanger.Services.Proccesings.SpreadSheet;

namespace Tarteeb.XChanger.Services.Orchestrations;

public class OrchestrationService : IOrchestrationService
{
    List<ExternalApplicantModel> validExternalApplicants;
    private readonly ISpreadsheetProccesingService spreadsheetProccesingService;
    private readonly IGroupProccesingService groupProccesingService;
    private readonly IApplicantProccesingService applicantProccesingService;

    public OrchestrationService(
        ISpreadsheetProccesingService spreadsheetProccesingService,
        IGroupProccesingService groupProccesingService,
        IApplicantProccesingService applicantProccesingService)
    {
        this.validExternalApplicants = new List<ExternalApplicantModel>();
        this.spreadsheetProccesingService = spreadsheetProccesingService;
        this.groupProccesingService = groupProccesingService;
        this.applicantProccesingService = applicantProccesingService;
    }

    public async void ProccesingImportRequest(MemoryStream stream)
    {
        this.validExternalApplicants = spreadsheetProccesingService.GetExternalApplicants(stream);

        foreach (var externalApplicant in validExternalApplicants)
        {
            Group ensureGroup = await groupProccesingService.EnsureGroupExistsByName(externalApplicant.GroupName);
            ExternalApplicantModel applicant = MapToApplicant(externalApplicant, ensureGroup);
            await applicantProccesingService.InsertApplicantAsync(applicant);

        }
    }

    private ExternalApplicantModel MapToApplicant(ExternalApplicantModel externalApplicant, Group ensureGroup)
    {
        return new ExternalApplicantModel
        {
            Id = Guid.NewGuid(),
            FirstName = externalApplicant.FirstName,
            LastName = externalApplicant.LastName,
            Email = externalApplicant.Email,
            GroupName = ensureGroup.GroupName,
            GroupId = ensureGroup.Id,
            PhoneNumber = externalApplicant.PhoneNumber
        };
    }
}
