using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject eatingPanel;
    public GameObject sleepingPanel;
    public GameObject showeringPanel;
    public GameObject workingPanel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowEatingPanel()
    {
        eatingPanel.SetActive(true);
    }

    public void ShowSleepingPanel()
    {
        sleepingPanel.SetActive(true);
    }

    public void ShowShoweringPanel()
    {
        showeringPanel.SetActive(true);
    }

    public void ShowWorkingPanel()
    {
        workingPanel.SetActive(true);
    }

    public void HideInteractionPanel()
    {
        eatingPanel.SetActive(false);
        sleepingPanel.SetActive(false);
        showeringPanel.SetActive(false);
        workingPanel.SetActive(false);
        PauseGame(false);
    }

    public void StartEatingCountdown()
    {
        StartCountdown(eatingPanel,"Eating...", 10); // Assuming 10 seconds for eating
    }

    public void StartSleepingCountdown()
    {
        StartCountdown(sleepingPanel, "Sleeping...", 10); 
    }

    public void StartShoweringCountdown()
    {
        StartCountdown(showeringPanel, "Showering...", 10); 
    }




    public void StartCountdown(GameObject panel, string actionText, int duration)
    {
        AudioSource audioSource = panel.GetComponent<AudioSource>();
        audioSource.Play();  // Play sound

        TextMeshProUGUI actionTextComponent = panel.transform.Find("ActionText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI timerTextComponent = panel.transform.Find("TimerText").GetComponent<TextMeshProUGUI>();

        // Access the buttons
        Button yesButton = panel.transform.Find("YesButton").GetComponent<Button>();
        Button noButton = panel.transform.Find("NoButton").GetComponent<Button>();

        // Disable the buttons
        yesButton.interactable = false;
        noButton.interactable = false;

        actionTextComponent.text = actionText;  // Set the action text, e.g., "Eating"
        StartCoroutine(CountdownCoroutine(timerTextComponent, duration, audioSource, panel, yesButton, noButton));
    }

    IEnumerator CountdownCoroutine(TextMeshProUGUI timerText, int duration, AudioSource audioSource, GameObject panel, Button yesButton, Button noButton)
    {
        int timeLeft = duration;
        while (timeLeft > 0)
        {
            timerText.text = timeLeft + " seconds remaining...";
            yield return new WaitForSecondsRealtime(1);
            timeLeft--;
        }

        timerText.text = "";
        panel.SetActive(false);
        audioSource.Stop();
        PauseGame(false);

        // Re-enable the buttons after the countdown is complete and the panel is closed
        yesButton.interactable = true;
        noButton.interactable = true;

        // Reset the action text 
        TextMeshProUGUI actionTextComponent = panel.transform.Find("ActionText").GetComponent<TextMeshProUGUI>();
        actionTextComponent.text = "Do you want to " + panel.name.Replace("Panel", "") + "?";  // Resets action text based on panel name

        // Update player state based on the panel
        UpdatePlayerState(panel.name);
    }

    void UpdatePlayerState(string panelName)
    {
        if (panelName.Contains("eat"))
            PlayerNeedsManager.Instance.SetEaten();
        else if (panelName.Contains("sleep"))
            PlayerNeedsManager.Instance.SetSlept();
        else if (panelName.Contains("shower"))
            PlayerNeedsManager.Instance.SetShowered();
    }




    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;  // Stops the time, effectively pausing the game
            Cursor.lockState = CursorLockMode.None; // Frees the cursor
            Cursor.visible = true; // Makes the cursor visible
        }
        else
        {
            Time.timeScale = 1;  // Resumes the time
            Cursor.lockState = CursorLockMode.None; // Locks the cursor back to the center of the screen
            Cursor.visible = true; 
        }
    }

}
