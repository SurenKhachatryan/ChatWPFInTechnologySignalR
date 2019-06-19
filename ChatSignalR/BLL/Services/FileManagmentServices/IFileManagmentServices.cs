using BLL.DomainModels;
using System.Threading.Tasks;

namespace BLL.Services.FileManagmentServices
{
    public interface IFileManagmentServices
    {
        Task UploadFile(BaseFileInfo fileInfo);
        Task UploadFiles(BaseFileInfo fileInfo);
        Task DeleteFiles(BaseFileInfo fileInfo);
    }
}
