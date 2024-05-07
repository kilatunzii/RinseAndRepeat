using UnityEngine;

public class EatTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowEatingPanel();
            UIManager.Instance.PauseGame(true);
        }
    }
}
