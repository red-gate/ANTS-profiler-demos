using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BookSearch
{
    public class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            SetManifestTokenResolver(new MyManifestTokenResolver());
        }
    }

    public class MyManifestTokenResolver : IManifestTokenResolver
    {
        public string ResolveManifestToken(DbConnection connection)
        {
            return "2012";
        }
    }
}