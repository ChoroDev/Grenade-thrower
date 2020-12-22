using System.Collections.Generic;
using UnityEngine;

public class BasePhysics : MonoBehaviour
{
    #region Fields

    [SerializeField] protected GameObject baseObject;
    [SerializeField] protected Rigidbody2D objectRig;

    protected Collider2D objectCollider;

    #endregion


    #region Properties

    public List<Collider2D> GroundColliders { get; set; }

    public bool IsObjectGrounded { get { return GroundColliders.Count > 0; } }

    #endregion


    #region Unity lifecycle


    void OnEnable()
    {
        GroundColliders = new List<Collider2D>();
        objectCollider = GetComponent<Collider2D>();
        objectRig = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D actualCollidedObstacle)
    {
        GroundCheck(actualCollidedObstacle);
    }


    void OnCollisionExit2D(Collision2D abandonedPlatform)
    {
        if (GroundColliders.Contains(abandonedPlatform.collider))
        {
            GroundColliders.Remove(abandonedPlatform.collider);
        }
    }


    void OnDisable()
    {
        if (GroundColliders != null)
        {
            GroundColliders = null;
        }
    }

    #endregion


    #region Private methods

    private void GroundCheck(Collision2D actualCollidedObstacle)
    {
        Collider2D actualObstacleCollider = actualCollidedObstacle.collider;
        bool isGround = GroundColliders.Contains(actualObstacleCollider);
        if (!isGround)
        {
            CheckForTheObstacleHeightRealtiveToThePlayer(actualCollidedObstacle);
        }
    }


    private void CheckForTheObstacleHeightRealtiveToThePlayer(Collision2D actualCollidedObstacle)
    {
        foreach (var obstacleColliderContact in actualCollidedObstacle.contacts)
        {
            float obstacleTop = obstacleColliderContact.point.y;
            float playerBottom = objectCollider.bounds.min.y;
            if (obstacleTop < playerBottom)
            {
                GroundColliders.Add(actualCollidedObstacle.collider);
                break;
            }
        }
    }

    #endregion
}
