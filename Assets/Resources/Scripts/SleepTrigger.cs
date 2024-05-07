using UnityEngine;

public class SleepTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowSleepingPanel();
            UIManager.Instance.PauseGame(true);
        }
    }

}
