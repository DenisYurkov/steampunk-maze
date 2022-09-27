using UnityEngine;

namespace Steampunk.Code.Logic
{
    [CreateAssetMenu(fileName = "HeroSettings", menuName = "Hero/Settings", order = 0)]
    public class HeroSettings : ScriptableObject
    {
        public float RayDistance;
        public float MoveSpeed;
        public float CooldownTime;
    }
}