//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.IO;
using System.Threading.Tasks;

namespace Tarteeb.XChanger.Services.Orchestrations;

public interface IOrchestrationService
{
    Task ProccesingImportRequest(MemoryStream stream);
}
