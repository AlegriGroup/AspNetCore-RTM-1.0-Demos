using System.Threading.Tasks;

namespace AspNetCore_Mvc_ViewComponents_CoreFx.Services
{
    public interface IDemoService
    {
        Task<string> GetRandomStringAsync(int length);
        string GetRandomString(int length);
    }
}