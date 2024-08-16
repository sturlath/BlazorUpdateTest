using BlazorUpdateTest.Menus;
using BlazorUpdateTest.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.UI.Navigation;

namespace BlazorUpdateTest.Menus;

public class BlazorUpdateTestMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BlazorUpdateTestResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BlazorUpdateTestMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );

        /* Example nested menu definition:

        context.Menu.AddItem(
            new ApplicationMenuItem("Menu0", "Menu Level 0")
            .AddItem(new ApplicationMenuItem("Menu0.1", "Menu Level 0.1", url: "/test01"))
            .AddItem(
                new ApplicationMenuItem("Menu0.2", "Menu Level 0.2")
                    .AddItem(new ApplicationMenuItem("Menu0.2.1", "Menu Level 0.2.1", url: "/test021"))
                    .AddItem(new ApplicationMenuItem("Menu0.2.2", "Menu Level 0.2.2")
                        .AddItem(new ApplicationMenuItem("Menu0.2.2.1", "Menu Level 0.2.2.1", "/test0221"))
                        .AddItem(new ApplicationMenuItem("Menu0.2.2.2", "Menu Level 0.2.2.2", "/test0222"))
                    )
                    .AddItem(new ApplicationMenuItem("Menu0.2.3", "Menu Level 0.2.3", url: "/test023"))
                    .AddItem(new ApplicationMenuItem("Menu0.2.4", "Menu Level 0.2.4", url: "/test024")
                        .AddItem(new ApplicationMenuItem("Menu0.2.4.1", "Menu Level 0.2.4.1", "/test0241"))
                )
                .AddItem(new ApplicationMenuItem("Menu0.2.5", "Menu Level 0.2.5", url: "/test025"))
            )
            .AddItem(new ApplicationMenuItem("Menu0.2", "Menu Level 0.2", url: "/test02"))
        );

        */

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 4;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->Tenant Management
        administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 2);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 6);

        context.Menu.AddItem(
            new ApplicationMenuItem(
                "BooksStore",
                l["Menu:BlazorUpdateTest"],
                icon: "fa fa-book"
            ).AddItem(
                new ApplicationMenuItem(
                    "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/books"
                )
            )
        );

        return Task.CompletedTask;
    }
}
