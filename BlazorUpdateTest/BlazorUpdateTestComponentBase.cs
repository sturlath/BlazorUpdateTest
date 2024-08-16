using BlazorUpdateTest.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BlazorUpdateTest;

public abstract class BlazorUpdateTestComponentBase : AbpComponentBase
{
    protected BlazorUpdateTestComponentBase()
    {
        LocalizationResource = typeof(BlazorUpdateTestResource);
    }
}
