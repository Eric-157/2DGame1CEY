using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControler : MonoBehaviour
{

    public string dialogToShow;
    public TextMeshProUGUI dialog;
    public Canvas canvas;
    private bool showWords = false;

    // Start is called before the first frame update
    void Awake()
    {
        Canvas canvas = FindAnyObjectByType<Canvas>();
        dialog.transform.parent = canvas.transform;
        dialog.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        showWords = true;
        if(collision.tag == "Player"){
            dialog.text = "";
            StartCoroutine(TypeWriter(dialogToShow));
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        showWords = false;
        if(collision.tag == "Player"){
            dialog.text = "";
        }
    }

     private IEnumerator TypeWriter(string text)
    {
        foreach(char character in text.ToCharArray())
        {
            if(showWords){
                dialog.text += character;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

}
