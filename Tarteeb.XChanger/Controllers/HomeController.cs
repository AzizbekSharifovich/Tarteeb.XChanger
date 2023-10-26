//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions;
using Tarteeb.XChanger.Models.Foundations.SpreadSheets.Exceptions.Categories;
using Tarteeb.XChanger.Models.Proccesings.SpreadSheet.Exceptions;
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
    public async Task<IActionResult> Import(IFormFile file)
    {
        try
        {
            await orchestrationService.ProccesingImportRequest(file);
            
            return Ok();
        }
        catch (SpreadSheetProccesingValidationException spreadSheetProccesingValidationException)
        {

            return BadRequest(spreadSheetProccesingValidationException.Message + " "
                + spreadSheetProccesingValidationException.InnerException.Message);    
        }
        catch(FailedServiceSpreadSheetException failedServiceSpreadSheetException)
        {
            return BadRequest(failedServiceSpreadSheetException.Message + " "
                + failedServiceSpreadSheetException.InnerException.Message);
        }
    }
}
