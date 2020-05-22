using System.Threading.Tasks;

namespace MobileKidsIdApp.Platform
{
    public interface IPhotoPicker
    {
        Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension);
    }
}
