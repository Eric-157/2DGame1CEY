using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public int sceneNumber;
    public PlayerController playerController;
    private GameObject[] playerObj;


    void Awake()
    {
        playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        playerController.saveData.SaveToJson();
        SceneManager.LoadScene(sceneNumber);
    }


    public void SpawnLocation(PlayerController playerController){
       
        Debug.Log("please work");
        int xOffset = 0;
        if (transform.position.x > 0){
            xOffset = -4;
        }
        else{
            xOffset = +4;
        }
        playerController.transform.position = new Vector3(transform.position.x+xOffset, transform.position.y, -10);
    }
}
