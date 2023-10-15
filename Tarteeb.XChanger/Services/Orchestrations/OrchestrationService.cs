//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;
using Tarteeb.XChanger.Services.Foundations.ProccesingService;
using Tarteeb.XChanger.Services.Orchestrations.Interfaces;

namespace Tarteeb.XChanger.Services.Orchestrations;

public class OrchestrationService : IOrchestrationService
{
    List<ExternalApplicantModel> validExternalApplicants;
    private readonly ISpreadsheetProccesingService spreadsheetProccesingService;

    public OrchestrationService(ISpreadsheetProccesingService spreadsheetProccesingService)
    {
        this.validExternalApplicants = new List<ExternalApplicantModel>();
        this.spreadsheetProccesingService = spreadsheetProccesingService;

    }

    public void ProccesingImportRequest(MemoryStream stream)
    {
        this.validExternalApplicants = spreadsheetProccesingService.GetExternalApplicants(stream);
    }
}
