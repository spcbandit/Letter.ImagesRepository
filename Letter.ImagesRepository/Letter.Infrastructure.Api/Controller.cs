using System.ComponentModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Letter.Infrastructure.Api;
[ApiController]
[Route("/")]
[DisplayName("Работа с изображениями")]
[Produces("application/octet-stream")]
public class Controller:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    public Controller(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _configuration = configuration;
    }

    [HttpPost]
    [Route("SaveImage")]
    [SwaggerResponse(StatusCodes.Status200OK, "Сохранить ", typeof())]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Save = fail", typeof())]
    public async Task<IActionResult> SavePicture([FromForm] SaveImageRequest request)
    {
        var resp = await _mediator.Send(request);
        if (resp.success)
            return Ok(resp);
        else
            return BadRequest(resp);

    }

}