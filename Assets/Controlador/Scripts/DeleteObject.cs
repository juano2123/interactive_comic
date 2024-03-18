using UnityEngine;
using UnityEngine.UI;

public class DeleteObject : MonoBehaviour
{
    public GameObject objetoADestruir; // Objeto que se destruir� al hacer clic en el bot�n

    private void Start()
    {
        // Agregar el listener para el evento de clic al bot�n
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir); // Destruir el objeto seleccionado
        }
        else
        {
            Debug.LogWarning("No se ha asignado ning�n objeto a destruir.");
        }
    }
}
