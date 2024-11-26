using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadMapSelect()
    {
        SceneManager.LoadScene("MapSelection");
    }

    public void Orange()
    {
        LoadMapSelect();
    }

    public void Silver()
    {
        LoadMapSelect();       
    }

    public void Red()
    {
        LoadMapSelect();        
    }

    public void RBlue()
    {
        LoadMapSelect();        
    }

    public void Pink()
    {
        LoadMapSelect();        
    }

    public void Blue()
    {
        LoadMapSelect();        
    }

}
