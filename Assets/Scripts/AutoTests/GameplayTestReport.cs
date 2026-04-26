using System;

namespace AutoTests
{
    [Serializable]
    public class GameplayTestReport
    {
        public string TestName;
        public bool IsPassed;
        public float AverageFps;
        public bool HasBotReachedFinish;
        public bool IsBotStuck;
        public bool IsButtonPressed;
        public bool IsDoorOpened;
        public bool IsCapturePointCompleted;
        public string FailureReason;
    }
}