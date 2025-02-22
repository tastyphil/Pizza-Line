using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Order
{
    public GameObject target;
    public int[] order;
    string orderStr = "", callDialogue = "";
    private List<string> pizzaOptions = new List<string> { "Pepperoni", "Cheese", "BBQ Chicken", "Hawaiian", "Bacon n Cheese" };

    public Order(GameObject h, int[] i) {
        target = h;
        order = i;
    }

    public bool IsCorrectTarget(string s) {
        House script = target.GetComponent<House>();
        string[] house_door = s.Split("_");

        bool correctHouse = script.GetHouseColor().ToLower().Equals(house_door[0]);
        bool correctDoor = script.GetDoorColor().ToLower().Equals(house_door[1]);

        return correctDoor & correctHouse;
    }

    public bool IsCorrectOrder(int[] arr) {
        bool result = false;

        for (int i = 0; i < order.Length;i++) {
            result = order[i] == arr[i];
        }
        return result;
    }

    public void PrintOrder(int n) {
        House h =  target.GetComponent<House>();
        string door = h.GetDoorColor(), house = h.GetHouseColor();
        for (int i = 0; i < 5; i++) {
            orderStr+=$"{order[i]} {pizzaOptions[i]}";
            if (i+1 < 5) orderStr += ", ";
        }

        if (n == 1) {
           callDialogue += $"> One {orderStr} pizzas on the double!\n";
           callDialogue += $"> Send to {door} door in {house} house";
        } else if (n == 2) {
            callDialogue += $"> Hello! Can I get {orderStr} please?\n";
            callDialogue += $"> Perfect! I am here at {house} house with a {door} door";
        } else if (n == 3) {
            callDialogue += $"> I need {orderStr}\n";
            callDialogue += $"> {door} door/{house} house";
        } else if (n == 4) {
            callDialogue += $"> Mr. Phil's! I am in dire need of some {orderStr}!\n";
            callDialogue += $"> Splendid! I will be waiting at {house} house with a {door} door";
        } else if (n == 5) {
            callDialogue += $"> henlo, me get {orderStr} piza\n";
            callDialogue += $"> Come to {door} door {house} house :3";
        }
        Debug.Log($"HouseCalling:{h.GetHouseColor()}_{h.GetDoorColor()}");
        Debug.Log($"Order: {orderStr}");
        Debug.Log(callDialogue);
    }

    public string GetCallDialogue() {
        return callDialogue;
    }
}
