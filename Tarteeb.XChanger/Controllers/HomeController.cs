//=================================
// Copyright (c) Tarteeb LLC.
// Powering True Leadership
//=================================

using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarteeb.XChanger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    public HomeController()
    {
        
    }

    [HttpPost]
    public IActionResult Import(IFormFile file)
    {
        var stream = new MemoryStream();
        file.CopyTo(stream);
        
        stream.Position = 1;
        return Ok();
    }
}
