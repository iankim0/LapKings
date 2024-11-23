using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class CarInput : MonoBehaviour
{
    CarController carController; 

    void Start()
    {
        carController = GetComponent<CarController>();
    }

    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        inputVector.y = Input.GetKey(KeyCode.W) ? 1 : 0;
    
        if (Input.GetKey(KeyCode.A)) inputVector.x = -1;
        if (Input.GetKey(KeyCode.D)) inputVector.x = 1;

        if (Input.GetKey(KeyCode.RightShift))
        {
            inputVector.y = -1; 
        }

        carController.SetInput(inputVector);
    }
}
