/*using UnityEngine;

public class ZoneSlowdown : MonoBehaviour
{
    [Range(0f, 1f)]
    public float slowdownFactor = 0.7f; // 70% de la velocidad original = 30% menos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AUTO"))
        {
            CarControllerGyro car = other.GetComponent<CarControllerGyro>();
            if (car != null)
            {
                car.ApplySlowdown(slowdownFactor);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AUTO"))
        {
            CarControllerGyro car = other.GetComponent<CarControllerGyro>();
            if (car != null)
            {
                car.ResetSpeed();
            }
        }
    }
}
*/
/*using UnityEngine;

public class ZoneSlowdown : MonoBehaviour
{
    public float slowdownFactor = 0.7f; // Reduce al 70% de la velocidad original

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AUTO"))
        {
            CarControllerGyro car = other.GetComponent<CarControllerGyro>();
            if (car != null)
            {
                car.ApplySlowdown(slowdownFactor);
            }
        }
    }
}
*/
using UnityEngine;

public class ZONA_SLOW : MonoBehaviour
{
    [Tooltip("Porcentaje de reducción de velocidad (0.1 = 10%, 0.5 = 50%)")]
    [Range(0f, 1f)]
    public float slowFactor = 0.5f; // Reduce al 50% por defecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AUTO"))
        {
            MovilidadAlternativa movilidad = other.GetComponent<MovilidadAlternativa>();
            if (movilidad != null)
            {
                Debug.Log("Entró en zona lenta: reduciendo velocidad");
                movilidad.ReducirVelocidad(slowFactor);
            }
        }
    }
}
