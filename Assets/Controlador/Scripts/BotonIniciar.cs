using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{
    public Image imagen;
    // Start is called before the first frame update
    void Start()
    {
        // Obtener el componente Image del objeto que act�a como bot�n
        imagen = GetComponent<Image>();

        // Agregar un listener al objeto para que llame al m�todo CargarEscena al ser seleccionado
        imagen.GetComponent<Button>().onClick.AddListener(CargarEscena);
    }

    void CargarEscena()
    {
        SceneManager.LoadScene("Minijuego1");
    }
}
