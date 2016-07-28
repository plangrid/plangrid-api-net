using System.IO;

namespace PlanGrid.Api
{
    public class VirtualFile
    {
        public string FileName { get; set; }
        public Stream Data { get; set; }
    }
}
