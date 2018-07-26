using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Chat.Core.Extensions
{
    internal static class SecureStringExtensions
    {
        #region Public Methods

        public static string Decrypt(this SecureString secureString)
        {
            var unmanagedString = IntPtr.Zero;
            if (secureString != null)
            {
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }

            return string.Empty;
        }

        public static bool IsEqualTo(this SecureString ss1, SecureString ss2)
        {
            var bstr1 = IntPtr.Zero;
            var bstr2 = IntPtr.Zero;

            if (ss2 == null)
                return false;

            try
            {
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);
                var length1 = Marshal.ReadInt32(bstr1, -4);
                var length2 = Marshal.ReadInt32(bstr2, -4);

                if (length1 == length2)
                {
                    for (var x = 0; x < length1; ++x)
                    {
                        var b1 = Marshal.ReadByte(bstr1, x);
                        var b2 = Marshal.ReadByte(bstr2, x);
                        if (b1 != b2)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            finally
            {
                if (bstr2 != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(bstr2);
                }

                if (bstr1 != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(bstr1);
                }
            }
        }

        public static SecureString ToSecureString(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return null;
            }

            var result = new SecureString();
            foreach (var c in source)
            {
                result.AppendChar(c);
            }

            return result;
        }

        #endregion
    }
}