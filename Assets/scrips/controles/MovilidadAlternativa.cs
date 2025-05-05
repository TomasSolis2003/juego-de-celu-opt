
using UnityEngine;
using UnityEngine.UI;

public class MovilidadAlternativa : MonoBehaviour
{
    public enum ControlMode { Manual, Automatic }
    public ControlMode controlMode = ControlMode.Manual;

    [Header("Movimiento")]
    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float turnSpeed = 5f;
    public float driftAmount = 0.1f;
    public float driftOnBrake = 0.2f;

    [Header("UI")]
    public Button botonCambioModo;
    public Text textoModo;

    private Rigidbody rb;
    public float currentSpeed = 0f;
    private float calibrationOffset = 0;
    private Vector3 currentDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        calibrationOffset = Input.acceleration.x;
        currentDirection = transform.forward;

        if (botonCambioModo != null)
            botonCambioModo.onClick.AddListener(CambiarModo);

        ActualizarTextoModo();
    }
    public void ReducirVelocidad(float factor)
    {
        currentSpeed *= Mathf.Clamp01(1f - factor);
    }

    void Update()
    {
        AplicarGiro();
        AplicarMovimiento();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + currentDirection.normalized * currentSpeed * Time.fixedDeltaTime);
    }

    void AplicarGiro()
    {
        float tilt = Input.acceleration.x - calibrationOffset;
        transform.Rotate(0, tilt * turnSpeed, 0); // ← Giro directo (como en tu código original)
    }

    void AplicarMovimiento()
    {
        bool isTouching = Input.touchCount > 0 || Input.GetMouseButton(0);

        switch (controlMode)
        {
            case ControlMode.Manual:
                if (isTouching)
                {
                    Vector3 touchPos = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector3)Input.mousePosition;
                    if (touchPos.x > Screen.width / 2)
                    {
                        // Derecha: acelerar
                        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
                    }
                    else
                    {
                        // Izquierda: frenar
                        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
                    }
                    currentDirection = Vector3.Lerp(currentDirection, transform.forward, 1f - driftOnBrake);
                }
                else
                {
                    // Sin tocar: derrape por inercia
                    currentDirection = Vector3.Lerp(currentDirection, transform.forward, 1f - driftAmount);
                }
                break;

            case ControlMode.Automatic:
                if (isTouching)
                {
                    // Tocando: frenar
                    currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
                }
                else
                {
                    // No tocar: acelerar automáticamente
                    currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
                }
                currentDirection = Vector3.Lerp(currentDirection, transform.forward, 1f - driftAmount);
                break;
        }
    }

    void CambiarModo()
    {
        controlMode = controlMode == ControlMode.Manual ? ControlMode.Automatic : ControlMode.Manual;
        ActualizarTextoModo();
    }

    void ActualizarTextoModo()
    {
        if (textoModo != null)
            textoModo.text = "Modo: " + controlMode.ToString();
    }
}
