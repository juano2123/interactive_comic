using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public string requiredTag = "BombillaBuena";
    private int objetosAEnCasilla = 0;
    public static int totalObjetosAEnCasillas = 0;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Objeto soltado");

        if (objetosAEnCasilla >= 1 || totalObjetosAEnCasillas >= 3) return;

        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag(requiredTag))
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            objetosAEnCasilla++;
            totalObjetosAEnCasillas++;
            if (totalObjetosAEnCasillas >= 3)
            {
                Debug.Log("Se han llenado suficientes casillas B con objetos A");
                ActivarOtrosScripts();
            }
            // Bloquear el objeto A colocado
            eventData.pointerDrag.GetComponent<DragAndDrop>().BloquearObjeto();
        }
    }

    public void RetirarObjetoA()
    {
        if (objetosAEnCasilla > 0)
        {
            objetosAEnCasilla--;
            totalObjetosAEnCasillas--;
            // Desbloquear el objeto A retirado
            GetComponentInChildren<DragAndDrop>().DesbloquearObjeto();
        }
    }

    private void ActivarOtrosScripts()
    {

        // Aquí puedes activar otros scripts o realizar acciones adicionales
    }
}
