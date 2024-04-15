using UnityEngine;

public class MoverChorroAgua : MonoBehaviour
{
    public float velocidadMinima = 1f;
    public float velocidadMaxima = 5f;
    public float cambioDireccionMinimo = 1f;
    public float cambioDireccionMaximo = 5f;

    private float velocidadActual;
    private float tiempoParaCambioDireccion;
    private int direccionMovimientoHorizontal = 1; // 1 para derecha, -1 para izquierda

    private void Start()
    {
        InicializarMovimiento();
    }

    private void Update()
    {
        // Mover el objeto del chorro de agua horizontalmente
        transform.Translate(Vector3.right * direccionMovimientoHorizontal * velocidadActual * Time.deltaTime);

        // Verificar si se necesita cambiar la dirección de movimiento
        tiempoParaCambioDireccion -= Time.deltaTime;
        if (tiempoParaCambioDireccion <= 0f)
        {
            CambiarDireccion();
            tiempoParaCambioDireccion = Random.Range(cambioDireccionMinimo, cambioDireccionMaximo);
        }

        // Mantener el objeto dentro de la pantalla horizontalmente
        MantenerEnPantalla();
    }

    private void InicializarMovimiento()
    {
        // Configurar una velocidad aleatoria al inicio
        velocidadActual = Random.Range(velocidadMinima, velocidadMaxima);

        // Configurar un tiempo aleatorio para el primer cambio de dirección
        tiempoParaCambioDireccion = Random.Range(cambioDireccionMinimo, cambioDireccionMaximo);
    }

    private void CambiarDireccion()
    {
        // Cambiar la dirección de movimiento horizontal
        direccionMovimientoHorizontal *= -1;
    }

    private void MantenerEnPantalla()
    {
        // Obtener los límites de la pantalla en el mundo
        Vector3 limiteInferiorIzquierdo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 limiteSuperiorDerecho = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        // Mantener el objeto dentro de los límites de la pantalla horizontalmente
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteInferiorIzquierdo.x, limiteSuperiorDerecho.x);
        transform.position = posicionActual;
    }
}
