namespace xUnitNancyv2Bug
{
    using Nancy.Bootstrapper;

    public class AppRegistrations
    {    
        public INancyBootstrapper Bootstrapper
        { 
            get;
            set;
        }
            
        public AppRegistrations()
        {
        }
    }
}