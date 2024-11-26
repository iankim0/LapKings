using UnityEngine;

public class Livery : MonoBehaviour
{
    public SpriteRenderer CarSpriteRenderer; // Assign your car's SpriteRenderer in the Inspector
    public Sprite Oran;
    public Sprite Silv;
    public Sprite Red;
    public Sprite RB;
    public Sprite Pink;
    public Sprite Blu;

    private void Start()
    {
        ApplySelectedColor();
    }

    private void ApplySelectedColor()
    {
        if (ButtonManager.CarColor != null)
        {
            switch (ButtonManager.CarColor)
            {
                case "Orange":
                    CarSpriteRenderer.sprite = Oran;
                    break;
                case "Silver":
                    CarSpriteRenderer.sprite = Silv;
                    break;
                case "Red":
                    CarSpriteRenderer.sprite = Red;
                    break;
                case "RB":
                    CarSpriteRenderer.sprite = RB;
                    break;
                case "Pink":
                    CarSpriteRenderer.sprite = Pink;
                    break;
                case "Blue":
                    CarSpriteRenderer.sprite = Blu;
                    break;
            }
        }
    }
}