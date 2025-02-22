using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static string houseSelected;
    public GameObject tempHouse, section1, section2;
    public List<GameObject> houses;

    void Start()
    {
        GenerateHouses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateHouses() {
        List<GameObject> arr = new List<GameObject>();
        for (int i = 0; i < 40; i++) {
            GameObject newHouse = Instantiate(tempHouse);
            House newHouseScript = newHouse.GetComponent<House>();
            newHouseScript.InitHouse(i);
            arr.Add(newHouse);
        }

        arr = arr.OrderBy(i => Guid.NewGuid()).ToList();
        GenerateSection(arr, -16,7.5f,-1, section1);
        GenerateSection(arr, -16,-2,-1, section2);
        foreach (GameObject item in arr) {
            if (item.transform.parent == null) Destroy(item);
        }

        int counter = 1;
        foreach(var item in houses) {
            var s = item.GetComponent<House>();
            s.PrintHouse();
            Debug.Log(counter);
            counter++;
        }
    }

    public void GenerateSection(List<GameObject> arr, float x, float y, float z, GameObject parent) {
        float xPos = x;
        float yPos = y;
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 2; j++) {
                GameObject h = arr[arr.Count-1];
                houses.Add(h);
                arr.Remove(h);
                h.transform.parent = parent.transform;

                House script = h.GetComponent<House>();
                script.InitPos(xPos + (i * 4), yPos - (j*4), z);
            }            
        }
    }
}
