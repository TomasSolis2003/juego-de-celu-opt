/*using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColisionPerdidaVelocidad : MonoBehaviour
{
    public float reduccionVelocidad = 0.8f; // 80% de p�rdida

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el objeto contra el que chocamos NO tiene Rigidbody o es kinematic, lo consideramos est�tico
        Rigidbody rbOtro = collision.collider.attachedRigidbody;

        if (rbOtro == null || rbOtro.isKinematic)
        {
            rb.velocity *= (1f - reduccionVelocidad); // Reduce la velocidad en 80%
        }
    }
}
*/
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColisionPerdidaVelocidad : MonoBehaviour
{
    public float reduccionVelocidad = 0.8f; // 80% de p�rdida

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Solo afecta si este objeto tiene la etiqueta "AUTO"
        if (CompareTag("AUTO"))
        {
            Rigidbody rbOtro = collision.collider.attachedRigidbody;

            // Si el otro objeto no tiene Rigidbody o es est�tico
            if (rbOtro == null || rbOtro.isKinematic)
            {
                rb.velocity *= (1f - reduccionVelocidad); // Reducir velocidad en 80%
            }
        }
    }
}
