using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.WaySystem
{
    public class Way : MonoBehaviour
    {
        [SerializeField]
        private StartPoint _start;

        private List<EndPoint> _potentialEnds;
        private List<EndPoint> _freeEnds;

        public Line Line { get; set; }

        public PlayerType Type;

        public event Action<Way> DrawBegan;
        public event Action<Way> DrawEnded;

        private void Start()
        {
            SubscribeToDrawEvents();
            FindPotentialEnds();
        }

        public bool IsAnyEndActive() =>
            _potentialEnds.Find(x => x.IsActive && !x.IsOccupied) != null;

        public void OccupyEnd()
        {
            _freeEnds = _potentialEnds.FindAll(x => x.IsActive && !x.IsOccupied);

            OccupyClosestEnd();
        }

        private void OccupyClosestEnd()
        {
            float min = Vector2.Distance(_freeEnds[0].transform.position, Line.EndPosition());
            int minIndex = 0;

            if (_freeEnds.Count < 2)
            {
                _freeEnds[0].IsOccupied = true;
                return;
            }

            for (int i = 1; i < _potentialEnds.Count; i++)
            {
                float distance = Vector2.Distance(_freeEnds[i].transform.position, Line.EndPosition());
                if (distance < min)
                {
                    min = distance;
                    minIndex = i;
                }
            }

            _freeEnds[minIndex].IsOccupied = true;
        }

        private void DrawEnd() =>
            DrawEnded?.Invoke(this);

        private void DrawBegin() =>
            DrawBegan?.Invoke(this);

        private void SubscribeToDrawEvents()
        {
            _start.DrawStarted += DrawBegin;
            _start.DrawEnded += DrawEnd;
        }

        private void FindPotentialEnds()
        {
            _potentialEnds = FindObjectsOfType<EndPoint>()
                .ToList()
                .FindAll(x => x.Type == Type || x.Type == PlayerType.Univesal);
        }
    }
}
