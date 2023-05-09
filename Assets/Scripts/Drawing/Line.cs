using System.Collections.Generic;
using UnityEngine;
using VIRGroupTestTask.Data;
using VIRGroupTestTask.WaySystem;

namespace VIRGroupTestTask.Drawing
{
    [RequireComponent(typeof(LineRenderer))]
    public class Line : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer _lineRenderer;

        public List<Segment> segments { get; private set; } = new List<Segment>();
        public float Length { get; private set; } = 0;

        public void SetPosition(Vector3 position)
        {
            if (!CanAppend(position))
                return;

            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);

            segments.Add(new Segment(position));
        }

        public void SetStartAt(Vector3 position)
        {
            _lineRenderer.SetPosition(0, position);
            _lineRenderer.SetPosition(1, position);
            segments.Add(new Segment(position));
        }

        public void SetColor(Color color) =>
            _lineRenderer.material.color = color;

        public void Clear()
        {
            _lineRenderer.positionCount = 0;
            segments.Clear();
        }

        private bool CanAppend(Vector3 position)
        {
            if (_lineRenderer.positionCount == 0)
                return true;

            return Vector3.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1), position) > Constants.Resolution;
        }

        public void CalculateLength()
        {
            for (int i = 1; i < segments.Count; i++)
            {
                segments[i].NormalizedLength = Vector3.Distance(segments[i - 1].Position, segments[i].Position);
                Length += segments[i].NormalizedLength;
            }
            for (int i = 1; i < segments.Count; i++)
            {
                segments[i].NormalizedLength /= Length;
            }
        }

        public Vector3 EndPosition() =>
            _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
    }
}