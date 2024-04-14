using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NegativeFeed : MonoBehaviour, IPointerClickHandler
{
    public GameObject self;
    public void OnPointerClick(PointerEventData eventData)
    {
        DesactivarFeed();
    }

    public void DesactivarFeed() {
        self.SetActive(false);
    }

}
