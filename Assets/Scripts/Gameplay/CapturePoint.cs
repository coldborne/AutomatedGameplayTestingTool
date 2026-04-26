using AutoTests;
using UnityEngine;

namespace Gameplay
{
    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        [SerializeField] private float _captureDuration = 3f;

        private float _currentCaptureTime;
        private bool _isCaptured;

        public float CaptureProgress => _currentCaptureTime / _captureDuration;
        public bool IsCaptured => _isCaptured;

        private void OnTriggerStay(Collider other)
        {
            if (_isCaptured)
            {
                return;
            }

            if (other.GetComponent<GameplayBot>() == null)
            {
                return;
            }

            _currentCaptureTime += Time.deltaTime;

            if (_currentCaptureTime >= _captureDuration)
            {
                _isCaptured = true;
                _currentCaptureTime = _captureDuration;
                _gameState.SetCapturePointCompleted();
            }
        }
    }
}