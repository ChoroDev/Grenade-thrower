using UnityEngine;
using Cinemachine;

public class CameraManager : BaseManager<CameraManager>
{
    #region Fields

    [SerializeField] CinemachineVirtualCamera objectCaptureCamera;

    CinemachineVirtualCamera activeCaptureCamera;
    
    Vector3 dragOrigin;

    bool canCameraDrag;

    private Vector3 cameraStartPosition;
    private Vector3 origin;
    private Vector3 diference;
    private bool drag = false;

    #endregion


    #region Unity lifecycle

    void OnEnable()
    {
        GameStateMachine.Instance.OnGameStateChanged += ManageCamera;
        //PlayerManager.Instance.OnPlayerCreated += ActivateCameraCapture;
    }


    void Start()
    {
        cameraStartPosition = Camera.main.transform.position;
    }


    void LateUpdate()
    {
        if (activeCaptureCamera != null && canCameraDrag)
        {
            CameraDrag();
        }
    }


    void OnDisable()
    {
        if (GameStateMachine.Instance != null)
        {
            GameStateMachine.Instance.OnGameStateChanged -= ManageCamera;
        }
        //if (PlayerManager.Instance != null)
        //{
        //    PlayerManager.Instance.OnPlayerCreated -= ActivateCameraCapture;
        //}
    }

    #endregion


    #region Private methods

    void ManageCamera(GameState newGameState)
    {
        DeactivateCameraDrag();
        switch (newGameState)
        {
            case GameState.OnMenu:

                DeactivateCamera();

                break;

            case GameState.OnGame:

                ActivateCameraDrag();

                break;
        }
    }


    void ActivateCamera()
    {
        if (activeCaptureCamera == null)
        {
            activeCaptureCamera = Instantiate(objectCaptureCamera);
        }
        else
        {
            activeCaptureCamera.gameObject.SetActive(true);
        }
    }


    void DeactivateCamera()
    {
        if (activeCaptureCamera != null)
        {
            activeCaptureCamera.gameObject.SetActive(false);
        }
    }


    void ActivateCameraDrag()
    {
        ActivateCamera();
        canCameraDrag = true;
    }


    void CameraDrag()
    {
        if (Input.GetMouseButton(0))
        {
            diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.transform.position;
            if (drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if (drag == true)
        {
            activeCaptureCamera.transform.position = origin - diference;
        }

        if (Input.GetMouseButton(1))
        {
            activeCaptureCamera.transform.position = cameraStartPosition;
        }
    }


    void DeactivateCameraDrag()
    {
        canCameraDrag = false;
        DeactivateCamera();
    }


    void ActivateCameraCapture(PlayerController activePlayerInstance)
    {
        ActivateCamera();
        activeCaptureCamera.Follow = activePlayerInstance.gameObject.transform;
        activeCaptureCamera.m_Lens.OrthographicSize = 5.0f;
    }

    #endregion
}
