using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Services
{
    public interface IPhotoPicker
    {
        Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension);
    }
}
