using Letter.Infrastructure.Application.Domains.Abstractions;
using Letter.Infrastructure.Application.Domains.Entities;
using Letter.Infrastructure.Application.Domains.Requests;
using Letter.Infrastructure.Application.Domains.Responses;
using System.IO;
using System.Linq;
using MediatR;

namespace Letter.Infrastructure.Application.Handlers;

public class GetImageHandler:IRequestHandler<GetImageRequest, GetImageResponse>
{
    private readonly IRepository<Image> _repository;

    public GetImageHandler(IRepository<Image> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<GetImageResponse> Handle(GetImageRequest request, CancellationToken cancellationToken)
    {
        var image = _repository.Get(image => image.Id == request.ImageId).FirstOrDefault();
        byte[] imageBytes = System.IO.File.ReadAllBytes(Environment.CurrentDirectory + $"\\{"ImageRepository"}\\{image.FileName}");
        var memoryStream = new MemoryStream(imageBytes);
        if (memoryStream.Length != 0)
            return new GetImageResponse() 
            {
                Success = true, 
                Image = new Microsoft.AspNetCore.Mvc.FileStreamResult(memoryStream, "application/octet-stream"){FileDownloadName = image.FileName}
            };
        else
            return new GetImageResponse() { Success = false, Message = "File not created" };
    }
}