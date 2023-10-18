//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;
using Tarteeb.XChanger.Services.Foundations.SpreadSheet;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet;
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

