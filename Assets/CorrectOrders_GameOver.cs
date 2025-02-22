using TMPro;
using UnityEngine;

public class CorrectOrders_GameOver : MonoBehaviour
{
    public TMP_Text txt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlayMusic("menu");
        txt.text = $"Correct Orders: {GameParameter.Instance.getCorrectOrders()}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
