using UnityEngine;
using VIRGroupTestTask.Data;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.Infrastructure
{
    public class GameFactory
    {
        private AssetProvider _assetProvider =  new AssetProvider();

        public Line CreateLine(Vector3 at, PlayerType type)
        {
            Line line = Object.Instantiate(_assetProvider.Line(), at, Quaternion.identity);
            line.SetStartAt(at);
            line.SetColor(Maps.LineColorMap[type]);

            return line;
        }
    }
}
