using System.Diagnostics.CodeAnalysis;

namespace OpenSteamworks.Extensions;

public static class FileInfoExtensions
{
    public static bool IsLink(this FileInfo di) {
        return di.LinkTarget != null;
    }
}
