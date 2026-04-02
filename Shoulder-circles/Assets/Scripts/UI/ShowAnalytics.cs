using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAnalytics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI compltetionTime; 
    [SerializeField] TextMeshProUGUI calories; 
    [SerializeField] TextMeshProUGUI CWReps;
    [SerializeField] TextMeshProUGUI CCWReps; 
    [SerializeField] TextMeshProUGUI totalRepsCompleted; 

    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI accuracy;
    [SerializeField] TextMeshProUGUI maxBPMReached;
    [SerializeField] TextMeshProUGUI totalWrongHits;
    [SerializeField] TextMeshProUGUI longestStreak;



    public void OnEnable()
    {
        // GameData gameData = SessionManager.currentSession;

        // if (gameData == null) return;

        // compltetionTime.text = gameData.sessionDuration;
        // CWReps.text = gameData.CW.ToString();
        // CCWReps.text = gameData.CCW.ToString();
        // calories.text = gameData.calories.ToString();
        // totalRepsCompleted.text = gameData.totalReps.ToString();


        // finalScore.text = gameData.finalScore.ToString();
        // accuracy.text = gameData.accuracy.ToString();
        // maxBPMReached.text = gameData.maxBPMReached.ToString();
        // totalWrongHits.text = gameData.totalWrongHits.ToString();
        // longestStreak.text = gameData.longestStreak.ToString();
    }


}
