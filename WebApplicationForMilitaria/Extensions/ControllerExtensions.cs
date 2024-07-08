using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplicationForMilitaria.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string type, string message) 
        {
            var notification = new Models.Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
