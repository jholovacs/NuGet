using Ninject.Modules;

namespace NuGet.Server.Infrastructure
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            IServerPackageRepository packageRepository = new ServerPackageRepository(PackageUtility.PackagePhysicalPath);
            Bind<IHashProvider>().To<CryptoHashProvider>();
            Bind<IServerPackageRepository>().ToConstant(packageRepository);
            Bind<IPackageService>().To<PackageService>();
            Bind<IPackageAuthenticationService>().To<PackageAuthenticationService>();
			Bind<NLog.ILogger>().ToMethod(p => NLog.LogManager.GetLogger(p.Request.Target.Member.DeclaringType.ToString()));
        }
    }
}
