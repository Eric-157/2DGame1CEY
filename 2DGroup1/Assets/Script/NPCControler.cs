using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControler : MonoBehaviour
{

    public string dialogToShow;
    private TextMeshProUGUI dialog;
    private bool showWords = false;
    private bool isRunning = false;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] dialogObj = GameObject.FindGameObjectsWithTag("Talking");
        dialog = dialogObj[0].GetComponent<TextMeshProUGUI>();
        dialog.text = " ";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        StopAllCoroutines();
        showWords = true;
        if(collision.tag == "Player"){
            dialog.text = "";
            StartCoroutine(TypeWriter(dialogToShow));
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        dialog.text = "";
    }

     private IEnumerator TypeWriter(string text)
    {
        isRunning = true;
        foreach(char character in text.ToCharArray())
        {
            if(showWords){
                dialog.text += character;
                yield return new WaitForSeconds(0.02f);
            }
            else{
                Debug.Log("stop talking");
                yield break;
            }
        }
        showWords = false;
        isRunning = false;
    }

}
