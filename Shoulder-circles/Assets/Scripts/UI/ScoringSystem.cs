using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 90f;

    [Header("Metrics (0.0 to 1.0)")]
    public float currentROM;
    public float currentSmoothness;
    public float currentConsistency;

    [Header("Final Results")]
    public float totalScore;

    private float currentAngle = 0f;
    private float totalActiveTime = 0f;
    private float totalTime = 0f;
    private int directionChanges = 0;
    private float lastInputDirection = 0f;

    private bool sessionActive = false;
    private bool sessionComplete = false;

    void Update()
    {
        if (sessionComplete) return;

        float dt = Time.deltaTime;
        float inputDir = 0f;


        if (Input.GetKey(KeyCode.W)) inputDir = 1f;
        else if (Input.GetKey(KeyCode.S)) inputDir = -1f;


        if (inputDir != 0f && !sessionActive)
            sessionActive = true;

        if (!sessionActive) return;

        totalTime += dt;


        if (inputDir != 0f)
        {
            if (lastInputDirection != 0f && inputDir != lastInputDirection)
            {
                directionChanges++;
            }

            totalActiveTime += dt;
            currentAngle += inputDir * rotationSpeed * dt;
            lastInputDirection = inputDir;
        }


        CalculateMetrics();


        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore(totalScore);
        }


        if (Mathf.Abs(currentAngle) >= 360f)
        {
            sessionComplete = true;
            Debug.Log("Mission Complete! Final Score: " + totalScore);
        }
    }

    void CalculateMetrics()
    {

        currentROM = Mathf.Clamp01(Mathf.Abs(currentAngle) / 360f);

       
        float smoothPenalty = directionChanges * 0.1f;
        currentSmoothness = Mathf.Clamp01(1f - smoothPenalty);


        float activeRatio = totalTime > 0 ? totalActiveTime / totalTime : 0f;
        currentConsistency = Mathf.Clamp01(activeRatio);


        totalScore = (currentSmoothness * 0.4f) + (currentROM * 0.3f) + (currentConsistency * 0.3f);
        totalScore *= 100f;
    }

    public void ResetSession()
    {
        currentAngle = 0f;
        totalActiveTime = 0f;
        totalTime = 0f;
        directionChanges = 0;
        lastInputDirection = 0f;

        currentROM = 0f;
        currentSmoothness = 0f;
        currentConsistency = 0f;
        totalScore = 0f;

        sessionActive = false;
        sessionComplete = false;
    }
}