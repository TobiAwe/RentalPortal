using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalPortal.Order.Common.Helpers
{
    public class SequentialGuid
    {

        public DateTime SequenceStartDate { get; }
        public DateTime SequenceEndDate { get; }

        const int NUMBER_OF_BYTES = 6;
        const int PERMUTATIONS_OF_A_BYTE = 256;
        readonly long _maximumPermutations = (long)Math.Pow(PERMUTATIONS_OF_A_BYTE, NUMBER_OF_BYTES);
        long _lastSequence;

        public SequentialGuid(DateTime sequenceStartDate, DateTime sequenceEndDate)
        {
            SequenceStartDate = sequenceStartDate;
            SequenceEndDate = sequenceEndDate;
        }

        public SequentialGuid()
            : this(new DateTime(2011, 10, 15), new DateTime(2100, 1, 1))
        {
        }

        static readonly Lazy<SequentialGuid> instanceField = new Lazy<SequentialGuid>(() => new SequentialGuid());
        internal static SequentialGuid Instance => instanceField.Value;

        public static Guid NewGuid() => Instance.GetGuid();

        public TimeSpan TimePerSequence
        {
            get
            {
                var ticksPerSequence = TotalPeriod.Ticks / _maximumPermutations;
                var result = new TimeSpan(ticksPerSequence);
                return result;
            }
        }

        public TimeSpan TotalPeriod
        {
            get
            {
                var result = SequenceEndDate - SequenceStartDate;
                return result;
            }
        }

        long GetCurrentSequence(DateTime value)
        {
            var ticksUntilNow = value.Ticks - SequenceStartDate.Ticks;
            var result = ((decimal)ticksUntilNow / TotalPeriod.Ticks * _maximumPermutations - 1);
            return (long)result;
        }

        public Guid GetGuid() => GetGuid(DateTime.Now);

        readonly object _synchronizationObject = new object();
        internal Guid GetGuid(DateTime now)
        {
            if (now < SequenceStartDate || now > SequenceEndDate)
            {
                return Guid.NewGuid(); // Outside the range, use regular Guid
            }

            var sequence = GetCurrentSequence(now);
            return GetGuid(sequence);
        }

        internal Guid GetGuid(long sequence)
        {
            lock (_synchronizationObject)
            {
                if (sequence <= _lastSequence)
                {
                    // Prevent double sequence on same server
                    sequence = _lastSequence + 1;
                }
                _lastSequence = sequence;
            }

            var sequenceBytes = GetSequenceBytes(sequence);
            var guidBytes = GetGuidBytes();
            var totalBytes = guidBytes.Concat(sequenceBytes).ToArray();
            var result = new Guid(totalBytes);
            return result;
        }

        IEnumerable<byte> GetSequenceBytes(long sequence)
        {
            var sequenceBytes = BitConverter.GetBytes(sequence);
            var sequenceBytesLongEnough = sequenceBytes.Concat(new byte[NUMBER_OF_BYTES]);
            var result = sequenceBytesLongEnough.Take(NUMBER_OF_BYTES).Reverse();
            return result;
        }

        IEnumerable<byte> GetGuidBytes()
        {
            var result = Guid.NewGuid().ToByteArray().Take(10).ToArray();
            return result;
        }
    }
}
