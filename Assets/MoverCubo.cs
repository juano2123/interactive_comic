using UnityEngine;

public class MoverCubo : MonoBehaviour
{
    private bool estaArrastrando;
    private Vector3 posicionInicialMouse;
    private Vector3 posicionInicialCubo;
    private Camera camaraPrincipal;

    private void Start()
    {
        camaraPrincipal = Camera.main;
    }

    private void Update()
    {
        // Mantener presionado el clic del mouse para arrastrar el cubo
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 posicionMouse = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(posicionMouse, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                estaArrastrando = true;
                posicionInicialMouse = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
                posicionInicialCubo = transform.position;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            estaArrastrando = false;
        }

        // Si se está arrastrando el cubo, actualizar su posición
        if (estaArrastrando)
        {
            Vector3 posicionActualMouse = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = posicionActualMouse - posicionInicialMouse;
            transform.position = posicionInicialCubo + offset;
        }
    }
}

