
/*using UnityEngine;
using TMPro;

public class SpeedometerTMP : MonoBehaviour
{
    public Transform carTransform;           // El transform del auto
    public TextMeshProUGUI speedText;        // El TextMeshProUGUI en la UI

    private Vector3 lastPosition;
    private float speed = 0f;

    void Start()
    {
        lastPosition = carTransform.position;
    }

    void Update()
    {
        // Calcular distancia recorrida entre frames
        float distance = Vector3.Distance(carTransform.position, lastPosition);

        // Calcular velocidad (m/s): distancia / tiempo
        speed = distance / Time.deltaTime;

        // Convertir a km/h
        float speedKmh = speed * 3.6f;

        // Mostrar en pantalla (redondeado)
        speedText.text = Mathf.RoundToInt(speedKmh) + " km/h";

        // Guardar posición para el próximo frame
        lastPosition = carTransform.position;
    }
}
*/
/*using UnityEngine;
using TMPro;

public class SpeedometerTMP : MonoBehaviour
{
    public Transform carTransform;            // El Transform del auto
    public TextMeshProUGUI speedText;         // El TextMeshProUGUI en la UI

    private Vector3 lastPosition;
    private float displayedSpeed = 0.5f;        // Velocidad que mostramos suavizada

    void Start()
    {
        lastPosition = carTransform.position;
    }

    void Update()
    {
        // Calcular velocidad instantánea (m/s)
        float distance = Vector3.Distance(carTransform.position, lastPosition);
        float instantSpeed = distance / Time.deltaTime;

        // Convertir a km/h
        float instantSpeedKmh = instantSpeed * 3.6f;

        // Suavizar usando Lerp (ajusta 5f si quieres que reaccione más rápido o lento)
        displayedSpeed = Mathf.Lerp(displayedSpeed, instantSpeedKmh, Time.deltaTime * 5f);

        // Mostrar en pantalla (redondeado)
        speedText.text = Mathf.RoundToInt(displayedSpeed) + " km/h";

        // Guardar posición para el próximo frame
        lastPosition = carTransform.position;
    }
}
*/
using UnityEngine;
using TMPro;

public class SpeedometerTMP : MonoBehaviour
{
    public Transform carTransform;             // El Transform del auto
    public TextMeshProUGUI speedText;          // El TextMeshProUGUI en la UI

    private Vector3 lastPosition;
    private float displayedSpeed = 0f;         // Velocidad suavizada

    void Start()
    {
        lastPosition = carTransform.position;
    }

    void Update()
    {
        // Calcular velocidad instantánea (m/s)
        float distance = Vector3.Distance(carTransform.position, lastPosition);
        float instantSpeed = distance / Time.deltaTime;

        // Convertir a km/h
        float instantSpeedKmh = instantSpeed * 3.6f;

        // Suavizar más lento usando Lerp (ajusta 2f si quieres aún más suavidad)
        displayedSpeed = Mathf.Lerp(displayedSpeed, instantSpeedKmh, Time.deltaTime * 3f);

        // Mostrar en pantalla (redondeado)
        speedText.text = Mathf.RoundToInt(displayedSpeed) + " km/h";

        // Guardar posición para el próximo frame
        lastPosition = carTransform.position;
    }
}
