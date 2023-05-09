using System;
using System.Collections.Generic;
using UnityEngine;
using VIRGroupTestTask.Infrastructure;
using VIRGroupTestTask.Infrastructure.InputSystem;
using VIRGroupTestTask.WaySystem;
using Zenject;

namespace VIRGroupTestTask.Drawing
{
    public class LineDrawer : MonoBehaviour
    {
        private Way _currentWay;

        private IInputService _inputService;
        private GameFactory _factory;

        private bool _canDraw;
        private int _drawnLinesCount;

        public List<Way> Ways;

        public event Action<Way> Drawn;
        public event Action DrawingCompleted;

        [Inject]
        private void Construct(GameFactory factory, IInputService inputService)
        {
            _factory = factory;
            _inputService = inputService;
        }

        private void OnEnable() =>
            SubscribeToWayEvents();

        private void OnDisable() =>
            UnsubscribeFromWayEvents();

        void Update()
        {
            if (!_canDraw)
                return;

            Vector3 clickPosition = _inputService.ClickPosition();
            clickPosition.z = -1;

            if (_inputService.Pressed())
                _currentWay.Line = _factory.CreateLine(clickPosition, _currentWay.Type);

            if (_inputService.Moved())
                _currentWay.Line.SetPosition(clickPosition);
        }

        private void ValidateLine(Way way)
        {
            _canDraw = false;

            if (!way.IsAnyEndActive())
            {
                way.Line.Clear();
                return;
            }

            Drawn?.Invoke(way);

            way.OccupyEnd();
            way.DrawBegan -= AllowDrawing;
            way.DrawEnded -= ValidateLine;

            UpdateDrawingProgress();
        }

        private void UpdateDrawingProgress()
        {
            _drawnLinesCount++;

            if (_drawnLinesCount == Ways.Count)
                DrawingCompleted?.Invoke();
        }

        private void AllowDrawing(Way way)
        {
            _canDraw = true;
            ChooseWay(way);
        }

        private void ChooseWay(Way way) =>
            _currentWay = way;

        private void SubscribeToWayEvents()
        {
            foreach (Way way in Ways)
            {
                way.DrawBegan += AllowDrawing;
                way.DrawEnded += ValidateLine;
            }
        }

        private void UnsubscribeFromWayEvents()
        {
            foreach (Way way in Ways)
            {
                way.DrawBegan -= AllowDrawing;
                way.DrawEnded -= ValidateLine;
            }
        }
    }
}
