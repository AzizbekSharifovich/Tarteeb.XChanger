//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.IO;

namespace Tarteeb.XChanger.Services.Orchestrations;

public interface IOrchestrationService
{
    void ProccesingImportRequest(MemoryStream stream);
}
