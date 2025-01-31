using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public Scene scene;

    void OnTriggerEnter2D(Collider2D collision){
        string sceneName = scene.name;
        SceneManager.LoadScene(sceneName);
    }
}
