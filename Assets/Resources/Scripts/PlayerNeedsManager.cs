using UnityEngine;

public class PlayerNeedsManager : MonoBehaviour
{
    public static PlayerNeedsManager Instance { get; private set; }
    public TaskManager taskManager;

    public bool hasEaten = false;
    public bool hasSlept = false;
    public bool hasShowered = false;
    private int correctAnswersCount;

    public void ResetNeeds()
    {
        hasEaten = false;
        hasSlept = false;
        hasShowered = false;
    }

    public void CompleteTask(bool isCorrect)
    {
        if (isCorrect)
        {
        correctAnswersCount++;

            if (correctAnswersCount >= 2) //check after every 2 correct answer
            {
                correctAnswersCount = 0; //reset correct answers count
                RequestRandomBreak();
            }  
        }
    }

    public void RequestRandomBreak()
    {
        int random = UnityEngine.Random.Range(0, 3);
        switch (random)
        {
            case 0:
                hasEaten = false;
                break;
            case 1:
                hasSlept = false;
                break;
            case 2:
                hasShowered = false;
                break;
        }
      
    }

    public void SetEaten()
    {
        hasEaten = true;
    }

    public void SetSlept()
    {
        hasSlept = true;
    }

    public void SetShowered()
    {
        hasShowered = true;
    }
}
