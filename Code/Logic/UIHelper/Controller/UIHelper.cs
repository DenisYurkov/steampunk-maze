using UnityEngine;
using Zenject;

namespace Steampunk.Code.Logic.Controller
{
    public class UIHelper : MonoBehaviour
    {
        private IUIHelperModel _uiHelperModel;

        [Inject]
        private void Construct(IUIHelperModel uiHelperModel) => 
            _uiHelperModel = uiHelperModel;

        private void Start() => 
            _uiHelperModel.Visualize();
    }
}