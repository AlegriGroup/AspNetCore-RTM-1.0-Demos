using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Mvc_ViewComponents_CoreFx.ViewComponents
{
    public class AlegriAddressViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
