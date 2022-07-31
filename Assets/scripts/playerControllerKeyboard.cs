using UnityEngine;

public class playerControllerKeyboard : MonoBehaviour
{
    public playerMovement playerMovement;

    private void Start()
    {
        playerMovement = playerMovement == null ? GetComponent<playerMovement>() : playerMovement;
        if (playerMovement == null)
        {
            Debug.LogError("Player not set to conroller");
        }
    }

    private void Update()
    {
        if (playerMovement != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerMovement.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerMovement.MoveLeft();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                playerMovement.Jump();
            }

        }
    }
}
