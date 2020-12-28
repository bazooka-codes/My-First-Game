using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables exposed to inspector
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody player;
    [SerializeField] private float forwardVelocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sidewaysForce;
    [SerializeField] private float verticalForce;
    
    //Private variables
    private bool jumpKey = false;
    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameInFreeztime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                player.AddForce(forwardVelocity, 0, 0, ForceMode.Acceleration);
                gameManager.EndFreeztime();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager gm = gameManager;

                if (!gm.gameIsPaused)
                {
                    gm.PauseGame();
                }
                else if (gm.gameIsPaused)
                {
                    gm.UnpauseGame();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpKey = true;
            }

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        if(jumpKey && GetComponent<PlayerCollision>().isGrounded)
        {
            player.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            jumpKey = false;
        }

        player.AddForce(0, 0, -1 * horizontalInput * sidewaysForce * Time.deltaTime, ForceMode.Acceleration);

        player.AddForce(verticalInput * verticalForce * Time.deltaTime, 0, 0, ForceMode.Acceleration);

        if(player.position.y < -20 && !gameManager.gameIsOver)
        {
            gameManager.GameOver("Fell off the map.");
        }

        if(player.velocity.x < 0 && !gameManager.gameIsOver && !gameManager.gameInFreeztime)
        {
            gameManager.GameOver("Lost too much speed.");
        }
    }
}
