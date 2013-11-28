namespace Hazelcast.IO.Serialization
{
    public sealed class ConstantSerializers
    {
        private ConstantSerializers()
        {
        }

        public sealed class BooleanSerializer : SingletonSerializer<bool>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeBoolean;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, bool obj)
            {
                output.Write((obj ? 1 : 0));
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override bool Read(IObjectDataInput input)
            {
                return input.ReadByte() != 0;
            }
        }

        public sealed class ByteSerializer : SingletonSerializer<byte>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeByte;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override byte Read(IObjectDataInput input)
            {
                return input.ReadByte();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, byte obj)
            {
                output.WriteByte(obj);
            }
        }

        public sealed class CharArraySerializer : SingletonSerializer<char[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeCharArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override char[] Read(IObjectDataInput input)
            {
                return input.ReadCharArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, char[] obj)
            {
                output.WriteCharArray(obj);
            }
        }

        public sealed class CharSerializer : SingletonSerializer<char>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeChar;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override char Read(IObjectDataInput input)
            {
                return input.ReadChar();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, char obj)
            {
                output.WriteChar(obj);
            }
        }

        public sealed class DoubleArraySerializer : SingletonSerializer<double[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeDoubleArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override double[] Read(IObjectDataInput input)
            {
                return input.ReadDoubleArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, double[] obj)
            {
                output.WriteDoubleArray(obj);
            }
        }

        public sealed class DoubleSerializer : SingletonSerializer<double>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeDouble;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override double Read(IObjectDataInput input)
            {
                return input.ReadDouble();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, double obj)
            {
                output.WriteDouble(obj);
            }
        }

        public sealed class FloatArraySerializer : SingletonSerializer<float[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeFloatArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override float[] Read(IObjectDataInput input)
            {
                return input.ReadFloatArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, float[] obj)
            {
                output.WriteFloatArray(obj);
            }
        }

        public sealed class FloatSerializer : SingletonSerializer<float>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeFloat;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override float Read(IObjectDataInput input)
            {
                return input.ReadFloat();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, float obj)
            {
                output.WriteFloat(obj);
            }
        }

        public sealed class IntegerArraySerializer : SingletonSerializer<int[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeIntegerArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override int[] Read(IObjectDataInput input)
            {
                return input.ReadIntArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, int[] obj)
            {
                output.WriteIntArray(obj);
            }
        }

        public sealed class IntegerSerializer : SingletonSerializer<int>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeInteger;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override int Read(IObjectDataInput input)
            {
                return input.ReadInt();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, int obj)
            {
                output.WriteInt(obj);
            }
        }

        public sealed class LongArraySerializer : SingletonSerializer<long[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeLongArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override long[] Read(IObjectDataInput input)
            {
                return input.ReadLongArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, long[] obj)
            {
                output.WriteLongArray(obj);
            }
        }

        public sealed class LongSerializer : SingletonSerializer<long>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeLong;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override long Read(IObjectDataInput input)
            {
                return input.ReadLong();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, long obj)
            {
                output.WriteLong(obj);
            }
        }

        public sealed class ShortArraySerializer : SingletonSerializer<short[]>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeShortArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override short[] Read(IObjectDataInput input)
            {
                return input.ReadShortArray();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, short[] obj)
            {
                output.WriteShortArray(obj);
            }
        }

        public sealed class ShortSerializer : SingletonSerializer<short>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeShort;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override short Read(IObjectDataInput input)
            {
                return input.ReadShort();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, short obj)
            {
                output.WriteShort(obj);
            }
        }

        public abstract class SingletonSerializer<T> : IStreamSerializer<T>
        {
            public virtual void Destroy()
            {
            }

            public abstract int GetTypeId();

            public abstract T Read(IObjectDataInput arg1);

            public abstract void Write(IObjectDataOutput arg1, T arg2);
        }

        public sealed class StringSerializer : SingletonSerializer<string>
        {
            public override int GetTypeId()
            {
                return SerializationConstants.ConstantTypeString;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override string Read(IObjectDataInput input)
            {
                return input.ReadUTF();
            }

            /// <exception cref="System.IO.IOException"></exception>
            public override void Write(IObjectDataOutput output, string obj)
            {
                output.WriteUTF(obj);
            }
        }

        public sealed class TheByteArraySerializer : IByteArraySerializer<byte[]>
        {
            public int GetTypeId()
            {
                return SerializationConstants.ConstantTypeByteArray;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public byte[] Write(byte[] @object)
            {
                return @object;
            }

            /// <exception cref="System.IO.IOException"></exception>
            public byte[] Read(byte[] buffer)
            {
                return buffer;
            }

            public void Destroy()
            {
            }
        }
    }
}