using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Controls;
    private bool IsShowingControls = false;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("PickCar"); 
    }

    public void ToggleControls()
    {
        IsShowingControls = !IsShowingControls;  
        Controls.SetActive(IsShowingControls); 
    }

    void Start()
    {
        Controls.SetActive(false);
    }

    void Update()
    {
        if (IsShowingControls && Input.GetKeyDown(KeyCode.E))
        {
            ToggleControls(); 
        }
    }
}
