using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{

    public static string CarColor;

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
        CarColor = "Orange";
        LoadMapSelect();
    }

    public void Silver()
    {
        CarColor = "Silver";
        LoadMapSelect();       
    }

    public void Red()
    {
        CarColor = "Red";
        LoadMapSelect();        
    }

    public void RBlue()
    {
        CarColor = "RB";
        LoadMapSelect();        
    }

    public void Pink()
    {
        CarColor = "Pink";
        LoadMapSelect();        
    }

    public void Blue()
    {
        CarColor = "Blue";
        LoadMapSelect();        
    }

}
