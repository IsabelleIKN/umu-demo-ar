using UnityEngine;
using UnityEngine.XR.ARFoundation;

// Phase 0 check: does an empty AR Foundation scene run on this Android device?
// Shows the AR session state and how many surfaces (planes) ARCore has found.
// Not a demo: the real AR_PlaceObject scene replaces this.
public class ARCheck : MonoBehaviour
{
    public ARPlaneManager planeManager;   // on the XR Origin

    void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.height / 30;   // OnGUI text is tiny on a phone otherwise

        // ARSession.state goes CheckingAvailability -> SessionInitializing -> SessionTracking.
        // "Unsupported" or "NeedsInstall" means the device lacks Google Play Services for AR.
        GUI.Label(new Rect(30, 60, Screen.width - 60, Screen.height / 4),
            $"AR session: {ARSession.state}\nSurfaces found: {planeManager.trackables.count}");
    }
}
