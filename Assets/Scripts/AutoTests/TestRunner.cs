using Gameplay;
using UnityEngine;

namespace AutoTests
{
    public class TestRunner : MonoBehaviour
    {
        [SerializeField] private string _testName = "Main gameplay route auto test";
        [SerializeField] private GameplayBot _bot;
        [SerializeField] private GameState _gameState;
        [SerializeField] private FPSMonitor _fpsMonitor;
        [SerializeField] private StuckDetector _stuckDetector;
        [SerializeField] private TestReportWriter _reportWriter;
        [SerializeField] private float _maximumTestDuration = 30f;

        private float _testTimer;
        private bool _isReportCreated;

        private void Update()
        {
            if (_isReportCreated)
            {
                return;
            }

            _testTimer += Time.deltaTime;

            if (_bot.IsFinished)
            {
                CreateReport();
                return;
            }

            if (_testTimer >= _maximumTestDuration)
            {
                CreateReport("Test timeout: bot did not finish route in expected time.");
            }
        }

        private void CreateReport(string failureReason = "")
        {
            _isReportCreated = true;

            bool isPassed =
                _bot.IsFinished &&
                _stuckDetector.IsStuck == false &&
                _fpsMonitor.IsFpsAcceptable &&
                _gameState.IsButtonPressed &&
                _gameState.IsDoorOpened &&
                _gameState.IsCapturePointCompleted;

            GameplayTestReport report = new GameplayTestReport
            {
                TestName = _testName,
                IsPassed = isPassed,
                AverageFps = _fpsMonitor.AverageFps,
                HasBotReachedFinish = _bot.IsFinished,
                IsBotStuck = _stuckDetector.IsStuck,
                IsButtonPressed = _gameState.IsButtonPressed,
                IsDoorOpened = _gameState.IsDoorOpened,
                IsCapturePointCompleted = _gameState.IsCapturePointCompleted,
                FailureReason = isPassed ? "" : failureReason
            };

            _reportWriter.WriteReport(report);

            Debug.Log(isPassed ? "AUTO TEST PASSED" : "AUTO TEST FAILED");
        }
    }
}