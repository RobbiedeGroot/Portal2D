using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillScript : MonoBehaviour
{
    private GameObject PortOrange;
    private GameObject PortBlue;

    private void OnTriggerEnter2D(Collider2D other) {
        
        PortBlue = GameObject.Find("portalblue(Clone)");
        PortOrange = GameObject.Find("portalorange(Clone)");

        if(other.gameObject.CompareTag("Player")){
            if(PortOrange != null){
                Destroy(PortOrange);
            }
            if(PortBlue != null){
                Destroy(PortBlue);
            }
        }
        
        if(other.gameObject.CompareTag("Cube")){
            Destroy(other.gameObject);
        }
    }

}
