namespace Letter.Infrastructure.Application.Domains.Entities;

public class Image
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Extension { get; set; }
    public string FileName { get; set; }
    public string Path { get; set; }
    public long ByteLength { get; set; }
    public DateTime DateTime { get; set; }

}