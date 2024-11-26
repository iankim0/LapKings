using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackButtonController : MonoBehaviour
{

    public AudioSource Click;

    public void SunnyStraights()
    {
        Click.Play();
        SceneManager.LoadScene("SunnyStraights");
    }

    public void ChicaneChaos()
    {
        Click.Play();
        SceneManager.LoadScene("ChicaneChaos");
    }

}