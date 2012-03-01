using System.Runtime.InteropServices;

namespace RadioLib.MultiplexInformation
{
    // ReSharper disable FieldCanBeMadeReadOnly.Local
    #pragma warning disable 649

    [StructLayout(LayoutKind.Sequential)]
    public class BaseData
    {
        [MarshalAs(UnmanagedType.U1)]
        bool isValid;

        public bool IsValid
        {
            get { return isValid; }
        }
    }

    // ReSharper restore FieldCanBeMadeReadOnly.Local
    #pragma warning restore 649
}
