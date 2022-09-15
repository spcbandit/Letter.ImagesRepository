using Letter.Infrastructure.Application.Domains.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Letter.Infrastructure.Application.Domains.Requests;

public class SaveImageRequest:IRequest<SaveImageResponse>
{
    public Guid OwnerId { get; set; }
    public List<IFormFile> Images { get; set; }
}