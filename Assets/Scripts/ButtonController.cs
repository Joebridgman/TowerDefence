using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public GameObject prefab;

    public void OnPlayButtonClicked() {
        SceneManager.LoadScene("GreenPastures");
    }

    public void OnPauseButtonClicked() {

    }
}
