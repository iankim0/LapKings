using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameCountdownManager : MonoBehaviour
{
    public TMP_Text CountdownText;
    public GameObject PlayerCar;
    public LapManager LapManager;
    public AudioSource AudioSource;
    public AudioClip CountdownClip;
    public AudioClip GoClip;
    public GameObject CompletionPanel;
    public TMP_Text CompletionText;

    private bool CountdownCompleted = false;
    private float DecelerationRate = 0.005f;

    void Start()
    {
        DisablePlayerControl();
        CompletionPanel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (LapManager.GetLapCount() == 3)
        {
            FinishRace();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator StartCountdown()
    {
        CountdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            PlayCountdownAudio();
            yield return new WaitForSeconds(1f);
        }

        CountdownText.text = "Go!";
        PlayGoAudio();
        yield return new WaitForSeconds(1f);

        CountdownText.gameObject.SetActive(false);
        CountdownCompleted = true;

        EnablePlayerControl();
        LapManager.StartTimer();
    }

    private IEnumerator SlowDown()
    {
        var carRigidbody = PlayerCar.GetComponent<Rigidbody2D>();
        if (carRigidbody != null)
        {
            while (carRigidbody.linearVelocity.magnitude > 0.1f)
            {
                carRigidbody.linearVelocity = Vector2.Lerp(carRigidbody.linearVelocity, Vector2.zero, DecelerationRate * Time.deltaTime);
                yield return null;
            }
            carRigidbody.linearVelocity = Vector2.zero;
        }
    }

    private void DisablePlayerControl()
    {
        var playerControl = PlayerCar.GetComponent<CarController>();
        if (playerControl != null)
        {
            playerControl.enabled = false;
        }
    }

    private void EnablePlayerControl()
    {
        var playerControl = PlayerCar.GetComponent<CarController>();
        if (playerControl != null)
        {
            playerControl.enabled = true;
        }
    }

    private void PlayCountdownAudio()
    {
        if (AudioSource != null && CountdownClip != null)
        {
            AudioSource.PlayOneShot(CountdownClip);
        }
    }

    private void PlayGoAudio()
    {
        if (AudioSource != null && GoClip != null)
        {
            AudioSource.PlayOneShot(GoClip);
        }
    }

    private void ShowCompletionPanel()
    {
        CompletionPanel.SetActive(true);
        CompletionText.text = $"Nice job! Total Time: {LapManager.GetTotalTime().ToString("F2")} seconds";
    }

    private void FinishRace()
    {
        StartCoroutine(SlowDown());
        ShowCompletionPanel();
    }
}
