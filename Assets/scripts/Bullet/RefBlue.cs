using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefBlue : MonoBehaviour
{
    public GameObject port2;
    private RefOrange refToOrange;
    public bool exitBlue = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && exitBlue == true)
        {
            //finds the other portal
            port2 = GameObject.Find("portalorange(Clone)");
            if (port2 != null)
            {
                //gets the location of the other portal, turns it off and then teleports the player.
                refToOrange = port2.GetComponent<RefOrange>();
                refToOrange.exitOrange = false;
                other.gameObject.transform.position = port2.transform.position;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //turns the portal back on
        exitBlue = true;
    }
}
