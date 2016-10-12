namespace RC.Framework.Net
{
    /// <summary>
    /// Interface reader in "box"
    /// </summary>
    /// <c>
    /// Of Fire Twins Wesp 2014-2016
    /// Alise Wesp and Yuuki Wesp
    /// </c>
    /// <license type="MIT" path="root\\LICENSE"/>
    /// <version>
    /// 9.0
    /// </version>
    public interface IArchByteBoxReader
    {
        /// <summary>
        /// Reading <see cref="System.Array"/> of <see cref="byte"/>
        /// </summary>
        /// <returns><see cref="System.Array"/> of <see cref="byte"/></returns>
        byte[] rByte();
        /// <summary>
        /// Reading <see cref="string"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        string rString();
        /// <summary>
        /// Reading <see cref="short"/>
        /// </summary>
        /// <returns><see cref="short"/></returns>
        short rShort();
        /// <summary>
        /// Reading <see cref="float"/>
        /// </summary>
        /// <returns><see cref="float"/></returns>
        float rFloat();
        /// <summary>
        /// Reading <see cref="int"/>
        /// </summary>
        /// <returns><see cref="int"/></returns>
        int rInt();
        /// <summary>
        /// Reading <see cref="long"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        long rLong();
        /// <summary>
        /// Reading <see cref="bool"/>
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        bool rBool();
        /// <summary>
        /// Reading <see cref="ulong"/>
        /// </summary>
        /// <returns><see cref="ulong"/></returns>
        ulong rULong();
        /// <summary>
        /// Reading <see cref="ushort"/>
        /// </summary>
        /// <returns><see cref="ushort"/></returns>
        ushort rUShort();
        /// <summary>
        /// Reading <see cref="uint"/>
        /// </summary>
        /// <returns>
        /// <see cref="uint"/>
        /// </returns>
        uint rUInt();
        /// <summary>
        /// Reading <see cref="System.DateTime.Ticks"/>
        /// </summary>
        /// <returns><see cref="System.DateTime"/></returns>
        System.DateTime rDateTime();
        /// <summary>
        /// Reading <see cref="System.Guid"/>
        /// </summary>
        /// <returns><see cref="System.Guid"/></returns>
        System.Guid rGUID();
        /// <summary>
        /// It creates a not complete copy of the current object
        /// </summary>
        /// <returns>
        /// not complete copy of the current object
        /// </returns>
        IArchByteBoxReader Clone();
        /// <summary>
        /// Reading remaining byte array
        /// </summary>
        /// <returns>
        /// remaining byte array
        /// </returns>
        byte[] getRemainingBytes();
    }
}