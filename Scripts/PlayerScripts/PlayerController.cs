using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Constants
    
    private const float PLAYER_SPEED_SCALER = 20.0f;

    #endregion


    #region Fields

    [SerializeField] PlayerPhysics playerPhysics;

    #endregion


    #region Unity lifecycle

    void FixedUpdate()
    {
        float horizontalVelocity = Input.GetAxis("Horizontal") / PLAYER_SPEED_SCALER;
        playerPhysics.Move(horizontalVelocity);
        if (Input.GetKey(KeyCode.UpArrow) && playerPhysics.IsObjectGrounded)
        {
            playerPhysics.Jump();
        }
    }


    #endregion


    //#region Private methods

    //private void MovePlayer(float horizontalVelocity)
    //{
    //    //transform.Translate(horizontalVelocity, 0.0f, 0.0f);
    //}

    //#endregion
}
