using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private TMP_Text countdownText;
    private float countdownTime = 10f; // 10 seconds

    void Start()
    {
        // Automatically find the CountdownText object
        countdownText = GameObject.Find("CountdownText").GetComponent<TMP_Text>();
        if (countdownText == null)
        {
            Debug.LogError("CountdownText object not found!");
        }
    }

    void Update()
    {
        if (countdownText != null)
        {
            if (countdownTime > 0)
            {
                countdownTime -= Time.deltaTime;
                countdownText.text = Mathf.Ceil(countdownTime).ToString();
            }
            else
            {
                countdownText.text = "Happy 2025!";
            }
        }
    }
}
