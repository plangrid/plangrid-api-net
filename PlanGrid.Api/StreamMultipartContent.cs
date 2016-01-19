using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PlanGrid.Api
{
    public class StreamMultipartContent : IMultipartContent
    {
        public string Name { get; }
        public string FileName { get; }
        public string ContentType { get; }
        public Stream Content { get; }

        public StreamMultipartContent(string name, string fileName, string contentType, Stream content)
        {
            Name = name;
            FileName = fileName;
            ContentType = contentType;
            Content = content;
        }

        public void CreateContent(MultipartFormDataContent multipart)
        {
            var content = new StreamContent(Content);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(ContentType);
            multipart.Add(content, Name, FileName);
        }
    }
}
