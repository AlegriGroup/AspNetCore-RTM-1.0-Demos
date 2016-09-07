using System.Threading.Tasks;
using AspNetCore_Mvc_ViewComponents_CoreFx.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Mvc_ViewComponents_CoreFx.ViewComponents
{
    //[ViewComponent(Name = "RandomString")] // optional
    public class RandomStringViewComponent : ViewComponent
    {
        private readonly IDemoService _demoService;

        public RandomStringViewComponent(IDemoService demoService) // injected by ASP.NET Core built in dependency injection
        {
            _demoService = demoService;
        }

        // !! use InvokeAsync -OR- Invoke


        public async Task<IViewComponentResult> InvokeAsync(int length)
        {
            string randomString = await _demoService.GetRandomStringAsync(length);
            return View("Default", randomString);
        }

        //public IViewComponentResult Invoke(int length)
        //{
        //    string randomString = _demoService.GetRandomString(length);
        //    return View(randomString);
        //}
    }
}
