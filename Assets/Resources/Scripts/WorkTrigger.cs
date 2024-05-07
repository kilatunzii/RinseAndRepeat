using UnityEngine;

public class WorkTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowWorkingPanel();
            UIManager.Instance.PauseGame(true);
        }
    }
}