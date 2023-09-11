using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookReviewer.Startup))]
namespace BookReviewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
