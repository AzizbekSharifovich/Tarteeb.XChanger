//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Brokers;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Foundations.ProccesingService;
public class SpreadsheetProccesingService : ISpreadsheetProccesingService
{
    private readonly ISpreadSheetBroker spreadSheetBroker;
    public SpreadsheetProccesingService(ISpreadSheetBroker spreadSheetBroker)
    {
        this.spreadSheetBroker = spreadSheetBroker;
    }
    public List<ExternalApplicant> GetExternalApplicants(MemoryStream memoryStream)
    {
        return spreadSheetBroker.ReadExternalApplicants(memoryStream);
    }
}

