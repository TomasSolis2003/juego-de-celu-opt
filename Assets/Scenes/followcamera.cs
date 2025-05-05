using UnityEngine;

public class CameraOrbitFollow : MonoBehaviour
{
    public Transform objetivo;        // El objeto que la c�mara debe seguir (por ejemplo, el auto)
    public Vector3 offset = new Vector3(0, 5, -10); // Posici�n relativa desde el objetivo
    public float velocidadRotacion = 20f; // Velocidad de rotaci�n alrededor del objetivo
    public float suavizado = 5f;     // Suavizado del movimiento de c�mara

    private Vector3 posicionDeseada;
    private Quaternion rotacionDeseada;

    void LateUpdate()
    {
        if (objetivo == null) return;

        // Girar offset alrededor del eje Y
        offset = Quaternion.AngleAxis(velocidadRotacion * Time.deltaTime, Vector3.up) * offset;

        // Calcular posici�n deseada y rotaci�n hacia el objetivo
        posicionDeseada = objetivo.position + offset;
        rotacionDeseada = Quaternion.LookRotation(objetivo.position - posicionDeseada);

        // Aplicar suavizado
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * suavizado);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * suavizado);
    }
}
