using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleManager : MonoBehaviour
{
    public string textToSay;
    
    private SpriteRenderer chatBg;
    private TextMeshPro TextMeshPro;
    
    private void Awake() 
    {
        TextMeshPro = transform.Find("TextLine").GetComponent<TextMeshPro>();
        chatBg = transform.Find("ChatBackground").GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        setup(textToSay);
    }

    
    private void setup(string text)
    {
        TextMeshPro.SetText(text);
        TextMeshPro.ForceMeshUpdate();
        
        Vector2 textSize = TextMeshPro.GetRenderedValues(false);
        
        Vector2 padding = new Vector2(0.5f, 1.2f);
        
        chatBg.size = textSize+padding;
    }
}
