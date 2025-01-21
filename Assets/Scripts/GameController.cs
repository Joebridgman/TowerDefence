using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int currentRound = 0;
    private bool roundOver = true;
    public LevelReader levelReader;
    public DogSpawner dogSpawner;

    void Update() {

        if (dogSpawner.currentDogs.Count == 0) {
            roundOver = true;
        }
        else if (dogSpawner.currentDogs[0] == null) {
            dogSpawner.currentDogs.RemoveAt(0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && roundOver) {
            levelReader.LoadRound(currentRound);
            currentRound++;
            dogSpawner.startRound = true;
            roundOver = false;
        }        
    }
}
