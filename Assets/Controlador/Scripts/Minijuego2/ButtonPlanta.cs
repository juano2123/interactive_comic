using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPlanta : MonoBehaviour, IPointerClickHandler
{
    public GameObject objetoActivar;
    public GameObject[] objetosDesactivar;
    public void OnPointerClick(PointerEventData eventData)
    {
        ActivarDesactivarElementos();
    }

    void ActivarDesactivarElementos() 
    {
        objetoActivar.SetActive(true);
        foreach (GameObject objeto in objetosDesactivar)
        {
            objeto.SetActive(false);
        }
    }
}
