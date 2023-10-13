//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services.Foundations.ProccesingService;

public interface ISpreadsheetProccesingService
{
    List<ExternalApplicant> GetExternalApplicants(MemoryStream memoryStream);
}
