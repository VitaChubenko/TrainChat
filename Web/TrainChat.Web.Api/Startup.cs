using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TrainChat.Web.Api.Startup))]

namespace TrainChat.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
