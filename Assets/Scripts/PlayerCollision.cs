using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private int collisionLimit = 1;

    public bool isGrounded = true;
    private int numColl;

    public void Start()
    {
        numColl = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Obstacle")
        {
            numColl++;
        }

        if(collision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }

        if(numColl >= collisionLimit && !FindObjectOfType<GameManager>().gameIsOver)
        {
            FindObjectOfType<GameManager>().GameOver("Too many collisions!");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isGrounded = false;
        }
    }
}
