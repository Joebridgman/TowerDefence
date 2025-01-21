using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    private XmlDocument itemDataXml;
    private List<string[]> dataList;
    public DogSpawner dogSpawner;

    void Start() {
        itemDataXml = new XmlDocument();
     
        itemDataXml.Load("Assets/Data/Rounds.xml");

        Debug.Log("Find all rounds.");
        XmlNodeList rounds = itemDataXml.SelectNodes("/Rounds/Round");

        dataList = new List<string[]>();

        foreach (XmlNode round in rounds) {
            string[] data = round.InnerText.Split(',');
            dataList.Add(data);
        }        
    }

    public void LoadRound(int round) {
        for (int i = 0; i < dataList[round].Length; i++) {
            var dogData = dataList[round][i].Split(" ");
            dogSpawner.dogsToSpawn.Add(Int32.Parse(dogData[0]));
            dogSpawner.timeToSpawn.Add(float.Parse(dogData[1]));
        }
        round++;
    }
}
