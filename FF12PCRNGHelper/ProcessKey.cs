using System;
using System.Diagnostics;

namespace FF12PCRNGHelper
{
    public class ProcessKey : IEquatable<ProcessKey>
    {
        public readonly int PID;
        public readonly string Name;
        public readonly DateTime StartTime;

        public ProcessKey(int pID, string name, DateTime startTime)
        {
            PID = pID;
            Name = name;
            StartTime = startTime;
        }

        public override bool Equals(object obj) => obj is ProcessKey pk && Equals(pk);
        public override int GetHashCode() => PID.GetHashCode() ^ Name.GetHashCode() ^ StartTime.GetHashCode();

        public bool Equals(ProcessKey other) => PID.Equals(other.PID) && Name.Equals(other.Name) && StartTime.Equals(other.StartTime);

        public static bool operator ==(ProcessKey left, ProcessKey right) => left.Equals(right);

        public static bool operator !=(ProcessKey left, ProcessKey right) => !(left == right);

        public static ProcessKey ForProcess(Process p) => new ProcessKey(p.Id, p.ProcessName, p.StartTime);
    }
}
