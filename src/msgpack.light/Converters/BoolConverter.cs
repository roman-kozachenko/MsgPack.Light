using System;

namespace ProGaudi.MsgPack.Converters
{
    internal sealed class BoolConverter : IMsgPackFormatter<bool>, IMsgPackParser<bool>
    {
        public int GetBufferSize(bool value) => DataLengths.Boolean;

        public bool HasConstantSize => true;

        public int Format(Span<byte> destination, bool value) => MsgPackSpec.WriteBoolean(destination, value);

        public bool Parse(Span<byte> source, out int readSize) => MsgPackSpec.ReadBoolean(source, out readSize);
    }
}