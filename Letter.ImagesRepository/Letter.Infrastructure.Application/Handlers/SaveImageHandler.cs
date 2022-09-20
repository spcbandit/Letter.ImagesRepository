using Letter.Infrastructure.Application.Domains.Abstractions;
using Letter.Infrastructure.Application.Domains.Entities;
using Letter.Infrastructure.Application.Domains.Requests;
using Letter.Infrastructure.Application.Domains.Responses;
using MediatR;

namespace Letter.Infrastructure.Application.Handlers;

public class SaveImageHandler:IRequestHandler<SaveImageRequest, SaveImageResponse>
{
    private readonly IRepository<Image> _repository;
    
    public SaveImageHandler(IRepository<Image> repository)
    {
        _repository = repository;
    }
    public async Task<SaveImageResponse> Handle(SaveImageRequest request, CancellationToken cancellationToken)
    {
        var uploadPath = $"{Environment.CurrentDirectory}\\{"ImageRepository"}\\";
        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        foreach (var img in request.Images)
        {
            var path = uploadPath + img.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
                await img.CopyToAsync(fileStream);
            var save = _repository.Create(new Image() 
            {
                ByteLength = img.Length, 
                Extension = Path.GetExtension(img.FileName),
                Path = uploadPath + img.FileName,
                FileName = img.FileName,
                OwnerId = request.OwnerId,
                DateTime = DateTime.Now,
            });
        }

        return new SaveImageResponse() { Success = true };
    }
}