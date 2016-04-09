namespace RC.Framework.Net
{
    using System;
    using System.Threading.Tasks;
    using RMath;
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
    public interface IAsyncArchMBReader
    {
        /// <summary>
        /// Async Reading <see cref="Array"/> of <see cref="byte"/>
        /// </summary>
        /// <returns><see cref="Array"/> of <see cref="byte"/></returns>
        Task<byte[]> rByte();
        /// <summary>
        /// Async Reading <see cref="string"/>
        /// </summary>
        /// <returns><see cref="string"/></returns>
        Task<string> rString();
        /// <summary>
        /// Async Reading <see cref="short"/>
        /// </summary>
        /// <returns><see cref="short"/></returns>
        Task<short> rShort();
        /// <summary>
        /// Async Reading <see cref="float"/>
        /// </summary>
        /// <returns><see cref="float"/></returns>
        Task<float> rFloat();
        /// <summary>
        /// Async Reading <see cref="int"/>
        /// </summary>
        /// <returns><see cref="int"/></returns>
        Task<int> rInt();
        /// <summary>
        /// Async Reading <see cref="long"/>
        /// </summary>
        /// <returns><see cref="long"/></returns>
        Task<long> rLong();
        /// <summary>
        /// Async Reading <see cref="bool"/>
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        Task<bool> rBool();
        /// <summary>
        /// Async Reading <see cref="ulong"/>
        /// </summary>
        /// <returns><see cref="ulong"/></returns>
        Task<ulong> rULong();
        /// <summary>
        /// Async Reading <see cref="ushort"/>
        /// </summary>
        /// <returns><see cref="ushort"/></returns>
        Task<ushort> rUShort();
        /// <summary>
        /// Async Reading <see cref="uint"/>
        /// </summary>
        /// <returns>
        /// <see cref="uint"/>
        /// </returns>
        Task<uint> rUInt();
        /// <summary>
        /// Async Reading <see cref="Guid"/>
        /// </summary>
        /// <returns><see cref="Guid"/></returns>
        Task<Guid> rGUID();
        /// <summary>
        /// Async create a not complete copy of the current object
        /// </summary>
        /// <returns>
        /// not complete copy of the current object
        /// </returns>
        IAsyncArchMBReader Clone();
        /// <summary>
        /// Async Reading remaining byte array
        /// </summary>
        /// <returns>
        /// remaining byte array
        /// </returns>
        Task<byte[]> getRemainingBytes();
    }
}