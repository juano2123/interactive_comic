using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PositiveFeedBack : MonoBehaviour, IPointerClickHandler
{
    //acedemos al controlador de background
    public BackgroundController backgroundController;

    //referencia a si mismo para quitar la pantalla al finaliza ejecucion
    public GameObject self;

    //pantallas para elegir planta que vamos a apagar
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;
    public GameObject tree4;

    //ultimo fondo
    public GameObject fondoFinal;

    public void OnPointerClick(PointerEventData eventData)
    {
        ModificarFondo();
    }

    public void ModificarFondo() {
        //lo que hacemos es mirar el valor booleano de fondo 1,2,3 y 4
        //y hacemos un cambio de variable 
        //si el fondo es 1 vamos a hacer una transicion de cambiar variable a 2
        //el cual vuelve el primero falso el segundo verdadero y los otros 2 falsos
        //se hace asi ya que el boton de plantar necesita saber el estado del fondo

        //comprobamos si el fondo 1 esta activo
        if (backgroundController.background1)
        {
            //entonces vamos a cambiar las variables a caso 2
            backgroundController.CambiarVariable(2);
            self.SetActive(false);
            //de paso desactivamos las opciones activadas para mejor transicion
            tree1.SetActive(false);
        }
        else if (backgroundController.background2)
        {
            backgroundController.CambiarVariable(3);
            self.SetActive(false);
            tree2.SetActive(false);
        }
        else if (backgroundController.background3)
        {
            backgroundController.CambiarVariable(4);
            self.SetActive(false);
            tree3.SetActive(false);
        }
        else if (backgroundController.background4) {
            //aqui seria la finalizacion completa del minijuego
            //asi que llamamos al ultimo fondo como retroalimentación
            tree4.SetActive(false);
            fondoFinal.SetActive(true);
            self.SetActive(false);
        }

        


    }
}
