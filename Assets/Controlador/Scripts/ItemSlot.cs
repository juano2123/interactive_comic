using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//agregando para manejar eventos
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // Etiqueta requerida para el objeto A
    public string requiredTag = "BombillaBuena"; 
    // Variable que cuenta objetos puestos
    public int objetosAEnCasilla = 0;

    //esto es para soltar el objeto en un lugar
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Objeto soltado");
        //hagamos que se adiera el otro objeto (con tag correcta y abajo incorrecta)
        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag(requiredTag)) {
            //anclarlo a la casilla
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            // Incrementar el contador de objetos A en la casilla B
            objetosAEnCasilla++;
            // Verificar si se han llenado suficientes casillas B
            if (objetosAEnCasilla >= 3)
            {
                // Aqu� puedes activar otros scripts o ejecutar cualquier acci�n necesaria
                Debug.Log("Se han llenado suficientes casillas B");
                // Llamar a una funci�n o m�todo que active otros scripts o realice alguna acci�n adicional
                ActivarOtrosScripts();
            }
        } else if (eventData.pointerDrag != null) 
        {
            //anclarlo a la casilla
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    // M�todo para activar otros scripts o realizar acciones adicionales
    private void ActivarOtrosScripts()
    {
        // Aqu� puedes activar otros scripts o realizar acciones adicionales
    }
}
