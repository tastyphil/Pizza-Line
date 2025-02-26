using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : MonoBehaviour
{
    public GameObject me;
    private string[] hColor = {"Black", "Blue", "Green", "Grey", "Orange", "Pink", "Purple", "Yellow"};
    private string[] dColor = {"Blue", "Brown", "Green", "Red", "White"};
    public Sprite[] sprites;
    public string houseColor, doorColor;

    public void InitHouse(int n) {
        int getHouseColor = ((n/5) == 0) ? 1 : (n/5);
        int getDoorColor = n % 5;
        houseColor = hColor[getHouseColor];
        doorColor = dColor[getDoorColor];
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[n];
    }

    public void PrintHouse() {
        Debug.Log($"House and Door:{houseColor}_{doorColor}");
    }

    public void OnMouseDown() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            Main.houseDialogue = "Selected:\n" + $"> House: {houseColor}\n> Door: {doorColor}";
            Main.UpdateSelectedHouse(houseColor + "_" + doorColor);
        }
    }

    public void InitPos(float x, float y, float z) {
        me.SetActive(true);
        transform.position = new Vector3(x,y,z);
    }

    public string GetHouseColor() {
        return houseColor;
    }

    public string GetDoorColor() {
        return doorColor;
    }
        
    
}
