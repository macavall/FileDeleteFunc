using System.Threading.Tasks;

public interface IFileService
{
    public Task WriteFile();
    public Task DeleteFile();
    public Task WriteFile(int loopNumber);
}