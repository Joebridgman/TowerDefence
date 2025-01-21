using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour {

    public List<Dog> currentDogs;
    public Waypoint spawn;
    public List<int> dogsToSpawn;
    public List<float> timeToSpawn;
    private float timer;
    public List<Dog> dogs;
    public bool startRound;

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if (startRound) {
            if (dogsToSpawn.Count > 0) {
                if (timer > timeToSpawn[0]) {
                    var newDog = Instantiate(dogs[dogsToSpawn[0]], spawn.transform.position, new Quaternion());
                    newDog.target = spawn;
                    currentDogs.Add(newDog);
                    timeToSpawn.RemoveAt(0);
                    dogsToSpawn.RemoveAt(0);
                }
            }
            else {
                startRound = false;
            }
        }
        else {
            timer = 0;
        }
    }
}
