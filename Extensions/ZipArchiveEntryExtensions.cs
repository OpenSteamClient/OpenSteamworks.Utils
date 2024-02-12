using System.IO.Compression;
using OpenSteamworks.Utils;
using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Extensions;

public static class ZipArchiveEntryExtensions {
    public static bool IsSymlink(this ZipArchiveEntry entry) {
        return GetFileType(entry) == FileTypes.S_IFLNK;
    }

    public static bool IsDirectory(this ZipArchiveEntry entry) {
        return GetFileType(entry) == FileTypes.S_IFDIR;
    }

    public static bool IsRegularFile(this ZipArchiveEntry entry) {
        return GetFileType(entry) == FileTypes.S_IFREG;
    }

    public static FileTypes GetFileType(this ZipArchiveEntry entry) {
        if (OperatingSystem.IsWindows()) {
            return OSSpecifics.ParseZipExternalAttributesWindows(entry.ExternalAttributes).fileType;
        } else if (OperatingSystem.IsLinux()) {
            return OSSpecifics.ParseZipExternalAttributesLinux(entry.ExternalAttributes).fileType;
        } else if (OperatingSystem.IsMacOS()) {
            return OSSpecifics.ParseZipExternalAttributesMacOS(entry.ExternalAttributes).fileType;
        } else {
            throw new NotImplementedException("No support for your platform (yet)");
        }
    }

}

