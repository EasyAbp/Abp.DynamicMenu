using Volo.Abp.Domain.Services;
using Volo.Abp.Users;

namespace EasyAbp.Abp.DynamicMenu.Demo
{
    public abstract class DemoDomainService : DomainService
    {
        protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();
    }
}