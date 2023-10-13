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
    List<ExternalApplicant> validExternalApplicants;
    private readonly ISpreadsheetProccesingService spreadsheetProccesingService;

    public OrchestrationService(ISpreadsheetProccesingService spreadsheetProccesingService)
    {
        validExternalApplicants = new List<ExternalApplicant>();
        this.spreadsheetProccesingService = spreadsheetProccesingService;

    }

    public void ProccesingImportRequest(MemoryStream stream)
    {
        this.validExternalApplicants = this.spreadsheetProccesingService.GetExternalApplicants(stream);
    }
}
