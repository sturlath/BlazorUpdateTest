using BlazorUpdateTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlazorUpdateTest.Permissions;

public class BlazorUpdateTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlazorUpdateTestPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(BlazorUpdateTestPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BlazorUpdateTestPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BlazorUpdateTestPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BlazorUpdateTestPermissions.Books.Delete, L("Permission:Books.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlazorUpdateTestPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlazorUpdateTestResource>(name);
    }
}
