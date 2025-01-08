using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private TMP_Text countdownText;
    private float countdownTime = 10f; // 10 seconds
    [SerializeField] private GameObject fireworkPrefab;



    private bool fireworkInstantiated = false; 

    void Start()
    {
        // Suche den Countdown-Text
        countdownText = GameObject.Find("CountdownText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (countdownText != null)
        {
            if (countdownTime > 0)
            {
                // Countdown läuft
                countdownTime -= Time.deltaTime;
                countdownText.text = Mathf.Ceil(countdownTime).ToString();
            }
            else
            {

                countdownText.text = "Happy 2025!";

                if (!fireworkInstantiated)
                {
             
                    InstantiateFirework();
                    fireworkInstantiated = true;
                }
            }
        }
    }

    void InstantiateFirework()
    {
        Vector3 position = new Vector3(1296.5f, 493.9f, -15.1f);
        Instantiate(fireworkPrefab, position, Quaternion.identity);
    }

}
