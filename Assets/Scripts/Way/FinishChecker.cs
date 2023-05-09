using System;
using System.Collections.Generic;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.WaySystem
{
    public class FinishChecker
    {
        private List<PlayerFacade> _players;

        private int _finishCounter;

        public event Action Finished;

        public FinishChecker(List<PlayerFacade> players)
        {
            _players = players;

            foreach (PlayerFacade player in _players)
                player.Movement.Finished += CheckFinish;
        }

        private void CheckFinish()
        {
            _finishCounter++;

            if (_finishCounter == _players.Count)
                Finished?.Invoke();
        }
    }
}
