using System.Collections;
using System.Collections.Generic;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using UnityEngine.UI;

public class VRSwitch : MonoBehaviour
{
  private const float _defaultFieldOfView = 60.0f;

    // Main camera from the scene.
    private Camera _mainCamera;
    
    public Button vrButton; // Tombol UI untuk mengaktifkan VR

    /// <summary>
    /// Gets a value indicating whether the VR mode is enabled.
    /// </summary>
    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }
    public GameObject cameraParent;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // Saves the main camera from the scene.
        _mainCamera = Camera.main;

        // Configures the app to not shut down the screen and sets the brightness to maximum.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }

        vrButton.onClick.AddListener(EnterVR);

        _mainCamera = Camera.main;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
        vrButton.onClick.AddListener(EnterVR);
        
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        if (_isVrModeEnabled)
        {
            if (Api.IsCloseButtonPressed)
            {
                ExitVR();
            }

            if (Api.IsGearButtonPressed)
            {
                Api.ScanDeviceParams();
            }

            Api.UpdateScreenParams();
        }
        else // New: If VR mode is off, handle touch inputs for camera movement
        {
        if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                     Vector3 touchDeltaPosition = touch.deltaPosition;

                    // Rotate around the Y-axis based on the horizontal movement
                    cameraParent.transform.Rotate(0, -touchDeltaPosition.x * Time.deltaTime, 0, Space.World);

                    // Rotate around the X-axis based on the vertical movement
                    cameraParent.transform.Rotate(touchDeltaPosition.y * Time.deltaTime, 0, 0, Space.Self);
                }
            }
        }
    }

    /// <summary>
    /// Enters VR mode.
    /// </summary>
    private void EnterVR()
    {
        StartCoroutine(StartXR());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    /// <summary>
    /// Exits VR mode.
    /// </summary>
    private void ExitVR()
    {
        StopXR();
    }

    /// <summary>
    /// Initializes and starts the Cardboard XR plugin.
    /// </summary>
    ///
    /// <returns>
    /// Returns result value of <c>InitializeLoader</c> method from the XR General Settings Manager.
    /// </returns>
    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    /// <summary>
    /// Stops and deinitializes the Cardboard XR plugin.
    /// </summary>
    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");

        _mainCamera.ResetAspect();
        _mainCamera.fieldOfView = _defaultFieldOfView;
    }
}

