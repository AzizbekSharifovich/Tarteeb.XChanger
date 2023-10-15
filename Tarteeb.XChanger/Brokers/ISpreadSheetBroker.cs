//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.Collections.Generic;
using System.IO;
using Tarteeb.XChanger.Models;

namespace Tarteeb.XChanger.Brokers;

public interface ISpreadSheetBroker
{
    List<ExternalApplicantModel> ReadExternalApplicants(MemoryStream stream);
}
