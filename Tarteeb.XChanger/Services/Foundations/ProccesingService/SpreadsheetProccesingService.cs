//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Foundations.ProccesingService;
public class SpreadsheetProccesingService : ISpreadsheetProccesingService
{
    private readonly ISpreadsheetService spreadsheetService;
    public SpreadsheetProccesingService(ISpreadsheetService spreadsheetService)
    {
        this.spreadsheetService = spreadsheetService;
    }
    public List<ExternalApplicantModel> GetExternalApplicants(MemoryStream memoryStream)
    {
        return spreadsheetService.GetApplicants(memoryStream);
    }
}

