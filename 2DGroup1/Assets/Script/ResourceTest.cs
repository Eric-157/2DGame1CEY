using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{

    public int energyCost;

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

    void OnTriggerStay2D(Collider2D collision){
        Debug.Log("shit is working");
        if(Input.GetKeyDown(KeyCode.E)){
            playerController.energy -= energyCost;
            playerController.saveData.playerData.objectNames.Add(gameObject.name);
            Destroy(gameObject);
        }
    }
    
}
