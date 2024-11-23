using UnityEngine;

public class SparkController : MonoBehaviour
{
    [Header("Particle Systems")]
    public ParticleSystem leftSpark;
    public ParticleSystem rightSpark;

    [Header("Car Settings")]
    public float topSpeed = 20f; 
    public float checkInterval = 0.1f; 

    [Header("Audio")]
    public AudioSource SparkSfx;

    private Rigidbody2D _carRb;
    private float nextCheckTime = 0f;

    void Start()
    {
        _carRb = GetComponent<Rigidbody2D>();

        StopSparks();
    }

    void Update()
    {
        if (Time.time >= nextCheckTime)
        {
            nextCheckTime = Time.time + checkInterval;
            if (IsAtTopSpeed())
            {
                PlaySparks();
                SparkSfx.Play();
            }
            else
            {
                StopSparks();
            }
        }
    }

    private bool IsAtTopSpeed()
    {
        return Mathf.Abs(_carRb.linearVelocity.magnitude - topSpeed) < 0.1f; 
    }

    private void PlaySparks()
    {
            leftSpark.Play();
            rightSpark.Play();
    }

    private void StopSparks()
    {
            leftSpark.Stop();
            rightSpark.Stop();
    }
}
