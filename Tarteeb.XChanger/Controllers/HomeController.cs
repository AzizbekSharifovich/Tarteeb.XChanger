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
using Tarteeb.XChanger.Models.Orchestrations.ExternalApplicants.Exceptions;
using Tarteeb.XChanger.Models.Orchestrations.Groups;
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
    public async Task<IActionResult> Import(IFormFile formFile)
    {
        try
        {
            await orchestrationService.ProccesingImportRequest(formFile);
            
            return Ok();
        }
        catch (ExternalApplicantOrchestrationValidationException externalApplicantOrchestrationValidationException)
        {

            return BadRequest(externalApplicantOrchestrationValidationException.Message + " "
                + externalApplicantOrchestrationValidationException.InnerException.Message);    
        }
        catch(GroupOchrestartionValidationException groupOchrestartionValidationException)
        {
            return BadRequest(groupOchrestartionValidationException.Message + " " +
                groupOchrestartionValidationException.InnerException.Message);
        }
        catch(GroupOchrestartionDependencyException groupOchrestartionDependencyException)
        {
            return BadRequest(groupOchrestartionDependencyException.Message + " " +
                groupOchrestartionDependencyException.InnerException.Message);
        }
        catch(GroupOrchestartionDependencyValidationException groupOrchestartionDependencyValidationException)
        {
            return BadRequest(groupOrchestartionDependencyValidationException.Message + " " +
                groupOrchestartionDependencyValidationException.InnerException.Message);
        }
        //exceptions
        catch(GroupOrchestrationServiceException groupOrchestrationServiceException)
        {
            return BadRequest(groupOrchestrationServiceException.Message + " " +
                groupOrchestrationServiceException.InnerException.Message);
        }
    }
}
