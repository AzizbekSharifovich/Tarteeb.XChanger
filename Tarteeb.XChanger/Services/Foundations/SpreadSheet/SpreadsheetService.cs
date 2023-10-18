//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Brokers;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Foundations.SpreadSheet;

public class SpreadsheetService : ISpreadsheetService
{
    private readonly ISpreadSheetBroker spreadSheetBroker;
    public SpreadsheetService(ISpreadSheetBroker spreadSheetBroker)
    {
        this.spreadSheetBroker = spreadSheetBroker;
    }
    public List<ExternalApplicantModel> GetApplicants(MemoryStream stream)
    {
        return spreadSheetBroker.ReadExternalApplicants(stream);
    }
}
