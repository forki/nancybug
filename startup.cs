using Owin;

namespace xUnitNancyv2Bug
{
    public class Startup
    {
        AppRegistrations appRegistrations;

        public Startup(AppRegistrations appRegistrations)
        {
            this.appRegistrations = appRegistrations;
        }

        public Startup()
            : this(null)
        {

        }

        public void Configuration(IAppBuilder app)
        {
            //Other MW removed for clarity
            app.UseNancy(options => options.Bootstrapper = this.appRegistrations.Bootstrapper);
        }
    }
}