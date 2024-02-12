using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Extensions;

public static class FileTypesExtensions {
    public static string ToFriendlyString(this FileTypes fileType) {
        switch (fileType)
        {
            case FileTypes.S_IFIFO:
                return "FIFO (Named Pipe)";
                
            case FileTypes.S_IFCHR:
                return "Character Device";
                
            case FileTypes.S_IFDIR:
                return "Directory";
                
            case FileTypes.S_IFBLK:
                return "Block Device";
                
            case FileTypes.S_IFREG:
                return "Regular File";
                
            case FileTypes.S_IFLNK:
                return "Symbolic Link";
                
            case FileTypes.S_IFSOCK:
                return "Socket";
                
            default:
                return "Unknown";
                
        }
    }
}