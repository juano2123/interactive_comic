using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDialogo : MonoBehaviour
{
    private void Start()
    {
        // Pausar el juego al inicio
        Time.timeScale = 0f;
    }

    public void IniciarJuego()
    {
        // Despausar el juego
        Time.timeScale = 1f;
    }

    public void ReiniciarNivel()
    {
        // Reanudar el juego
        Time.timeScale = 1f;

        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}