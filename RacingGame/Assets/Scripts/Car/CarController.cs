using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    [Header("Car Stats")]
    public float acceleration = 30.0f;
    public float turnSpeed = 3.5f;
    public float drift = 0.95f;
    public float minSteer = 8; 
    public float topSpeed = 20;

    public  float accelInput = 0;
    float steerInput = 0;
    float rotateAngle = 0;
    float velocityVsUp = 0;
    private Rigidbody2D _carRb;

    void Start()
    {
        _carRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        ApplyEngine();
        NoOrthVelo();
        ApplySteer();
    }

    void ApplyEngine()
    {
        velocityVsUp = Vector2.Dot(transform.up, _carRb.linearVelocity);
        if (velocityVsUp > topSpeed && accelInput > 0) {return;}
        if (velocityVsUp < -topSpeed * 0.5f && accelInput < 0) {return;}
        if (_carRb.linearVelocity.sqrMagnitude > topSpeed * topSpeed && accelInput > 0) {return;}
        if (accelInput == 0) { _carRb.linearDamping = Mathf.Lerp(_carRb.linearDamping, 3.0f, Time.fixedDeltaTime * 3); }
        else { _carRb.linearDamping = 0; }

        Vector2 engineForce = transform.up * accelInput * acceleration;
        _carRb.AddForce(engineForce, ForceMode2D.Force);
    }

    void ApplySteer()
    {
        float minSpeed = (_carRb.linearVelocity.magnitude / minSteer);
        minSpeed = Mathf.Clamp01(minSpeed);
        rotateAngle -= steerInput * turnSpeed * minSpeed;
        _carRb.MoveRotation(rotateAngle);
    }

    void NoOrthVelo()
    {
        Vector2 forwardV = transform.up * Vector2.Dot(_carRb.linearVelocity, transform.up);
        Vector2 rightV = transform.right * Vector2.Dot(_carRb.linearVelocity, transform.right);

        _carRb.linearVelocity = forwardV + rightV * drift;

    }


    public void SetInput(Vector2 inputV)
    {
        steerInput = inputV.x;
        accelInput = inputV.y;
    }


}
