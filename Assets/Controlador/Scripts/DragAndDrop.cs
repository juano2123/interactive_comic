using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//agregando para manejar eventos
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, 
    IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //no todas las pantallas de celulares tienen mismas
    //dimensiones, asi que vamos a traer propiedades del canvas
    [SerializeField] private Canvas canvas;
    //transformacion de posicion
    private RectTransform rectTransform;
    //el canvas group es para que varios objetos escuchen eventos de drag
    //en vez de solo el seleccionado
    private CanvasGroup canvasGroup;

    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    //iniciar drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("inicio drag");
    }

    //esto llama cada frame cuando hacemos drag al objeto
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("draging");
        //movimiento
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;
    }

    //finalizar drag
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("fin drag");
    }

    //IP es oara detectar click en objeto

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click objero");
    }

    
}
