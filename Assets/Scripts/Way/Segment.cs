using UnityEngine;

namespace VIRGroupTestTask.WaySystem
{
    public class Segment
    {
        public float NormalizedLength;
        public Vector3 Position;

        public Segment(Vector3 position) => 
            Position = position;
    }
}
