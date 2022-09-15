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

}