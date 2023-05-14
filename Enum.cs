namespace SimpleStream
{
    public static class SimpleEnum
    {
        /// <summary>
        /// The supported color orders.
        /// </summary>
        public enum ColorOrder
        {
            /// <summary>
            /// Red green blue
            /// </summary>
            RGB = 0,

            /// <summary>
            /// Blue green red
            /// </summary>
            BGR = 1,

            /// <summary>
            /// Red green blue alpha
            /// </summary>
            RGBA = 2,

            /// <summary>
            /// Blue green red alpha
            /// </summary>
            BGRA = 3,

            /// <summary>
            /// Alpha red green blue
            /// </summary>
            ARGB = 4,

            /// <summary>
            /// Alpha blue green red
            /// </summary>
            ABGR = 5
        }

        /// <summary>
        /// The orders of a vector2.
        /// </summary>
        public enum Vector2Order
        {
            /// <summary>
            /// X Y
            /// </summary>
            XY = 0,

            /// <summary>
            /// Y X
            /// </summary>
            YX = 1
        }

        /// <summary>
        /// The supported orders of a vector3.
        /// </summary>
        public enum Vector3Order
        {
            /// <summary>
            /// X Y Z
            /// </summary>
            XYZ = 0,

            /// <summary>
            /// X Z Y
            /// </summary>
            XZY = 1,

            /// <summary>
            /// Z Y X
            /// </summary>
            ZYX = 2,

            /// <summary>
            /// Y Z X
            /// </summary>
            YZX = 3,
        }

        /// <summary>
        /// The supported orders of a vector4.
        /// </summary>
        public enum Vector4Order
        {
            /// <summary>
            /// X Y Z W
            /// </summary>
            XYZW = 0,

            /// <summary>
            /// X Z Y W
            /// </summary>
            XZYW = 1,

            /// <summary>
            /// W Z Y X
            /// </summary>
            WZYX = 2,

            /// <summary>
            /// W Y Z X
            /// </summary>
            WYZX = 3,
        }

        /// <summary>
        /// The supported varint lengths.
        /// </summary>
        public enum VarintLength
        {
            /// <summary>
            /// A 32-bit int.
            /// </summary>
            Int = 4,

            /// <summary>
            /// A 64-bit int.
            /// </summary>
            Long = 8
        }
    }
}
