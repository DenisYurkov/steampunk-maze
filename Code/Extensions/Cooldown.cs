using UnityEngine;

namespace Steampunk.Code.Extensions
{
    public class Cooldown
    {
        private float _startWaitTime;
        private readonly float _duration;

        public Cooldown(float duration) => 
            _duration = duration;

        public bool Wait()
        {
            var nextAvailableTime = _startWaitTime + _duration;

            if (Time.time >= nextAvailableTime)
            {
                _startWaitTime = Time.time;
                return true;
            }
            return false;
        }
    }
}