using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class slotbasuraazul : MonoBehaviour, IDropHandler
{
    public string requiredTag = "basuraazul";
    private int objetosAEnCasilla = 0;
    public static int totalObjetosAEnCasillas = 0;
    //referencia a componente feedback
    public GameObject objetoADesaparecer; // GameObject a hacer aparecer/desaparecer
    public Sprite[] sprites; // Array de sprites para seleccionar aleatoriamente
    private Image imagen; // Referencia al componente Image del GameObject

    //textMesh que llamamos para actualizar el contador
    public TextMeshProUGUI textoTotalObjetos;

    //distancia en Y para bajar el objeto
    public float distanciaY;

    //mas referencia a 
    private void Start()
    {
        // Obtener la referencia al componente Image
        imagen = objetoADesaparecer.GetComponent<Image>();
        // Hacer que el objeto est� inicialmente invisible al configurar el canal alfa al m�ximo
        imagen.color = new Color(imagen.color.r, imagen.color.g, imagen.color.b, 0f);
        //inicializando el texto
        textoTotalObjetos.text = "0/2"; // Inicializar el texto en "0/2"

        //inicializar distancia en y para abajo
        distanciaY = 50f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Objeto soltado");

        if (objetosAEnCasilla >= 2 || totalObjetosAEnCasillas >= 2) return;

        if (eventData.pointerDrag != null && eventData.pointerDrag.CompareTag(requiredTag))
        {
            //comentada antigua forma para alinear
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //nueva forma de alinear
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                GetComponent<RectTransform>().anchoredPosition.x,
                GetComponent<RectTransform>().anchoredPosition.y - distanciaY); // Alineaci�n con offset en Y
            objetosAEnCasilla++;
            totalObjetosAEnCasillas++;
            // Actualizar el texto del TextMeshPro con el nuevo valor
            textoTotalObjetos.text = totalObjetosAEnCasillas + "/2";
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
        // Hacer aparecer el objeto configurando su canal alfa al m�ximo
        imagen.color = new Color(imagen.color.r, imagen.color.g, imagen.color.b, 1f);

        // Seleccionar aleatoriamente un sprite del array
        if (sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            imagen.sprite = sprites[randomIndex];
        }
        else
        {
            Debug.LogWarning("No se han asignado sprites en el Inspector.");
        }
    }
}

