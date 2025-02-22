using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Order
{
    public GameObject target;
    public List<string> list;

    public bool IsCorrectTarget(string s) {
        House script = target.GetComponent<House>();
        string[] house_door = s.Split("_");

        bool correctHouse = script.GetHouseColor().ToLower().Equals(house_door[0]);
        bool correctDoor = script.GetDoorColor().ToLower().Equals(house_door[1]);

        return correctDoor & correctHouse;
    }

    public bool IsCorrectOrder(string[] arr) {
        bool result = false;

        foreach (string x in arr) {
            result = list.IndexOf(x) > -1;
        }   

        return result;
    }
}
