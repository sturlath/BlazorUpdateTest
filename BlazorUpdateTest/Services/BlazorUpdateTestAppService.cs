using Volo.Abp.Application.Services;
using BlazorUpdateTest.Localization;

namespace BlazorUpdateTest.Services;

/* Inherit your application services from this class. */
public abstract class BlazorUpdateTestAppService : ApplicationService
{
    protected BlazorUpdateTestAppService()
    {
        LocalizationResource = typeof(BlazorUpdateTestResource);
    }
}