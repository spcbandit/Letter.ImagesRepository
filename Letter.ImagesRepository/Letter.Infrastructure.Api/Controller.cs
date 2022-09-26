using System.ComponentModel;
using Letter.Infrastructure.Application.Domains.Requests;
using Letter.Infrastructure.Application.Domains.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Letter.Infrastructure.Api;
[ApiController]
[Route("/image")]
[DisplayName("Работа с изображениями")]
[Produces("application/json")]
public class Controller:ControllerBase
{
    private readonly IMediator _mediator;
    public Controller(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    [Route("SaveImage")]
    [SwaggerResponse(StatusCodes.Status200OK, "Сохранить ", typeof(SaveImageResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Save = fail", typeof(SaveImageResponse))]
    public async Task<JsonResult> SavePicture([FromForm] SaveImageRequest request)
    {
        Request.ContentType = "multipart/form-data";
        var resp = await _mediator.Send(request);
        if (resp.Success)
            return new JsonResult(Ok(resp));
        else
            return new JsonResult(BadRequest(resp));

    }
    [HttpGet]
    [Route("GetImage")]
    [SwaggerResponse(StatusCodes.Status200OK, "Сохранить ", typeof(GetImageResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Save = fail", typeof(GetImageResponse))]
    public async Task<IActionResult> GetPicture([FromQuery] GetImageRequest request)
    {
        var resp = await _mediator.Send(request);

        if (resp.Success)
            return resp.Image;
        else
            return BadRequest(resp);

    }

}