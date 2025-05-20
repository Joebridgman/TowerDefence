using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour {

    public GameObject moneyParticle;
    public List<GameObject> moneyParticleList;

    void Start() {
        moneyParticleList = new List<GameObject>();
    }

    void Update() {
        for (int i = 0; i < moneyParticleList.Count; i++) {
            if (moneyParticleList[i].transform.position.y < -10) {
                Destroy(moneyParticleList[i].gameObject);
                moneyParticleList.RemoveAt(i);
            }
        }
    }

    public void UpdateDisplay(int initialAmount, int amountChanged) {
        GetComponent<TextMeshProUGUI>().text = initialAmount.ToString();
        if (amountChanged > 0) {
            CreateAmountGainedParticle(amountChanged);
        }
        else if (amountChanged < 0) {
            CreateAmountLostParticle(amountChanged);
        }
    }

    private void CreateAmountGainedParticle(int amountGained) {
        var newObject = Instantiate(moneyParticle, transform.position, new Quaternion(), transform);
        var anglularForce = Random.Range(-amountGained, amountGained);
        newObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(anglularForce, 100));
        newObject.GetComponent<TextMeshPro>().text = "+" + amountGained.ToString();
        newObject.GetComponent<TextMeshPro>().color = Color.green;
        moneyParticleList.Add(newObject);
    }

    private void CreateAmountLostParticle(int amountLost) {
        var newObject = Instantiate(moneyParticle, transform.position, new Quaternion(), transform);
        var anglularForce = Random.Range(100, -100);
        newObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(anglularForce, -amountLost));
        newObject.GetComponent<TextMeshPro>().text = amountLost.ToString();
        newObject.GetComponent<TextMeshPro>().color = Color.red;
        moneyParticleList.Add(newObject);
    }
}
