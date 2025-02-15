using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{

    public int energyCost;
    private bool canBeUsed;

    public PlayerController playerController;

    void Awake(){
        
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
        for (int i = 0; i < playerController.names.Count; i++){
            if(playerController.names[i] == gameObject.name){
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        canBeUsed = true;
    }

    void OnTriggerExit2D(Collider2D collision){
        canBeUsed = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canBeUsed){
            playerController.energy -= energyCost;
            playerController.saveData.playerData.objectNames.Add(gameObject.name);
            Destroy(gameObject);
        }
    }

}
