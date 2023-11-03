namespace SimpleBinary
{
    public static class SimpleBinaryEnum
    {
        /// <summary>
        /// The supported color orders.
        /// </summary>
        public enum ColorOrder
        {
            /// <summary>
            /// Red Green Blue
            /// </summary>
            RGB = 0,

            /// <summary>
            /// Blue Green Red
            /// </summary>
            BGR = 1,

            /// <summary>
            /// Red Green Blue Alpha
            /// </summary>
            RGBA = 2,

            /// <summary>
            /// Blue Green Red Alpha
            /// </summary>
            BGRA = 3,

            /// <summary>
            /// Alpha Red Green Blue
            /// </summary>
            ARGB = 4,

            /// <summary>
            /// Alpha Blue Green Red
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
        public enum VarintLengthType
        {
            /// <summary>
            /// An 8-bit int.
            /// </summary>
            Byte = 1,

            /// <summary>
            /// A 16-bit int.
            /// </summary>
            Short = 2,

            /// <summary>
            /// A 32-bit int.
            /// </summary>
            Int = 4,

            /// <summary>
            /// A 64-bit int.
            /// </summary>
            Long = 8
        }

        /// <summary>
        /// See if the selected <see cref="ColorOrder"> does not support Alpha.
        /// </summary>
        /// <param name="order">A <see cref="ColorOrder"></param>
        /// <returns>Whether or not the selected <see cref="ColorOrder"> does not support alpha.</returns>
        public static bool IsColor3(this ColorOrder order)
        {
            return order switch
            {
                ColorOrder.RGB => true,
                ColorOrder.BGR => true,
                _ => false,
            };
        }

        /// <summary>
        /// See if the selected <see cref="ColorOrder"> supports Alpha.
        /// </summary>
        /// <param name="order">A <see cref="ColorOrder"></param>
        /// <returns>Whether or not the selected <see cref="ColorOrder"> supports alpha.</returns>
        public static bool IsColor4(this ColorOrder order)
        {
            return order switch
            {
                ColorOrder.RGBA => true,
                ColorOrder.BGRA => true,
                ColorOrder.ARGB => true,
                ColorOrder.ABGR => true,
                _ => false,
            };
        }
    }
}
