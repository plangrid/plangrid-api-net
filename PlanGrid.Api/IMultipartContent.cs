using System.Net.Http;

namespace PlanGrid.Api
{
    public interface IMultipartContent
    {
        string Name { get; }
        void CreateContent(MultipartFormDataContent multipart);
    }
}
