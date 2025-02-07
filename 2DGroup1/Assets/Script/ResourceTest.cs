using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{

    public PlayerController playerController;

    void Awake(){
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
    }

    void OnCollisionStay2D(Collision2D collision2D){
        if(Input.GetKeyDown(KeyCode.V)){
            playerController.energy -= 10;
            Destroy(gameObject);
        }
    }
    
}
