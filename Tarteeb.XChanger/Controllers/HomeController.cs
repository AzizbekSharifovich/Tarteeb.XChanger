//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarteeb.XChanger.Services.Orchestrations;

namespace Tarteeb.XChanger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IOrchestrationService orchestrationService;
    public HomeController(IOrchestrationService orchestrationService)
    {
        this.orchestrationService = orchestrationService;
    }

    [HttpPost]
    public IActionResult Import(IFormFile file)
    {
        var stream = new MemoryStream();
        file.CopyTo(stream);
        
        stream.Position = 1;
        orchestrationService.ProccesingImportRequest(stream);

        return Ok();
    }
}
