using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public string sceneName;
    public PlayerController playerController;

    void OnTriggerEnter2D(Collider2D collision){
        SceneManager.LoadScene(sceneName);
    }

    void Awake(){
        int xOffset = 0;
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
        if (transform.position.x > 0){
            xOffset = -2;
        }
        else{
            xOffset = +2;
        }
        playerController.gameObject.transform.position = new Vector2(transform.position.x+xOffset, transform.position.y);
    }
}
