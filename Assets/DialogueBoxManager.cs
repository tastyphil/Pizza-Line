using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxManager : MonoBehaviour
{   
    private List<string> pizzaOptions = new List<string> { "Pepperoni", "Cheese", "BBQ Chicken", "Hawaiian", "Bacon n Cheese" };
    public int[] order;
    public string greeting, address;

    public void PrintOrder() {
        
    }
    public void UpdateGreeting(int n) {
        if (n == 1) {

        } else if (n == 2) {
            
        } else if (n == 3) {
            
        } else if (n == 4) {
            
        } else if (n == 5) {
            
        }
    }
}
