using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public List<Sprite> clouds;
    public GameObject cloud;
    private float spawnTimer;

    void Start() {
        int initialCloudCount = UnityEngine.Random.Range(3, 10);
        for (int i = 0; i < initialCloudCount; i++) {
            SpawnCloud(-10, 11); 
        }
    }

    void Update() {

        spawnTimer += Time.deltaTime;

        if (spawnTimer > 3) {
            SpawnCloud(12, 21);
            spawnTimer = 0;
        }
    }

    private void SpawnCloud(int lowerX, int upperX) {
        int spawnX = UnityEngine.Random.Range(lowerX, upperX);
        int spawnY = UnityEngine.Random.Range(-5, 6);
        int cloudSelector = UnityEngine.Random.Range(1, 5);
        int cloudScaler = UnityEngine.Random.Range(10, 31);
        Vector3 cloudLocation = new Vector3(spawnX, spawnY, 0);
        var cloudObject = Instantiate(cloud, cloudLocation, new Quaternion());
        cloudObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2 * (-Math.Abs(spawnX) - Math.Abs(spawnY)), 0));
        cloudObject.gameObject.transform.localScale *= cloudScaler;
        cloudObject.GetComponent<SpriteRenderer>().sprite = clouds[cloudSelector % 4];
    }
}
