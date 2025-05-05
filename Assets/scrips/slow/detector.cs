using UnityEngine;

public class DetectorDeColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AUTO"))
        {
            MovilidadAlternativa movilidad = other.GetComponent<MovilidadAlternativa>();
            if (movilidad != null)
            {
                // Revisamos si este trigger tiene el tag 'inamovible'
                if (CompareTag("inamovible"))
                {
                    Debug.Log("DetectorDeColision: colisión con objeto inamovible detectada, reduciendo velocidad al 20%.");
                    movilidad.currentSpeed *= 0.8f;  // Reduce la velocidad al 20%
                }
            }
        }
    }
}
