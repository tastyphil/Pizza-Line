using UnityEngine;

public class House : MonoBehaviour
{
    private string[] hColor = {"Black", "Blue", "Green", "Grey", "Orange", "Pink", "Purple", "Yellow"};
    private string[] dColor = {"Blue", "Brown", "Green", "Red", "White"};
    public Sprite[] sprites;
    public string houseColor, doorColor;

    void Start()
    {
        InitHouse(39);
        PrintHouse();
    }

    public void InitHouse(int n) {
        int getHouseColor = ((n/5) == 0) ? 1 : (n/5);
        int getDoorColor = n % 5;
        houseColor = hColor[getHouseColor];
        doorColor = dColor[getDoorColor];
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[n];
    }

    public void PrintHouse() {
        Debug.Log($"House:{houseColor}");
        Debug.Log($"Door:{doorColor}");
    }
}
