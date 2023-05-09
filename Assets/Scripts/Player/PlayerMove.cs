using System;
using System.Collections.Generic;
using UnityEngine;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.WaySystem;

namespace VIRGroupTestTask.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]
        private float timeDuration = 5f;

        private List<Segment> _segments;

        private bool _isReady;
        private bool _canMove;
        private int _current = 1;
        private float _t = 0f;

        public event Action WaySet;
        public event Action Finished;

        public Way Way;

        void Update()
        {
            if (!_isReady || !_canMove)
                return;

            Move();
        }

        public void Allow() => 
            _canMove = true;

        public void Stop() =>
            _canMove = false;

        public void SetWay()
        {
            GetSegmentsFor(Way.Line);
            _isReady = true;
        }

        private void Move()
        {
            if (_current > 0 && _current < _segments.Count)
            {
                _t += Time.deltaTime / _segments[_current].NormalizedLength / timeDuration;

                if (_t > 1f)
                {
                    _t -= 1f;
                    _t *= _segments[_current].NormalizedLength;
                    _current++;

                    if (_current >= _segments.Count)
                    {
                        Finished?.Invoke();
                        return;
                    }


                    _t /= _segments[_current].NormalizedLength;
                }

                transform.position = Vector3.Lerp(_segments[_current - 1].Position, _segments[_current].Position, _t);
            }
        }

        private void GetSegmentsFor(Line line)
        {
            line.CalculateLength();

            _segments = line.segments;
        }
    }
}
