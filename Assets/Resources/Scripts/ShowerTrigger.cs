using UnityEngine;

public class ShowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ShowShoweringPanel();
            UIManager.Instance.PauseGame(true);
        }
    }
}
