using AutoTests;
using UnityEngine;

namespace Gameplay
{
    public class PressureButton : MonoBehaviour
    {
        [SerializeField] private Door _door;
        [SerializeField] private GameState _gameState;

        private bool _isPressed;

        private void OnTriggerEnter(Collider other)
        {
            if (_isPressed)
            {
                return;
            }

            if (other.GetComponent<GameplayBot>() == null)
            {
                return;
            }

            _isPressed = true;

            _gameState.SetButtonPressed();
            _door.Open();
        }
    }
}