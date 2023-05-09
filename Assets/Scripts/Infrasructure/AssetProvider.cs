using UnityEngine;
using VIRGroupTestTask.Drawing;

namespace VIRGroupTestTask.Infrastructure
{
    public class AssetProvider
    {
        private const string LinePath = "Prefabs/Way/Line";

        private Line _linePrefab;

        public Line Line()
        {
            if (_linePrefab == null)
                _linePrefab = Resources.Load<Line>(LinePath);

            return _linePrefab;
        }
    }
}
