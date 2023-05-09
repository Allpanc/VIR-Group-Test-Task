using System.Collections.Generic;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.WaySystem
{
    public class MoveStarter
    {
        private LineDrawer _lineDrawer;

        private List<PlayerFacade> _players;

        public MoveStarter(LineDrawer lineDrawer, List<PlayerFacade> players)
        {
            _players = players;
            _lineDrawer = lineDrawer;
        }

        public void SubscribeToDrawEvents()
        {
            _lineDrawer.Drawn += UpdateReady;
            _lineDrawer.DrawingCompleted += AllowMovement;
        }

        public void UnsubscribeFromDrawEvents()
        {
            _lineDrawer.Drawn -= UpdateReady;
            _lineDrawer.DrawingCompleted -= AllowMovement;
        }

        private void AllowMovement() =>
            _players.ForEach(x => x.Run());

        private void UpdateReady(Way way) =>
            _players
            .Find(x => x.Movement.Way == way)?
            .SetWay();
    }
}
