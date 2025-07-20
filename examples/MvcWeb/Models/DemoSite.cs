using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Piranha.Extend.Fields;
using Microsoft.AspNetCore.Components.Routing;

namespace MvcWeb.Models;

[SiteType(Title = "Demo site")]
public class DemoSite : SiteContent<DemoSite>
{
    [Region(Title = "Footer", Display = RegionDisplayMode.Setting)]
    public Footer FooterContents { get; set; }
}

public class Footer
{
    [Field(Title = "Footer logo")]
    public ImageField Logo { get; set; }

    [Field(Title = "Footer text")]
    public HtmlField Text { get; set; }

    [Field(Title = "Company Name")]
    public TextField CompanyName { get; set; }
}