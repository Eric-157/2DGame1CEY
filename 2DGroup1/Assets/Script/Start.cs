using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public SaveData saveData;

    // Start is called before the first frame update
    void Awake()
    {
        saveData = GetComponent<SaveData>();
        saveData.playerData.playerEnergy = 100;
        saveData.playerData.doorLeft = 2;
        saveData.playerData.objectNames = new List<string>();
        saveData.SaveToJson();
    }

    public void NextScene()
    {
        SceneManager.LoadScene("GrayboxSpawn");
    }
}
