using UnityEngine;
using VIRGroupTestTask.Drawing;
using VIRGroupTestTask.WaySystem;
using Zenject;

namespace VIRGroupTestTask
{
    public class Tutorial : MonoBehaviour
    {
        [Inject]
        private void Construct(LineDrawer lineDrawer) => 
            lineDrawer.Drawn += Hide;

        private void Hide(Way way) => 
            gameObject.SetActive(false);
    }
}
