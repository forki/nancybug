using Nancy;

namespace xUnitNancyv2Bug
{
    public class SystemModule : LegacyNancyModule
    {
        public SystemModule()
        {
            Post["/api/system/debug/allowedroute"] = _ => 200;
        }
    }
}