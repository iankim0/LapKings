using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    public int NumCheckpoints = 3;
    public Collider2D FinishLine;
    public Collider2D[] CheckpointColliders;
    public TMP_Text LapText;
    public TMP_Text TimerText;
    public AudioClip LapClip;
    public AudioSource LapSource;

    private bool[] CheckpointsPassed;
    private int CheckpointCounter = 0;
    private int LapCount = 0;
    private float Timer = 0f;
    private bool TimerRunning = false;

    public void StartTimer()
    {
        TimerRunning = true;
    }

    public int GetLapCount()
    {
        return LapCount;
    }

    public float GetTotalTime()
    {
        return Timer;
    }
    void Start()
    {
        CheckpointsPassed = new bool[NumCheckpoints];
        UpdateLapUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (TimerRunning)
        {
            Timer += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsCheckpoint(other))
        {
            HandleCheckpoint(other);
        }
        else if (other == FinishLine)
        {
            HandleFinishLine();
        }
    }

    private bool IsCheckpoint(Collider2D other)
    {
        foreach (var checkpoint in CheckpointColliders)
        {
            if (other == checkpoint)
            {
                return true;
            }
        }
        return false;
    }

    private void HandleCheckpoint(Collider2D checkpoint)
    {
        int checkpointIndex = System.Array.IndexOf(CheckpointColliders, checkpoint);

        if (checkpointIndex >= 0 && !CheckpointsPassed[checkpointIndex])
        {
            CheckpointsPassed[checkpointIndex] = true;
            CheckpointCounter++;
        }
    }

    private void HandleFinishLine()
    {
        if (CheckpointCounter == NumCheckpoints)
        {
            LapCount++;
            LapSource.clip = LapClip;
            LapSource.Play();
            ResetCheckpoints();
            UpdateLapUI();
            if (LapCount >= 3)
            {
                TimerRunning = false;
            }
        }
    }

    private void ResetCheckpoints()
    {
        CheckpointCounter = 0;
        for (int i = 0; i < CheckpointsPassed.Length; i++)
        {
            CheckpointsPassed[i] = false;
        }
    }

    private void UpdateLapUI()
    {
        if (LapText != null)
        {
            LapText.text = "Laps: " + LapCount + "/3";
        }
    }

    private void UpdateTimerUI()
    {
        if (TimerText != null)
        {
            TimerText.text = "Time: " + Timer.ToString("F2");
        }
    }
}
