//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Services;

public interface ISpreadsheetService
{
    List<ExternalApplicant> GetApplicants(MemoryStream stream);
}
