using UnityEngine;
using UnityEngine.UI;

public class CuboAgua : MonoBehaviour
{
    [SerializeField] private Image imagenLlenado;
    [SerializeField] private Text textoPorcentaje;
    [SerializeField] private float capacidadTotal = 10f;
    [SerializeField] private float tiempoLimite = 60f; // Tiempo límite en segundos
    [SerializeField] private GameObject objetivoCompletadoUI;
    [SerializeField] private GameObject objetivoFallidoUI;

    private float cantidadActual;
    private float tiempoTranscurrido;
    private float tiempoEnColision;
    private bool juegoTerminado;

    private void Start()
    {
        imagenLlenado.fillAmount = 0f;
        ActualizarTextoPorcentaje();
    }

    private void Update()
    {
        // Actualizar la imagen de llenado
        imagenLlenado.fillAmount = cantidadActual / capacidadTotal;

        // Actualizar el texto del porcentaje
        ActualizarTextoPorcentaje();

        // Actualizar el temporizador
        if (!juegoTerminado)
        {
            tiempoTranscurrido += Time.deltaTime;

            if (tiempoTranscurrido >= tiempoLimite)
            {
                TerminarJuego(false); // Tiempo agotado, no se cumplió el objetivo
            }
            else if (cantidadActual >= capacidadTotal)
            {
                TerminarJuego(true); // Objetivo cumplido dentro del tiempo límite
            }
        }
    }

    private void ActualizarTextoPorcentaje()
    {
        float porcentajeLlenado = (cantidadActual / capacidadTotal) * 100f;
        textoPorcentaje.text = porcentajeLlenado.ToString("F1") + "%";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chorro"))
        {
            tiempoEnColision = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Chorro"))
        {
            tiempoEnColision += Time.deltaTime;
            if (tiempoEnColision >= 10f)
            {
                cantidadActual = Mathf.Min(cantidadActual + Time.deltaTime, capacidadTotal);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Chorro"))
        {
            cantidadActual = Mathf.Min(cantidadActual + tiempoEnColision, capacidadTotal);
            tiempoEnColision = 0f;
        }
    }

    private void TerminarJuego(bool objetivoCumplido)
    {
        juegoTerminado = true;
        Time.timeScale = 0f; // Pausar el juego

        if (objetivoCumplido)
        {
            objetivoCompletadoUI.SetActive(true); // Mostrar el objeto de objetivo completado
        }
        else
        {
            objetivoFallidoUI.SetActive(true); // Mostrar el objeto de objetivo fallido
        }
    }
}
