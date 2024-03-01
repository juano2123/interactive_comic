using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//agregando para manejar eventos
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    //esto es para soltar el objeto en un lugar
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Objeto soltado");
    }
}
