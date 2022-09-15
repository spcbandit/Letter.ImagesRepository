using Letter.Infrastructure.Application.Domains.Entities;
using Microsoft.AspNetCore.Http;

namespace Letter.Infrastructure.Application.Domains.Responses;

public class SaveImageResponse:BasicResponse
{
    public List<IFormFile> Images { get; set; }
}