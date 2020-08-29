using System;
using System.Collections.Generic;
using System.Text;

namespace PortalCorreios.Utils.Helpers
{
    public static class ArquivoHelpers
    {
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}