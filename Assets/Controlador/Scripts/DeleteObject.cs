using UnityEngine;
using UnityEngine.UI;

public class DeleteObject : MonoBehaviour
{
    public GameObject objetoADestruir; // Objeto que se destruirá al hacer clic en el botón

    private void Start()
    {
        // Agregar el listener para el evento de clic al botón
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
            Debug.LogWarning("No se ha asignado ningún objeto a destruir.");
        }
    }
}
