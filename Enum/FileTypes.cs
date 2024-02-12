namespace OpenSteamworks.Utils.Enum;

/// <summary>
/// File types copied from dotnet source code
/// </summary>
public enum FileTypes : int
{
    S_IFMT = 0xF000,
    S_IFIFO = 0x1000,
    S_IFCHR = 0x2000,
    S_IFDIR = 0x4000,
    S_IFBLK = 0x6000,
    S_IFREG = 0x8000,
    S_IFLNK = 0xA000,
    S_IFSOCK = 0xC000
}