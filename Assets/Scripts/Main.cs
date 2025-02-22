using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static bool shiftOn = true;
    public static string houseSelected, houseDialogue;
    public GameObject tempHouse, section1, section2, timerObj;
    public Timer timer;
    public List<GameObject> houses;
    public int orderIndex = 0;

    public List<Order> callList = new List<Order>();

    public TMP_Text currOrderDisplay, dialogueBox, selectedHouse, correct;
    public int[] currOrder;
    private List<string> pizzaOptions = new List<string> { "Pepperoni", "Cheese", "BBQ Chicken", "Hawaiian", "Bacon n Cheese" };
    public static int correctOrders = 0;

    void Start() {
        timer = timerObj.GetComponent<Timer>();
        GenerateHouses();
        GenerateCalls(100);
        ResetParameters();
        DisplayCall();
    }

    // Update is called once per frame
    void Update() {
        selectedHouse.text = houseDialogue;
        if (!timer.timerActive) {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ResetParameters()
    {
        houseSelected = "";
        houseDialogue = "";
        currOrder = new int[5];
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
    }

    public void DisplayCall() {
        callList[orderIndex].PrintOrder(UnityEngine.Random.Range(1,5));
        dialogueBox.text = callList[orderIndex].GetCallDialogue();
        UpdateCurrOrder();
        correct.text = $"Correct: {correctOrders}";
    }

    public void SendOrder() {
        Order call = callList[orderIndex];
        Debug.Log(houseSelected);
        bool correct = (call.IsCorrectTarget(houseSelected) && call.IsCorrectOrder(currOrder)) == true; 

        if (correct) {
            correctOrders++;
            AudioManager.Instance.PlaySFX("correct");
            Debug.Log($"CorrectOrders: {correctOrders}");
        } else{
            AudioManager.Instance.PlaySFX("wrong");
        }

        ResetParameters();
        orderIndex++;
        DisplayCall();
    }

    public void GenerateCalls(int n) {
        for (int i = 0; i < n; i++) {
            int[] tempArr = new int[5];
            for (int j = 0; j < 5; j++) {
                tempArr[j] = UnityEngine.Random.Range(1, 10);
            }
            callList.Add(new Order(houses[UnityEngine.Random.Range(0,houses.Count)], tempArr));
        }
    }
    public void AddToOrder(string s) {
        AudioManager.Instance.PlaySFX("click");
        currOrder[pizzaOptions.IndexOf(s)]++;
        UpdateCurrOrder();
    }

    public void UpdateCurrOrder() {
        string order = "";
        for (int i = 0; i < 5; i++) {
            order += $"[{currOrder[i]}] {pizzaOptions[i]}\n";
        }
        currOrderDisplay.text = order;
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

    public static void UpdateSelectedHouse(string s) {
        houseSelected = s;
    }
}
