using UnityEngine;

namespace Gameplay
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;

        private bool _isOpened;

        public bool IsOpened => _isOpened;

        public void Open()
        {
            if (_isOpened)
            {
                return;
            }

            _isOpened = true;
            gameObject.SetActive(false);

            _gameState.SetDoorOpened();
        }
    }
}