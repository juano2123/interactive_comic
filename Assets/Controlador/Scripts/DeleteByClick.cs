using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteByClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Destruir el objeto al hacer clic
        Destroy(gameObject);
    }
}
