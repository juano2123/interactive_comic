using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChorroInteraction : MonoBehaviour
{

    private float tiempo;
    
    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            tiempo += Time.deltaTime;
            Debug.Log("Collision");
        }
    }
}
