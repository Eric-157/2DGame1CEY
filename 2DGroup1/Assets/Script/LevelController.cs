using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public string sceneName;
    public int doorNumber;
    public PlayerController playerController;

    void OnTriggerEnter2D(Collider2D collision){
        playerController.saveData.playerData.doorLeft = doorNumber;
        playerController.saveData.SaveToJson();
        SceneManager.LoadScene(sceneName);
    }

    void Awake(){
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
    }

    public void SpawnLocation(){
        int xOffset = 0;
        if (transform.position.x > 0){
            xOffset = -2;
        }
        else{
            xOffset = +2;
        }
        playerController.gameObject.transform.position = new Vector2(transform.position.x+xOffset, transform.position.y);
    }
}
