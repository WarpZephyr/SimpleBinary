using System.Text;

namespace SimpleStream
{
    /// <summary>
    /// A class for easier access to different encodings.
    /// </summary>
    public static class SimpleEncoding
    {
        /// <summary>
        /// ASCII encoding.
        /// </summary>
        public static readonly Encoding ASCII;

        /// <summary>
        /// Japanese Shift-JIS encoding.
        /// </summary>
        public static readonly Encoding ShiftJIS;

        /// <summary>
        /// Japanese EUC-JP encoding.
        /// </summary>
        public static readonly Encoding EucJP;

        /// <summary>
        /// Chinese Simplified EUC-CN encoding.
        /// </summary>
        public static readonly Encoding EucCN;

        /// <summary>
        /// Korean EUC-KR encoding.
        /// </summary>
        public static readonly Encoding EucKR;

        /// <summary>
        /// UTF8 encoding.
        /// </summary>
        public static readonly Encoding UTF8;

        /// <summary>
        /// UTF-16 or Unicode encoding.
        /// </summary>
        public static readonly Encoding UTF16;

        /// <summary>
        /// UTF-16 or Unicode encoding in big endian.
        /// </summary>
        public static readonly Encoding UTF16BE;

        static SimpleEncoding()
        {
#if NETSTANDARD
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
            ASCII = Encoding.ASCII;
            ShiftJIS = Encoding.GetEncoding("shift_jis");
            EucJP = Encoding.GetEncoding("euc-jp");
            EucCN = Encoding.GetEncoding("EUC-CN");
            EucKR = Encoding.GetEncoding("euc-kr");
            UTF8 = Encoding.UTF8;
            UTF16 = Encoding.Unicode;
            UTF16BE = Encoding.BigEndianUnicode;
        }
    }
}