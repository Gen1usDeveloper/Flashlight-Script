using UnityEngine;
using Vuforia;

public class FlashlightController : MonoBehaviour
{
    private bool isFlashlightOn = false;

    public void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;

        if (isFlashlightOn)
        {
            TurnOnFlashlight();
            Debug.Log("Flashlight turned on.");
        }
        else
        {
            TurnOffFlashlight();
            Debug.Log("Flashlight turned off.");
        }
    }

    private void TurnOnFlashlight()
    {
        // Use Vuforia's CameraDevice to control the flashlight
        if (VuforiaBehaviour.Instance.CameraDevice.SetFlash(true))
        {
            Debug.Log("Flashlight turned on using Vuforia.");
        }
        else
        {
            // Fallback to using the camera's light component
            var cam = Camera.main;

            if (cam != null)
            {
                var torch = cam.GetComponent<Light>();

                if (torch == null)
                {
                    torch = cam.gameObject.AddComponent<Light>();
                    torch.type = LightType.Directional;
                }

                torch.enabled = true;
                Debug.Log("Flashlight turned on using camera light.");
            }
        }
    }

    private void TurnOffFlashlight()
    {
        // Use Vuforia's CameraDevice to turn off the flashlight
        if (VuforiaBehaviour.Instance.CameraDevice.SetFlash(false))
        {
            Debug.Log("Flashlight turned off using Vuforia.");
        }
        else
        {
            // Fallback to using the camera's light component
            var cam = Camera.main;

            if (cam != null)
            {
                var torch = cam.GetComponent<Light>();

                if (torch != null)
                {
                    torch.enabled = false;
                    Debug.Log("Flashlight turned off using camera light.");
                }
            }
        }
    }
}