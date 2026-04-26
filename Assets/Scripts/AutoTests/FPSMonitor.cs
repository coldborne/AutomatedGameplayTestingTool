using UnityEngine;

namespace AutoTests
{
    public class FPSMonitor : MonoBehaviour
    {
        [SerializeField] private float _minimumAllowedFps = 30f;

        private int _framesCount;
        private float _elapsedTime;
        private float _averageFps;

        public float AverageFps => _averageFps;
        public bool IsFpsAcceptable => _averageFps >= _minimumAllowedFps;

        private void Update()
        {
            _framesCount++;
            _elapsedTime += Time.unscaledDeltaTime;

            if (_elapsedTime > 0)
            {
                _averageFps = _framesCount / _elapsedTime;
            }
        }
    }
}
