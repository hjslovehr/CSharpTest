using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MarshalTest
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Data
    {
        public short Tag;

        public int Length;
    }

    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Press any key to close the application.");
            Console.ReadKey();
        }

        static unsafe void Test()
        {
            var bytes = new byte[100];    // 2(T) + 4(L) + 94(V)

            short tag = 0xff;
            byte* pby = (byte*)&tag;

            bytes[0] = pby[0];
            bytes[1] = pby[1];

            string context = "hello,world!";
            var bs = Encoding.ASCII.GetBytes(context);
            Buffer.BlockCopy(bs, 0, bytes, 6, bs.Length);

            int length = context.Length;
            pby = (byte*)&length;

            bytes[2] = pby[0];
            bytes[3] = pby[1];
            bytes[4] = pby[2];
            bytes[5] = pby[3];

            fixed (byte* bp0 = &bytes[0])
            {
                short* pus = (short*)bp0;
                Console.WriteLine(*pus);
            }

            fixed (byte* bp1 = &bytes[2])
            {
                int* pui = (int*)bp1;
                Console.WriteLine(*pui);
            }
            
            var size = sizeof(Data);
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, 0, ptr, size);
            var data = (Data)Marshal.PtrToStructure(ptr, typeof(Data));

            Marshal.FreeHGlobal(ptr);

            Console.WriteLine("data.Tag : " + data.Tag);
            Console.WriteLine("data.Length : " + data.Length);

            var value = new byte[data.Length];
            Buffer.BlockCopy(bytes, size, value, 0, data.Length);

            Console.WriteLine("value : " + Encoding.ASCII.GetString(value));
        }

    }
}
