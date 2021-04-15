using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThis : MonoBehaviour
{
    public GameObject enablethis;
    private bool Once;
    // Start is called before the first frame update
    void Start()
    {
        enablethis.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (Once == false)
        {
            enablethis.SetActive(true);
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        enablethis.SetActive(false);
        Once = true;
    }
}
