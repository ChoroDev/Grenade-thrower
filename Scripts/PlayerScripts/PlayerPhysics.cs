using UnityEngine;

public class PlayerPhysics : BasePhysics
{
    #region Constants

    private const float JUMP_FORCE = 150.0f;

    private const float MOVE_FORCE = 200.0f;

    #endregion


    #region Public methods

    public void Jump()
    {
        objectRig.AddForce(Vector2.up * JUMP_FORCE);
    }


    public void Move(float horizontalVelocity)
    {
        objectRig.AddForce(Vector2.right * horizontalVelocity * MOVE_FORCE);
    }

    #endregion
}
