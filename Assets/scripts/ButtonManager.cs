using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject Door;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Cube")){
            Debug.Log("door");
            Door.SetActive(false);
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Cube")){
            Door.SetActive(true);
        }
    }
}
