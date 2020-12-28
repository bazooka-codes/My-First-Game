using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Scoreboard scoreboard;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            gameManager.WinGame();
        }
    }
}
