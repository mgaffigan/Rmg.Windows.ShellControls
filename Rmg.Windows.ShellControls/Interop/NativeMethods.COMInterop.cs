using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Rmg.Windows.ShellControls
{
    public static partial class NativeMethods
    {
        private const string Ole32 = "ole32.dll";

        [Flags]
        public enum CLSCTX : uint
        {
            INPROC_SERVER = 0x1,
            INPROC_HANDLER = 0x2,
            LOCAL_SERVER = 0x4,
            INPROC_SERVER16 = 0x8,
            REMOTE_SERVER = 0x10,
            INPROC_HANDLER16 = 0x20,
            RESERVED1 = 0x40,
            RESERVED2 = 0x80,
            RESERVED3 = 0x100,
            RESERVED4 = 0x200,
            NO_CODE_DOWNLOAD = 0x400,
            RESERVED5 = 0x800,
            NO_CUSTOM_MARSHAL = 0x1000,
            ENABLE_CODE_DOWNLOAD = 0x2000,
            NO_FAILURE_LOG = 0x4000,
            DISABLE_AAA = 0x8000,
            ENABLE_AAA = 0x10000,
            FROM_DEFAULT_CONTEXT = 0x20000,
            ACTIVATE_32_BIT_SERVER = 0x40000,
            ACTIVATE_64_BIT_SERVER = 0x80000
        }

        [DllImport(Ole32, ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern object CoCreateInstance(
           [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
           [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
           CLSCTX dwClsContext,
           [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    }

    internal static class StreamAsIStreamExtension
    {
        private class StreamAsIStream : IStream
        {
            private readonly Stream stream;

            internal StreamAsIStream(Stream backingStream)
            {
                stream = backingStream;
            }

            void IStream.Read(byte[] pv, int cb, IntPtr pcbRead)
            {
                Marshal.WriteInt32(pcbRead, stream.Read(pv, 0, cb));
            }

            void IStream.Write(byte[] pv, int cb, IntPtr pcbWritten)
            {
                stream.Write(pv, 0, cb);

                if (pcbWritten != IntPtr.Zero)
                    Marshal.WriteInt32(pcbWritten, cb);
            }

            void IStream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
            {
                long pos = stream.Seek(dlibMove, (SeekOrigin)dwOrigin);

                if (plibNewPosition != IntPtr.Zero)
                    Marshal.WriteInt64(plibNewPosition, pos);
            }

            void IStream.Stat(out STATSTG pstatstg, int grfStatFlag)
            {
                pstatstg = new STATSTG { cbSize = stream.Length, type = 2 /*STGTY_STREAM*/ };
            }

            void IStream.SetSize(long libNewSize) => stream.SetLength(libNewSize);

            void IStream.Commit(int grfCommitFlags) => stream.Flush();

            void IStream.CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten) { throw new NotImplementedException(); }

            void IStream.Clone(out IStream ppstm) { throw new NotImplementedException(); }

            void IStream.Revert() { throw new NotImplementedException(); }

            void IStream.LockRegion(long libOffset, long cb, int dwLockType) { throw new NotImplementedException(); }

            void IStream.UnlockRegion(long libOffset, long cb, int dwLockType) { throw new NotImplementedException(); }
        }

        public static IStream AsIStream(this Stream s) => new StreamAsIStream(s);
    }
}
