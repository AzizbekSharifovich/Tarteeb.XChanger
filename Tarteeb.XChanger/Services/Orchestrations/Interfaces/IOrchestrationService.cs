//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System;
using System.IO;

namespace Tarteeb.XChanger.Services.Orchestrations.Interfaces;

public interface IOrchestrationService
{
    void ProccesingImportRequest(MemoryStream stream);
}
