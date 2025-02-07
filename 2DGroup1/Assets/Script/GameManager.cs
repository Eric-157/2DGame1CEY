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
        GameObject[] levelTransitionsObj  = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject i in levelTransitionsObj){
            LevelController levelTransitions = i.GetComponent<LevelController>(); 
            if (levelTransitions.doorNumber == playerController.saveData.playerData.doorLeft){
                levelTransitions.SpawnLocation();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        energyDisplay.text = ("Energy: "+ playerController.energy);
    }
}
