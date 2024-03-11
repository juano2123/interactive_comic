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
                // Aquí puedes activar otros scripts o ejecutar cualquier acción necesaria
                Debug.Log("Se han llenado suficientes casillas B");
                // Llamar a una función o método que active otros scripts o realice alguna acción adicional
                ActivarOtrosScripts();
            }
        } else if (eventData.pointerDrag != null) 
        {
            //anclarlo a la casilla
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    // Método para activar otros scripts o realizar acciones adicionales
    private void ActivarOtrosScripts()
    {
        // Aquí puedes activar otros scripts o realizar acciones adicionales
    }
}
