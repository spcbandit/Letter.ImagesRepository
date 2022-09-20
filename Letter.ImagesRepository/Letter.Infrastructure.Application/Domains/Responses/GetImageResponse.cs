using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Letter.Infrastructure.Application.Domains.Responses;

public class GetImageResponse:BasicResponse
{
    public FileStreamResult Image { get; set; }
}