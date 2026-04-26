using UnityEngine;

namespace Gameplay
{
    public class GameState : MonoBehaviour
    {
        public bool IsButtonPressed { get; private set; }
        public bool IsDoorOpened { get; private set; }
        public bool IsCapturePointCompleted { get; private set; }
        public bool IsFinishReached { get; private set; }

        public void SetButtonPressed()
        {
            IsButtonPressed = true;
        }

        public void SetDoorOpened()
        {
            IsDoorOpened = true;
        }

        public void SetCapturePointCompleted()
        {
            IsCapturePointCompleted = true;
        }

        public void SetFinishReached()
        {
            IsFinishReached = true;
        }
    }
}