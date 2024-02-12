using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Utils;

internal static class OSSpecifics {
    public static (int permissions, FileTypes fileType) ParseZipExternalAttributesLinux(int externalAttributes) {
        int permissionsAndType = externalAttributes >> 16;
        int permissions = permissionsAndType & 0xFFF; // Mask to get the last 12 bits
        FileTypes fileType = (FileTypes)(permissionsAndType & (int)FileTypes.S_IFMT); // Mask using the S_IFMT mask
        return (permissions, fileType);
    }

    public static (int permissions, FileTypes fileType) ParseZipExternalAttributesWindows(int externalAttributes) {
        var lowerByte = (byte)(externalAttributes & 0x00FF);
        var attributes = (FileAttributes)lowerByte;
        
        if (attributes.HasFlag(FileAttributes.Directory)) {
            return (0, FileTypes.S_IFDIR);
        }

        if (attributes.HasFlag(FileAttributes.Normal) || attributes == 0) {
            return (0, FileTypes.S_IFREG);
        }

        throw new NotSupportedException("Unsupported attributes " + attributes.ToString());
    }

    public static (int permissions, FileTypes fileType) ParseZipExternalAttributesMacOS(int externalAttributes) {
        throw new NotImplementedException("Parsing zip attributes not yet implemented on macOS");
    }
}