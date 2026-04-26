using System;
using System.IO;
using UnityEngine;

namespace AutoTests
{
    public class TestReportWriter : MonoBehaviour
    {
        public void WriteReport(GameplayTestReport report)
        {
            string json = JsonUtility.ToJson(report, true);
            string directoryPath = Path.Combine(Application.dataPath, "..", "TestReports");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"test_report_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.json";
            string filePath = Path.Combine(directoryPath, fileName);

            File.WriteAllText(filePath, json);

            Debug.Log($"Test report saved: {filePath}");
        }
    }
}