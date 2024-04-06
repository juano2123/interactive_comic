using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAvanzar : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool variable1;
    [SerializeField] private bool variable2;
    [SerializeField] private bool variable3;
    [SerializeField] private bool variable4;

    public BackgroundController backgroundController;

    //fedbacks
    public GameObject feedbackPositivo;
    public GameObject feedbackNegativo;

    public void OnPointerClick(PointerEventData eventData)
    {
        ActivarFuncion();
    }

    void ActivarFuncion()
    {
        // Acceder a las variables del otro script
        bool v1 = backgroundController.background1;
        bool v2 = backgroundController.background2;
        bool v3 = backgroundController.background3;
        bool v4 = backgroundController.background4;

        if (v1 && variable1)
        {
            feedbackPositivo.SetActive(true);
        }
        else if (v2 && variable2)
        {
            feedbackPositivo.SetActive(true);
        }
        else if (v3 && variable3)
        {
            feedbackPositivo.SetActive(true);
        }
        else if (v4 && variable4)
        {
            feedbackPositivo.SetActive(true);
        }
        else 
        {
            feedbackNegativo.SetActive(true);
        }
    }
}
