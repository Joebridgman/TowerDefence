using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int currentRound = 0;
    private bool roundOver = true;
    public LevelReader levelReader;
    public DogSpawner dogSpawner;
    public MapUI mapUI;
    public int currentMoney;
    public MoneyDisplay moneyDisplay;
    private bool placingCat;
    private GameObject catToPlace;

    void Start() {
        moneyDisplay.UpdateDisplay(currentMoney, 0);
    }

    void Update() {

        if (dogSpawner.currentDogs.Count == 0) {
            roundOver = true;
        }
        else if (dogSpawner.currentDogs[0] == null) {
            dogSpawner.currentDogs.RemoveAt(0);
        }

        for (int i = 0; i < dogSpawner.currentDogs.Count; i++) {
            Dog dog = dogSpawner.currentDogs[i];
            if (dog.health <= 0) {
                currentMoney += dog.value;
                moneyDisplay.UpdateDisplay(currentMoney, dog.value);
                Destroy(dog.gameObject);
                dogSpawner.currentDogs.Remove(dog);
                i--;
                mapUI.UpdateButtons();
                //death animation
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && roundOver) {
            levelReader.LoadRound(currentRound);
            currentRound++;
            dogSpawner.startRound = true;
            roundOver = false;
        }    
        
        if (placingCat && catToPlace.GetComponent<Cat>().blockingBounds.Count == 0 && Input.GetMouseButtonDown(0)) {
            placingCat = false;
            catToPlace.GetComponent<Cat>().isPlaced = true;
            catToPlace.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            currentMoney -= catToPlace.GetComponent<Cat>().cost;
            moneyDisplay.UpdateDisplay(currentMoney, -catToPlace.GetComponent<Cat>().cost);
            mapUI.UpdateButtons();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && placingCat) {
            placingCat = false;
            Destroy(catToPlace);
        }
    }

    public void PlacingCat(GameObject cat) {
        if (placingCat) {
            Destroy(catToPlace);//next step is stop button highlight changing as it currently does
        }
        Debug.Log(cat.name);
        catToPlace = Instantiate(cat, new Vector2(0,0), new Quaternion());
        catToPlace.GetComponent<Cat>().isPlaced = false;
        catToPlace.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        placingCat = true;
    }
}
