using UnityEngine;

namespace Steampunk.Code.Logic
{
    [CreateAssetMenu(fileName = "UIHelperConfig", menuName = "UIHelper/Config", order = 0)]
    public class UIHelperConfig : ScriptableObject
    {
        public float TimeForHide;
        public float AnimationSpeed;
    }
}