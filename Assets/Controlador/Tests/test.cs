using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement; // Usado para pruebas en modo de edición
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class test
{
    // Constante con la ruta de la escena de prueba
    private const string TestScenePath = "Assets/Vista/Scenes/MiniJuego1.unity"; // Asegúrate de que la ruta de la escena sea correcta

    // Método para cargar la escena de prueba
    [SetUp]
    public void Setup()
    {
        // Carga la escena en el modo de edición usando EditorSceneManager
        EditorSceneManager.OpenScene(TestScenePath, OpenSceneMode.Single);
    }

    // Prueba para verificar la interacción con un elemento de UI específico, como un botón o una pieza del puzzle
    [UnityTest]
    public IEnumerator FullGameInteractionTest()
    {
        // Esperar un frame para que la escena se cargue completamente
        yield return null;

        // Encuentra el botón dentro del canvas y simula un clic
        var puzzleButton = GameObject.Find("Button").GetComponent<Button>();
        Assert.IsNotNull(puzzleButton, "PuzzleButton not found in the scene");
        puzzleButton.onClick.Invoke();

        // Encuentra y simula un clic en "bombillaMala (2)"
        var badBulb = GameObject.Find("bombillaMala (2)");
        Assert.IsNotNull(badBulb, "bombillaMala (2) not found in the scene");

       

        // Espera un frame para procesar los efectos del clic
        yield return null;

         //Comienza la prueba de arrastrar y soltar
         var draggableObject = GameObject.Find("Lampara");
         var targetSlot = GameObject.Find("bombillaBuena");
        Assert.IsNotNull(draggableObject, "DraggableObject not found");
        Assert.IsNotNull(targetSlot, "TargetSlot not found");

        // Preparar el eventData con la posición inicial exacta
        var initialPosition = new Vector3(-425, 331, 0); // Posición destino
         var screenPosition = Camera.main.WorldToScreenPoint(initialPosition);

          var pointerEventData = new PointerEventData(EventSystem.current)
         {
           pressPosition = screenPosition,
          position = screenPosition
         };

        // Simular el clic inicial para comenzar el arrastre
          ExecuteEvents.Execute(draggableObject, pointerEventData, ExecuteEvents.pointerDownHandler);

         //Simula el proceso de arrastre
         pointerEventData.position = Camera.main.WorldToScreenPoint(targetSlot.transform.position);
          ExecuteEvents.Execute(draggableObject, pointerEventData, ExecuteEvents.dragHandler);

        // Espera un frame para procesar el arrastre
        yield return null;

        // Simula la liberación del objeto en la posición deseada
         ExecuteEvents.Execute(draggableObject, pointerEventData, ExecuteEvents.pointerUpHandler);

    }




    // Limpiar después de cada test
    [TearDown]
    public void Teardown()
    {
        // Cargar una escena básica antes de cerrar la escena de prueba
        EditorSceneManager.CloseScene(EditorSceneManager.GetActiveScene(), true);
    }

}
