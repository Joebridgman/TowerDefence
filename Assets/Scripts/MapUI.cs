using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour {

    public List<Cat> catsForSale;
    private List<GameObject> catButtons;
    public GameObject catButton;
    public GameController gameController;

    private enum ChildCategory {
        Text = 0,
        Image = 1,
    }
    // Start is called before the first frame update
    void Start() {
        int y = -1;
        catButtons = new List<GameObject>();
        for (int i = 0; i < catsForSale.Count; i++) {
            var newObject = Instantiate(catButton, gameObject.transform);
            if (i % 2 == 0) {
                y++;
                newObject.GetComponent<RectTransform>().anchorMin = new Vector2(0.05f, 0.78f);
                newObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.45f, 0.98f);
            }
            else {
                newObject.GetComponent<RectTransform>().anchorMin = new Vector2(0.55f, 0.78f);
                newObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.95f, 0.98f);            
            }
            newObject.transform.position += new Vector3(0, -4 * y);            
            newObject.transform.GetChild((int)ChildCategory.Image).gameObject.GetComponent<Image>().sprite = catsForSale[i].defaultSprite;
            newObject.transform.GetChild((int)(ChildCategory.Text)).gameObject.GetComponent<TextMeshProUGUI>().text = catsForSale[i].cost.ToString();
            newObject.GetComponent<ButtonController>().prefab = catsForSale[i].gameObject;
            newObject.GetComponent<Button>().onClick.AddListener(delegate() { gameController.PlacingCat(newObject.GetComponent<ButtonController>().prefab); });
            
            catButtons.Add(newObject);
        }
        UpdateButtons();
    }

    public void UpdateButtons() {
        foreach (var catButton in catButtons) {
            if (catButton.GetComponent<ButtonController>().prefab.GetComponent<Cat>().cost <= gameController.currentMoney) {
                catButton.GetComponent<Button>().interactable = true;
            }
            else {
                catButton.GetComponent<Button>().interactable = false;
            }
        }
    }
}
