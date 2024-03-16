using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,
    IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private bool estaBloqueado = false; // Nuevo booleano para indicar si el objeto está bloqueado

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!estaBloqueado) // Solo permitir drag si el objeto no está bloqueado
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!estaBloqueado)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click objeto");
    }

    // Método para bloquear el objeto
    public void BloquearObjeto()
    {
        estaBloqueado = true;
    }

    // Método para desbloquear el objeto
    public void DesbloquearObjeto()
    {
        estaBloqueado = false;
    }
}
