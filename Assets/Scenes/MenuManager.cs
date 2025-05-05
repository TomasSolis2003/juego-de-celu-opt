using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cambia por el nombre real de tu escena de juego
    }

    public void Salir()
    {
        Application.Quit(); // Esto funcionará en una build, no en el editor
    }
}

