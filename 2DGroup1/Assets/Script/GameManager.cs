using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController playerController;
    public TextMeshProUGUI energyDisplay;


    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");
        playerController = playerObj[0].GetComponent<PlayerController>();
        playerController.SetUpPlayer();

        GameObject[] levelTransitionsObj  = GameObject.FindGameObjectsWithTag("Door");
        Debug.Log(levelTransitionsObj.Length);
        foreach (GameObject i in levelTransitionsObj){
            LevelController levelTransitions = i.GetComponent<LevelController>(); 
            Debug.Log(levelTransitions.sceneNumber + " " + playerController.doorNumber);
            if (levelTransitions.sceneNumber == playerController.doorNumber){
                levelTransitions.SpawnLocation(playerController);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        energyDisplay.text = ("Energy: "+ playerController.energy);
    }
}
