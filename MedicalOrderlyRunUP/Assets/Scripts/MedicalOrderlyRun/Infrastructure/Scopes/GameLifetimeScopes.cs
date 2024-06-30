using VContainer;
using VContainer.Unity;

namespace MedicalOrderlyRun.Infrastructure.Scopes
{
    public class GameLifetimeScopes : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Boot>();
        }
    }
}
