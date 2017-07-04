using CKSource.CKFinder.Connector.Config;
using CKSource.CKFinder.Connector.Core.Builders;
using CKSource.CKFinder.Connector.Host.Owin;
using CKSource.FileSystem.Local;
using Microsoft.Owin;
using Owin;
using System.Configuration;
using VShop.Web.Configurations;

[assembly: OwinStartup(typeof(VShop.Web.App_Start.Startup))]

namespace VShop.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfiguration.Config(app);
            AutoMapperConfiguration.Configure();
            ConfigureAuth(app);
            GlobalConfig.JsonFormatterConfig();

            /*
            * If you installed CKSource.CKFinder.Connector.Logs.NLog you can start the logger:
            * LoggerManager.LoggerAdapterFactory = new NLogLoggerAdapterFactory();
            * Keep in mind that the logger should be initialized only once and before any other
            * CKFinder method is invoked.
            */
            /*
             * Register the "local" type backend file system.
             */
            FileSystemFactory.RegisterFileSystem<LocalStorage>();
            /*
             * Map the CKFinder connector service under a given path. By default the CKFinder JavaScript
             * client expect the ASP.NET connector to be accessible under the "/ckfinder/connector" route.
             */
            app.Map("/ckfinder/connector", SetupConnector);

        }
        public static void SetupConnector(IAppBuilder builder)
        {
            var allowedRoleMatcherTemplate = ConfigurationManager.AppSettings["ckfinderAllowedRole"];
            var authenticator = new RoleBasedAuthenticator(allowedRoleMatcherTemplate);

            var connectorFactory = new OwinConnectorFactory();
            var connectorBuilder = new ConnectorBuilder();
            var connector = connectorBuilder
                .LoadConfig()
                .SetAuthenticator(authenticator)
                .SetRequestConfiguration(
                    (request, config) =>
                    {
                        config.LoadConfig();

                        var defaultBackend = config.GetBackend("default");
                        //var keyValueStoreProvider = new FileSystemKeyValueStoreProvider(defaultBackend);
                        //config.SetKeyValueStoreProvider(keyValueStoreProvider);
                    })
                .Build(connectorFactory);

            builder.UseConnector(connector);
        }
    }
}