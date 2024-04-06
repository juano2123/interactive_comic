using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public bool background1;
    public bool background2;
    public bool background3;
    public bool background4;

    public GameObject objetoUI1;
    public GameObject objetoUI2;
    public GameObject objetoUI3;
    public GameObject objetoUI4;

    void Start()
    {
        background1 = true;
        background2 = false;
        background3 = false;
        background4 = false;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        objetoUI1.SetActive(background1);
        objetoUI2.SetActive(background2);
        objetoUI3.SetActive(background3);
        objetoUI4.SetActive(background4);
    }

    void ActualizarVariables(bool v1, bool v2, bool v3, bool v4)
    {
        background1 = v1;
        background2 = v2;
        background3 = v3;
        background4 = v4;
        ActualizarUI();
        //Debug.Log("variables fondo:" + background1 + background2 + background3 + background4);
    }

    public void CambiarVariable(int numeroVariable)
    {
        switch (numeroVariable)
        {
            case 1:
                ActualizarVariables(true, false, false, false);
                break;
            case 2:
                ActualizarVariables(false, true, false, false);
                break;
            case 3:
                ActualizarVariables(false, false, true, false);
                break;
            case 4:
                ActualizarVariables(false, false, false, true);
                break;
            default:
                Debug.LogError("Número de variable no válido.");
                break;
        }
    }
}
