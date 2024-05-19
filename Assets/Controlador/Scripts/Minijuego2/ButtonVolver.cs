using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonVolver : MonoBehaviour, IPointerClickHandler
{
    public GameObject eleccion1;
    public GameObject eleccion2;
    public GameObject eleccion3;
    public GameObject eleccion4;

    void Start()
    {
        // Verificar si se ha asignado un objeto a desactivar
        //if (eleccion1 || eleccion2 || eleccion3 || eleccion4 == null)
        //{
        //    Debug.LogError("No se ha asignado un objeto a desactivar en el inspector.");
        //}
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        DesactivarObjeto();
    }
    public void DesactivarObjeto()
    {
        // Verificar que el objeto a desactivar no sea nulo antes de desactivarlo
        //if (eleccion1 || eleccion2 || eleccion3 || eleccion4 != null)
        //{
            eleccion1.SetActive(false);
            eleccion2.SetActive(false);
            eleccion3.SetActive(false);
            eleccion4.SetActive(false);
        //}
    }
}
