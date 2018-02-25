/*
https://github.com/lolp1/Process.NET/blob/master/src/Process.NET/Marshaling/MarshalType.cs
https://github.com/ZenLulz/MemorySharp/blob/master/src/MemorySharp/Internals/MarshalType.cs
https://github.com/ZenLulz/MemorySharp/blob/master/src/MemorySharp/Memory/LocalUnmanagedMemory.cs
*/

// ReSharper disable StaticMemberInGenericType

// ReSharper disable SwitchStatementMissingSomeCases

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FF12PCRNGHelper
{
    public static class MarshalType<T>
    {
        #region Constructors and Destructors

        static MarshalType()
        {
            Type = typeof(T);
            IsIntPtr = Type == typeof(IntPtr);
            TypeCode = Type.GetTypeCode(Type);

            switch (TypeCode)
            {
                case TypeCode.Boolean:
                    Size = 1;
                    return;
                case TypeCode.Char:
                    Size = 1;
                    return;
                case TypeCode.SByte:
                    Size = 1;
                    return;
                case TypeCode.Byte:
                    Size = 1;
                    return;
                case TypeCode.Int16:
                    Size = 2;
                    return;
                case TypeCode.UInt16:
                    Size = 2;
                    return;
                case TypeCode.Int32:
                    Size = 4;
                    return;
                case TypeCode.UInt32:
                    Size = 4;
                    return;
                case TypeCode.Int64:
                    Size = 8;
                    return;
                case TypeCode.UInt64:
                    Size = 8;
                    return;
                case TypeCode.Single:
                    Size = 4;
                    return;
                case TypeCode.Double:
                    Size = 8;
                    return;
            }

            Size = Marshal.SizeOf(Type);
        }

        #endregion

        #region Static Fields

        /// <summary>
        ///     If T is IntPtr or not
        /// </summary>
        public static bool IsIntPtr;

        /// <summary>
        ///     Size of T
        /// </summary>
        public static int Size;

        /// <summary>
        ///     The Type of T
        /// </summary>
        public static Type Type;

        /// <summary>
        ///     TypeCode of T
        /// </summary>
        public static TypeCode TypeCode;

        #endregion

        #region Public Methods and Operators

        public static T ByteArrayToObject(byte[] btArray, int index = 0)
        {
            switch (TypeCode)
            {
                case TypeCode.Object:
                    if (IsIntPtr)
                    {
                        switch (btArray.Length)
                        {
                            case 1:
                                return (T) (object) new IntPtr(BitConverter.ToInt32(new byte[] {btArray[0], 0, 0, 0},
                                    index));
                            case 2:
                                return (T) (object) new IntPtr(
                                    BitConverter.ToInt32(new byte[] {btArray[0], btArray[1], 0, 0}, index));
                            case 4:
                                return (T) (object) new IntPtr(BitConverter.ToInt32(btArray, index));
                            case 8:
                                return (T) (object) new IntPtr(BitConverter.ToInt64(btArray, index));
                        }
                    }

                    break;
                case TypeCode.Boolean:
                    return (T) (object) BitConverter.ToBoolean(btArray, index);
                case TypeCode.Char:
                    return (T) (object) Encoding.UTF8.GetChars(btArray)[index];
                case TypeCode.Byte:
                    return (T) (object) btArray[index];
                case TypeCode.Int16:
                    return (T) (object) BitConverter.ToInt16(btArray, index);
                case TypeCode.UInt16:
                    return (T) (object) BitConverter.ToUInt16(btArray, index);
                case TypeCode.Int32:
                    return (T) (object) BitConverter.ToInt32(btArray, index);
                case TypeCode.UInt32:
                    return (T) (object) BitConverter.ToUInt32(btArray, index);
                case TypeCode.Int64:
                    return (T) (object) BitConverter.ToInt64(btArray, index);
                case TypeCode.UInt64:
                    return (T) (object) BitConverter.ToUInt64(btArray, index);
                case TypeCode.Single:
                    return (T) (object) BitConverter.ToSingle(btArray, index);
                case TypeCode.Double:
                    return (T) (object) BitConverter.ToDouble(btArray, index);
            }

            var ptr = Marshal.AllocHGlobal(Size);
            Marshal.Copy(btArray, index, ptr, Size);
            var rtn = Marshal.PtrToStructure<T>(ptr);
            Marshal.FreeHGlobal(ptr);
            return rtn;
        }

        public static byte[] ObjectToByteArray(T obj, bool? intptr64Bit = null)
        {
            switch (TypeCode)
            {
                case TypeCode.Object:
                    if (IsIntPtr)
                    {
                        if (intptr64Bit.HasValue)
                        {
                            Size = intptr64Bit.Value ? 8 : 4;
                        }

                        switch (Size)
                        {
                            case 4:
                                return BitConverter.GetBytes(((IntPtr) (object) obj).ToInt32());
                            case 8:
                                return BitConverter.GetBytes(((IntPtr) (object) obj).ToInt64());
                        }
                    }

                    break;
                case TypeCode.Boolean:
                    return BitConverter.GetBytes((bool) (object) obj);
                case TypeCode.Char:
                    return Encoding.UTF8.GetBytes(new[] {(char) (object) obj});
                case TypeCode.Byte:
                    return new[] {(byte) (object) obj};
                case TypeCode.Int16:
                    return BitConverter.GetBytes((short) (object) obj);
                case TypeCode.UInt16:
                    return BitConverter.GetBytes((ushort) (object) obj);
                case TypeCode.Int32:
                    return BitConverter.GetBytes((int) (object) obj);
                case TypeCode.UInt32:
                    return BitConverter.GetBytes((uint) (object) obj);
                case TypeCode.Int64:
                    return BitConverter.GetBytes((long) (object) obj);
                case TypeCode.UInt64:
                    return BitConverter.GetBytes((ulong) (object) obj);
                case TypeCode.Single:
                    return BitConverter.GetBytes((float) (object) obj);
                case TypeCode.Double:
                    return BitConverter.GetBytes((double) (object) obj);
            }

            var ptr = Marshal.AllocHGlobal(Size);
            Marshal.StructureToPtr(obj, ptr, false);
            var rtn = new byte[Size];
            Marshal.Copy(ptr, rtn, 0, Size);
            Marshal.FreeHGlobal(ptr);
            return rtn;
        }

        #endregion
    }
}