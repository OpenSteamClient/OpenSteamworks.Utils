using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenSteamworks.Extensions;

public static class BinaryReaderExtensions {
    public static T ReadStruct<T>(this BinaryReader reader) where T: unmanaged {
        unsafe {
            fixed (byte* ptr = reader.ReadBytes(sizeof(T))) {
                return Marshal.PtrToStructure<T>((nint)ptr);
            }
        }
    }

    public static object? ReadStruct(this BinaryReader reader, Type type) {
        unsafe {
            fixed (byte* ptr = reader.ReadBytes(Marshal.SizeOf(type))) {
                var structt = Marshal.PtrToStructure((nint)ptr, type);
                return structt;
            }
        }
    }

    public static string ReadNullTerminatedWideString(this BinaryReader reader)
    {
        StringBuilder builder = new();
        while (true)
        {
            char c = reader.ReadChar();
            if (c == char.MinValue) {
                break;
            }
            
            builder.Append(c);
        }
        return builder.ToString();
    }

    public static string ReadNullTerminatedUTF8String(this BinaryReader reader)
    {
        using var bytes = new MemoryStream();
        while (true)
        {
            byte c = reader.ReadByte();
            if (c == 0) {
                break;
            }
            
            bytes.WriteByte(c);
        }
        
        return Encoding.UTF8.GetString(bytes.ToArray());
    }
}