using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CuboArrastrable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image barraDeProgreso; // Imagen de la barra de progreso
    public string ChorroDeAgua = "ChorroDseAgua"; // Etiqueta del objeto del chorro de agua
    public float tiempoParaLlenar = 10f; // Tiempo necesario para llenar la barra

    private RectTransform rectTransform;
    private Canvas canvas;
    private bool arrastrando = false;
    private bool sobreChorroDeAgua = false;
    private float tiempoActual = 0f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        arrastrando = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (arrastrando)
        {
            Vector2 posicionLocal;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out posicionLocal);
            rectTransform.localPosition = posicionLocal;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        arrastrando = false;
    }

    void Update()
    {
        if (sobreChorroDeAgua && arrastrando)
        {
            tiempoActual += Time.deltaTime;
            float fillAmount = tiempoActual / tiempoParaLlenar;
            barraDeProgreso.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }

    public void SobreChorroDeAgua()
    {
        sobreChorroDeAgua = true;
    }

    public void SalirDeChorroDeAgua()
    {
        sobreChorroDeAgua = false;
        tiempoActual = 0f;
        barraDeProgreso.fillAmount = 0f;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ChorroDeAgua))
        {
            SobreChorroDeAgua();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(ChorroDeAgua))
        {
            SalirDeChorroDeAgua();
        }
    }
}

