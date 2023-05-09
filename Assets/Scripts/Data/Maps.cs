using System.Collections.Generic;
using UnityEngine;
using VIRGroupTestTask.Player;

namespace VIRGroupTestTask.Data
{
    public static class Maps
    {
        public static Dictionary<PlayerType, Color> LineColorMap = new Dictionary<PlayerType, Color>()
        {
            { PlayerType.Blue, Color.blue },
            { PlayerType.Orange, new Color(244/255f, 116/255f, 39/255f)},
        };
    }
}
