#if UNIX
#pragma warning disable CS1591
namespace RC.Framework.Native.Unix.Time
{
    using System;
    using System.Globalization;
    public struct UnixTimestamp
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public long SecondsSinceEpoch => secondsSinceEpoch;
        private readonly long secondsSinceEpoch;
        public UnixTimestamp(long secondsSinceEpoch)
        {
            this.secondsSinceEpoch = secondsSinceEpoch;
        }
        public static bool TryParse(string value, out UnixTimestamp result)
        {
            result = new UnixTimestamp();

            long seconds;
            if (!long.TryParse(value, out seconds))
                return false;

            result = new UnixTimestamp(seconds);
            return true;
        }
        /// <summary>
        /// Adds the specified <see cref="UnixTimestamp" /> to this instance
        /// and returns a new instance of UnixTimestamp
        /// </summary>
        public UnixTimestamp Add(UnixTimestamp unixTimestamp)
        {
            return new UnixTimestamp(secondsSinceEpoch + unixTimestamp);
        }
        public static UnixTimestamp FromDateTime(DateTime dateTime)
        {
            return (UnixTimestamp)dateTime;
        }
        public static explicit operator UnixTimestamp(DateTime dateTime)
        {
            var secondsSinceEpoc = (long)(dateTime - Epoch).TotalSeconds;
            return new UnixTimestamp(secondsSinceEpoc);
        }
        public static implicit operator long (UnixTimestamp timestamp)
        {
            return timestamp.secondsSinceEpoch;
        }
        public static implicit operator string (UnixTimestamp timestamp)
        {
            return timestamp.secondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
        }
        public static implicit operator DateTime(UnixTimestamp timestamp)
        {
            return timestamp.secondsSinceEpoch >= 253402300800 ? DateTime.MaxValue : Epoch.AddSeconds(timestamp.secondsSinceEpoch);
        }
        public static UnixTimestamp operator +(UnixTimestamp a, UnixTimestamp b)
        {
            return new UnixTimestamp(a.SecondsSinceEpoch + b.SecondsSinceEpoch);
        }
        public static bool operator ==(UnixTimestamp a, UnixTimestamp b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(UnixTimestamp a, UnixTimestamp b)
        {
            return !a.Equals(b);
        }
        public override bool Equals(object obj) => base.Equals(obj);
        public bool Equals(UnixTimestamp other) => other.secondsSinceEpoch == secondsSinceEpoch;
        public override int GetHashCode() => secondsSinceEpoch.GetHashCode();
        public override string ToString() => secondsSinceEpoch.ToString(CultureInfo.InvariantCulture);
    }
}
#endif