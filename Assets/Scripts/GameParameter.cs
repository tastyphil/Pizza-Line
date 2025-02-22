using UnityEngine;

public class GameParameter : MonoBehaviour {
    public static GameParameter Instance;
    public static int correctOrders;


    public void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public int getCorrectOrders() {
        return correctOrders;
    }

    public void setCorrectOrders(int i) {
        correctOrders = i;
    }
}
