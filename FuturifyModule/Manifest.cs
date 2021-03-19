using OrchardCore.Modules;
using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "FuturifyModule",
    Author = "Bui Phan Tho",
    Website = "https://futurify.io",
    Version = "1.0.0-rc2",
    Description = "Futurify Module",
    Category = "Content Management",
    Dependencies = new[]
    {
        "OrchardCore.Contents",
        "OrchardCore.ContentTypes",
        "OrchardCore.ContentFields",
    }
)]
