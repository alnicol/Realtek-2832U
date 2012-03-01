using System;
using System.Collections;
using System.Text;

namespace RadioLib.MultiplexInformation
{
    internal class Helpers
    {
        internal static string GetAbbreviatedLabel(string label, ushort mask)
        {
            var bits = new BitArray(BitConverter.GetBytes(mask));
            var builder = new StringBuilder();
            for (var i = bits.Length - 1; i >= 0; i--)
            {
                if (bits[i])
                    builder.Append(label[bits.Length - i - 1]);
            }
            return builder.ToString().Trim();
        }
    }
}
