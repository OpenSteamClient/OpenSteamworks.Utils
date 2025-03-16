using System.Buffers.Binary;
using System.IO;
using System.Text;
using OpenSteamworks.Utils.Enum;

namespace OpenSteamworks.Utils;

public class EndianAwareBinaryReader : BinaryReader
{
    private readonly Endianness _endianness = Endianness.Little;

    public EndianAwareBinaryReader(Stream input) : base(input)
    {
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(
        input, encoding, leaveOpen)
    {
    }

    public EndianAwareBinaryReader(Stream input, Endianness endianness) : base(input)
    {
        _endianness = endianness;
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding, Endianness endianness) :
        base(input, encoding)
    {
        _endianness = endianness;
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen,
        Endianness endianness) : base(input, encoding, leaveOpen)
    {
        _endianness = endianness;
    }

    /// <summary>
    /// Reads at least a minimum number of bytes from the current stream and advances the position within the stream by the number of bytes read.
    /// </summary>
    /// <param name="minimumBytes">The minimum number of bytes to read into the buffer.</param>
    /// <exception cref="ArgumentOutOfRangeException">minimumBytes is negative, or is greater than the length of buffer.</exception>
    /// <exception cref="EndOfStreamException">The end of the stream is reached before reading minimumBytes bytes of data.</exception>
    /// <returns>The bytes requested.</returns>
    public byte[] ReadAtLeast(int minimumBytes)
    {
        byte[] arr = new byte[minimumBytes];
        BaseStream.ReadAtLeast(arr, minimumBytes);
        return arr;
    }

    public override short ReadInt16() => ReadInt16(_endianness);

    public override int ReadInt32() => ReadInt32(_endianness);

    public override long ReadInt64() => ReadInt64(_endianness);

    public override ushort ReadUInt16() => ReadUInt16(_endianness);

    public override uint ReadUInt32() => ReadUInt32(_endianness);

    public override ulong ReadUInt64() => ReadUInt64(_endianness);

    public short ReadInt16(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadInt16LittleEndian(ReadAtLeast(sizeof(short)))
        : BinaryPrimitives.ReadInt16BigEndian(ReadAtLeast(sizeof(short)));

    public int ReadInt32(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadInt32LittleEndian(ReadAtLeast(sizeof(int)))
        : BinaryPrimitives.ReadInt32BigEndian(ReadAtLeast(sizeof(int)));

    public long ReadInt64(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadInt64LittleEndian(ReadAtLeast(sizeof(long)))
        : BinaryPrimitives.ReadInt64BigEndian(ReadAtLeast(sizeof(long)));

    public ushort ReadUInt16(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadUInt16LittleEndian(ReadAtLeast(sizeof(ushort)))
        : BinaryPrimitives.ReadUInt16BigEndian(ReadAtLeast(sizeof(ushort)));

    public uint ReadUInt32(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadUInt32LittleEndian(ReadAtLeast(sizeof(uint)))
        : BinaryPrimitives.ReadUInt32BigEndian(ReadAtLeast(sizeof(uint)));

    public ulong ReadUInt64(Endianness endianness) => endianness == Endianness.Little
        ? BinaryPrimitives.ReadUInt64LittleEndian(ReadAtLeast(sizeof(ulong)))
        : BinaryPrimitives.ReadUInt64BigEndian(ReadAtLeast(sizeof(ulong)));
}