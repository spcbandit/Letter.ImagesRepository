using Letter.Infrastructure.Application.Domains.Entities;
using Letter.Infrastructure.Application.Domains.Responses;
using MediatR;

namespace Letter.Infrastructure.Application.Domains.Requests;

public class GetImageRequest:IRequest<GetImageResponse>
{
    public Guid OwnerId { get; set; }
    public Guid ImageId { get; set; }
}