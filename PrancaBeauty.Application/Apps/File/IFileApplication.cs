using PrancaBeauty.Application.Contracts.Files;
using PrancaBeauty.Application.Contracts.Result;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.File
{
    public interface IFileApplication
    {
        Task<OperationResult> AddFileAsync(InpAddFile Input);
        Task<OutGetFileInfo> GetFileInfoAsync(string FileId, string UserId = null);
        Task<OperationResult> RemoveFileAsync(string FileId, string UserId = null);
    }
}
