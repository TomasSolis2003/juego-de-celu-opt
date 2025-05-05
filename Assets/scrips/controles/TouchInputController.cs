/*using UnityEngine;

public class TouchInputController : MonoBehaviour
{
    public CarControllerGyro carController;

    void Update()
    {
        bool accelerating = false;
        bool braking = false;

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x > Screen.width / 2)
            {
                // Lado derecho = acelerar
                accelerating = true;
            }
            else if (touch.position.x < Screen.width / 2)
            {
                // Lado izquierdo = frenar
                braking = true;
            }
        }

        carController.SetInput(accelerating, braking);
    }
}
*/
/*using UnityEngine;
using UnityEngine.UI;

public class ToggleControllerButton : MonoBehaviour
{
    public Button toggleButton;                   // Botón de la UI
    public MonoBehaviour carControllerGyro;       // Referencia al script CarControllerGyro
    public MonoBehaviour movilidadAlternativa;    // Referencia al script MovilidadAlternativa

    private bool usingGyro = true;

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleControllers);
        }
        else
        {
            Debug.LogError("No se asignó el toggleButton en el Inspector.");
        }

        // Asegurarse que solo uno esté activo al inicio
        SetControllerState(usingGyro);
    }

    void ToggleControllers()
    {
        usingGyro = !usingGyro;
        SetControllerState(usingGyro);
    }

    void SetControllerState(bool useGyro)
    {
        carControllerGyro.enabled = useGyro;
        movilidadAlternativa.enabled = !useGyro;

        Debug.Log("Modo actual: " + (useGyro ? "Gyro" : "Alternativa"));
    }
}
*/
/*using UnityEngine;
using UnityEngine.UI;

public class ToggleControllerButton : MonoBehaviour
{
    public Button toggleButton;                   // Botón UI para alternar
    public GameObject carObject;                  // GameObject que tiene los dos scripts
    public CarControllerGyro carControllerGyro;   // Referencia al script CarControllerGyro
    public MovilidadAlternativa movilidadAlternativa; // Referencia al script MovilidadAlternativa

    private bool usingGyro = true;

    void Start()
    {
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleControllers);
        }
        else
        {
            Debug.LogError("No se asignó el toggleButton en el Inspector.");
        }

        if (carObject == null)
        {
            Debug.LogError("No se asignó el carObject en el Inspector.");
        }

        // Asegúrate que solo uno esté activo al inicio
        SetControllerState(usingGyro);
    }

    void ToggleControllers()
    {
        usingGyro = !usingGyro;
        SetControllerState(usingGyro);
    }

    void SetControllerState(bool useGyro)
    {
        if (carObject != null)
        {
            carControllerGyro.enabled = useGyro;
            movilidadAlternativa.enabled = !useGyro;

            Debug.Log("Modo actual: " + (useGyro ? "Gyro" : "Alternativa"));
        }
    }
}
*/
/*using UnityEngine;
using UnityEngine.UI;

public class ControllerSwitcher : MonoBehaviour
{
    public GameObject carControllerGyro;           // GameObject con el script CarControllerGyro
    public GameObject movilidadAlternativa;        // GameObject con el script MovilidadAlternativa
    public Button switchUIButton;                  // El botón UI que alterna entre los modos
    public Color gyroColor = Color.green;          // Color cuando está activado el modo Gyro
    public Color altColor = Color.blue;            // Color cuando está activado el modo Alternativo

    private bool usingGyro = true;

    void Start()
    {
        if (switchUIButton != null)
        {
            switchUIButton.onClick.AddListener(SwitchControllers);
            UpdateButtonColor();
        }
        else
        {
            Debug.LogWarning("No se asignó el botón UI switchUIButton en el Inspector.");
        }

        // Inicializar el estado del controlador y el color del botón
        SetControllerState(usingGyro);
    }

    public void SwitchControllers()
    {
        // Alternar entre los dos modos
        usingGyro = !usingGyro;
        SetControllerState(usingGyro);
        UpdateButtonColor();
    }

    void SetControllerState(bool useGyro)
    {
        // Activar el controlador correspondiente
        carControllerGyro.SetActive(useGyro);
        movilidadAlternativa.SetActive(!useGyro);
    }

    void UpdateButtonColor()
    {
        if (switchUIButton != null)
        {
            ColorBlock colors = switchUIButton.colors;
            colors.normalColor = usingGyro ? gyroColor : altColor;
            switchUIButton.colors = colors;
        }
    }
}
*/
using UnityEngine;
using UnityEngine.UI;

public class ControllerSwitcher : MonoBehaviour
{
    public MonoBehaviour carControllerGyroScript;  // El script del CarControllerGyro
    public MonoBehaviour movilidadAlternativaScript; // El script del MovilidadAlternativa
    public Button switchUIButton;                  // El botón UI que alterna entre los modos
    public Color gyroColor = Color.green;          // Color cuando está activado el modo Gyro
    public Color altColor = Color.blue;            // Color cuando está activado el modo Alternativo

    private bool usingGyro = true;

    void Start()
    {
        if (switchUIButton != null)
        {
            switchUIButton.onClick.AddListener(SwitchControllers);
            UpdateButtonColor();
        }
        else
        {
            Debug.LogWarning("No se asignó el botón UI switchUIButton en el Inspector.");
        }

        // Inicializar el estado del controlador y el color del botón
        SetControllerState(usingGyro);
    }

    public void SwitchControllers()
    {
        // Alternar entre los dos modos
        usingGyro = !usingGyro;
        SetControllerState(usingGyro);
        UpdateButtonColor();
    }

    void SetControllerState(bool useGyro)
    {
        // Activar o desactivar los scripts según el modo
        carControllerGyroScript.enabled = useGyro;
        movilidadAlternativaScript.enabled = !useGyro;
    }

    void UpdateButtonColor()
    {
        if (switchUIButton != null)
        {
            ColorBlock colors = switchUIButton.colors;
            colors.normalColor = usingGyro ? gyroColor : altColor;
            switchUIButton.colors = colors;
        }
    }
}
