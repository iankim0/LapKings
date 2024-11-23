using UnityEngine;

public class TireMarkController : MonoBehaviour
{
    [Header("Trail Renderers")]
    public TrailRenderer leftTireTrail;
    public TrailRenderer rightTireTrail;

    [Header("Drift and Brake Settings")]
    public float driftThreshold = 0.5f;
    public float brakeForceThreshold = 0.1f; 

    private Rigidbody2D _carRb;
    private CarInput _carInput;
    private CarController _carController;   

    void Start()
    {
        _carRb = GetComponent<Rigidbody2D>();
        _carInput = GetComponent<CarInput>();

        EnableTrails(false);
    }

    void Update()
    {
        bool isBraking = CheckBraking();    
        bool isDrifting = CheckDrift();

        EnableTrails(isBraking || isDrifting);
    }

    private bool CheckDrift()
    {
   
        Vector2 forwardVelocity = transform.up * Vector2.Dot(_carRb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(_carRb.linearVelocity, transform.right);

        float driftIntensity = rightVelocity.magnitude / _carRb.linearVelocity.magnitude;
        return driftIntensity > driftThreshold;
    }

    private bool CheckBraking()
    {
        return _carController != null && _carController.accelInput < 0 && Vector2.Dot(_carRb.linearVelocity, transform.up) > brakeForceThreshold;
    }

    private void EnableTrails(bool enable)
    {
        leftTireTrail.emitting = enable;
        rightTireTrail.emitting = enable;
    }
}
