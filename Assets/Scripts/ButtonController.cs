using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour { 


    public void OnPlayButtonClicked() {
        SceneManager.LoadScene("GreenPastures");
    }

}