using UnityEngine;
using TMPro; 

public class PlayerNeedsUI : MonoBehaviour
{
    public PlayerNeedsManager needsManager;

    public TextMeshProUGUI eatenText;
    public TextMeshProUGUI sleptText;
    public TextMeshProUGUI showeredText;

    private void Update()
    {
        //update UI text based on player needs
        eatenText.text = "Eaten: " + (needsManager.hasEaten ? "Yes" : "No");
        sleptText.text = "Slept: " + (needsManager.hasSlept ? "Yes" : "No");
        showeredText.text = "Showered: " + (needsManager.hasShowered ? "Yes" : "No");
    }
}
