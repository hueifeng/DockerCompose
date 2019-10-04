using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceStack.Redis;

namespace DockerComposeDemo.Pages
{
    public class IndexModel : PageModel
    {

        private readonly RedisManagerPool redisManger = new RedisManagerPool("172.17.0.1:6379");
        public void OnGet()
        {
            using (var db = redisManger.GetClient()) {
                ViewData["num"] = db.IncrementValue("count");
            } 
        }
    }
}
