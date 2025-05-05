using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform car;          // El auto a seguir
    public Vector3 offset = new Vector3(0, 5, -10);  // Posición relativa a mantener
    public float smoothSpeed = 5f;  // Suavidad del movimiento

    void LateUpdate()
    {
        if (car == null)
            return;

        Vector3 desiredPosition = car.position + car.TransformDirection(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        transform.LookAt(car);  // Hace que la cámara mire al auto
    }
}
