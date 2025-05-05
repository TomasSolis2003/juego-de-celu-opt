using UnityEngine;
using TMPro;
using System.Collections;

public class CuentaRegresiva : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    public GameObject auto; // El GameObject que tiene MovilidadAlternativa
    public float tiempoEntreNumeros = 1f;

    private MovilidadAlternativa movilidadScript;

    void Start()
    {
        if (auto != null)
            movilidadScript = auto.GetComponent<MovilidadAlternativa>();

        if (movilidadScript != null)
            movilidadScript.enabled = false; // Desactiva movimiento al inicio

        StartCoroutine(ContarRegresivamente());
    }

    IEnumerator ContarRegresivamente()
    {
        int conteo = 3;
        while (conteo > 0)
        {
            textoContador.text = conteo.ToString();
            yield return new WaitForSeconds(tiempoEntreNumeros);
            conteo--;
        }

        textoContador.text = "¡YA!";
        yield return new WaitForSeconds(1f);
        textoContador.gameObject.SetActive(false); // Oculta el texto

        if (movilidadScript != null)
            movilidadScript.enabled = true; // Reactiva el movimiento
    }
}
