//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Proccesings.SpreadSheet;

public interface ISpreadsheetProccesingService
{
    List<ExternalApplicantModel> GetExternalApplicants(MemoryStream memoryStream);
}
