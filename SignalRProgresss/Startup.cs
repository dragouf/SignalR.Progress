using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRProgresss.Startup))]
namespace SignalRProgresss
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //ConfigureAuth(app);
        }
    }
}
