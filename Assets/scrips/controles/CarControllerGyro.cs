

using UnityEngine;

public class CarControllerGyro : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float turnSpeed = 5f;
    public float driftAmount = 0.1f;
    public float driftOnBrake = 0.2f;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    private float calibrationOffset = 0;

    private Vector3 currentDirection;

    private bool accelerating = false;
    private bool braking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        calibrationOffset = Input.acceleration.x;
        currentDirection = transform.forward;
    }

    public void ApplySlowdown(float factor)
    {
        currentSpeed *= factor;
    }

    public void SetInput(bool accel, bool brake)
    {
        accelerating = accel;
        braking = brake;
    }

    void Update()
    {
        float tilt = Input.acceleration.x - calibrationOffset;
        transform.Rotate(0, tilt * turnSpeed, 0);

        if (braking)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftOnBrake));
        }
        else if (accelerating)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftAmount));
        }
        else
        {
            // Inercia: pierde velocidad poco a poco
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, (deceleration * 0.2f) * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftAmount));
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + currentDirection.normalized * currentSpeed * Time.fixedDeltaTime);
    }
}

//la aceleracion automatica no funciona correctamente
/*using UnityEngine;
using UnityEngine.UI;

public class CarControllerGyro : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float turnSpeed = 5f;
    public float driftAmount = 0.1f;
    public float driftOnBrake = 0.2f;

    public Button toggleModeButton;
    public Color autoColor = Color.green;
    public Color touchColor = Color.red;

    private Rigidbody rb;
    private float currentSpeed = 0f;
    private float calibrationOffset = 0;

    private Vector3 currentDirection;

    private bool accelerating = false;
    private bool braking = false;
    private bool autoAccelerate = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        calibrationOffset = Input.acceleration.x;
        currentDirection = transform.forward;

        if (toggleModeButton != null)
        {
            toggleModeButton.onClick.AddListener(ToggleAccelerationMode);
            UpdateButtonColor();
        }
    }

    public void ApplySlowdown(float factor)
    {
        currentSpeed *= factor;
    }

    public void SetInput(bool accel, bool brake)
    {
        accelerating = accel;
        braking = brake;
    }

    void ToggleAccelerationMode()
    {
        autoAccelerate = !autoAccelerate;
        UpdateButtonColor();
    }

    void UpdateButtonColor()
    {
        if (toggleModeButton != null)
        {
            ColorBlock colors = toggleModeButton.colors;
            colors.normalColor = autoAccelerate ? autoColor : touchColor;
            toggleModeButton.colors = colors;
        }
    }

    void Update()
    {
        float tilt = Input.acceleration.x - calibrationOffset;
        transform.Rotate(0, tilt * turnSpeed, 0);

        if (autoAccelerate)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else if (braking)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftOnBrake));
        }
        else if (accelerating)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftAmount));
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, (deceleration * 0.2f) * Time.deltaTime);
            currentDirection = Vector3.Lerp(currentDirection, transform.forward, (1f - driftAmount));
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + currentDirection.normalized * currentSpeed * Time.fixedDeltaTime);
    }
}
*/