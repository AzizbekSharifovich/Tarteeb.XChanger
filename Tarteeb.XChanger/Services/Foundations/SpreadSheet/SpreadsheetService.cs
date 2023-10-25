//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Brokers;
using Tarteeb.XChanger.Brokers.Loggings;
using Tarteeb.XChanger.Models.Foundations.Applicants;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions;

namespace Tarteeb.XChanger.Services.Foundations.SpreadSheet;

public partial class SpreadsheetService : ISpreadsheetService
{
    private readonly ISpreadSheetBroker spreadSheetBroker;
    private readonly ILoggingBroker loggingBroker;

    public SpreadsheetService(
        ISpreadSheetBroker spreadSheetBroker,
        ILoggingBroker loggingBroker)
    {
        this.spreadSheetBroker = spreadSheetBroker;
        this.loggingBroker = loggingBroker;
    }

    public List<ExternalApplicantModel> GetApplicants(MemoryStream stream) =>
    TryCatch(() =>
    {
        ValidateSpreadSheetNotNull(stream);

        return spreadSheetBroker.ReadExternalApplicants(stream);
    });

    private static void ValidateSpreadSheetNotNull(MemoryStream stream)
    {
        if (stream is null)
        {
            throw new NullSpreadSheetException();
        }
    }
}
