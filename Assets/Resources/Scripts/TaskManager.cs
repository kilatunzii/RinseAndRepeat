using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> questionPanels;
    public GameObject notFitPanel;
    public GameObject breakPanel;
    public GameObject CongratulationsPanel;
    public PlayerNeedsManager needsManager;
    public Slider progressSlider; 
    private int currentQuestionIndex = 0;
    public UIManager uiManager;

    void Start()
    {
        InitializeQuestions();
        needsManager.ResetNeeds(); //ensure all needs must be met before starting
    }

    public void Update()
    {
        if (progressSlider.value >= progressSlider.maxValue)
        {
            ShowCongratulationsPanel();
        }
    }

    void InitializeQuestions()
    {
        //hide all panels
        foreach (GameObject panel in questionPanels)
        {
            panel.SetActive(false);
        }
    }

    public void BeginTasks()
    {
        if (needsManager.hasEaten && needsManager.hasSlept && needsManager.hasShowered)
        {
            questionPanels[currentQuestionIndex].SetActive(true);
            
        }
        else
        {
            notFitPanel.SetActive(true);
            Debug.Log("fulfill a need to continue.");
        }
    }

    public void AnswerQuestion(bool isCorrect)
    {
        questionPanels[currentQuestionIndex].SetActive(false);
        if (isCorrect)
        {
            progressSlider.value += 1; // Increase progress
            needsManager.CompleteTask(isCorrect); 
            currentQuestionIndex++;
            

            if (currentQuestionIndex >= questionPanels.Count)
            {
                Debug.Log("Congratulations");
                
            }
            else
            {
                //check if break is needed
                if (needsManager.hasEaten && needsManager.hasSlept && needsManager.hasShowered)
                {
                    questionPanels[currentQuestionIndex].SetActive(true);
                }
                else
                {
                    breakPanel.SetActive(true); //show take a break panel

                }
            }
        }
        else
        {
            needsManager.RequestRandomBreak();
            notFitPanel.SetActive(true); //call not fit to work panel when user fails
        }
    }
public void HIdeNotFitPanel()
    {
        notFitPanel.SetActive(false);
        uiManager.HideInteractionPanel();
    }

    public void HIdeBreakPanel()
    {
        breakPanel.SetActive(false);
        uiManager.HideInteractionPanel();
    }

    public void ShowCongratulationsPanel()
    {
        CongratulationsPanel.SetActive(true);
    }

     public void RestartGame()
    {
        SceneManager.LoadScene("life");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
