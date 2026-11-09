# Android AR (AR Foundation + ARCore)

This project runs on an Android phone or tablet. Google's ARCore follows how the device moves and finds flat surfaces and images in the camera image, so 3D objects can stay in place in the room. Everything runs on the device: no images are stored or sent anywhere.

Back to the [main README](../../README.md). The webcam and Kinect starter project is [umu-demo](https://github.com/IsabelleIKN/umu-demo).

## 1. What you need

- **Nothing extra to start:** you can try and change everything in the Unity editor with XR Simulation (section 4).
- **To see how AR behaves in a real room:** an Android phone or tablet that supports ARCore, running **Android 10 or newer**. Check Google's [list of supported devices](https://developers.google.com/ar/devices). Most mid-range and better phones from the last few years are on it; many cheap tablets aren't.
- **A USB cable that carries data**, not just power. Some cables that come with chargers only charge.

## 2. Installing on the device

**On the computer:** Unity's Android Build Support module (see the main README). Nothing else.

**On the device:**

1. Turn on developer options: *Settings* → *About phone* → tap **Build number** seven times. (On some devices it's under *Software information*.)
2. In *Settings* → *System* → *Developer options*, turn on **USB debugging**.
3. Connect the device to the computer. A prompt "Allow USB debugging?" appears on the device: tap **Allow** (and tick *Always allow from this computer*).
4. Install or update **Google Play Services for AR** from the Play Store.

## 3. Check the device works outside Unity

Look up **Google Play Services for AR** in the Play Store on the device. If it offers *Install*, *Update* or *Open*, the device supports AR. If the Play Store says the device isn't compatible, it can't run AR apps.

## 4. Running the scene

### In the editor, with XR Simulation (no device needed)

Pressing Play in the editor doesn't use your webcam. It puts you in a **simulated room** instead, and AR Foundation finds its floor, walls and table as if a phone were scanning a real room. The same scripts run unchanged, so this is the quickest way to try a change.

1. Open `Assets/Checks/ARCheck.unity` and press Play.
2. Click in the Game view. **Hold the right mouse button** and move the mouse to look around. While holding it, use **W A S D** to walk, **Q** and **E** to go down and up, and **Shift** to go faster. A left click works as a tap.
3. **Keep moving:** just like on a phone, surfaces are only found while the camera moves. Look around the room slowly for a few seconds.

The standard room is a plain grey space with a table and a picture on the wall that works as an image marker (section 5). For more realistic rooms, open the **XR Environment** toolbar in the Scene view and choose *Install sample environments*. (Toolbar not visible? Hover over the Scene view, press the **`** key and tick *XR Environment*.)

The simulation is generous: real cameras struggle with plain surfaces, glare and dim light, and the simulated one doesn't. **Always test on a real device before the museum.**

### On a device

Build an app and install it on the device:

1. Connect the device with USB debugging on (section 2).
2. Open *File* → *Build Profiles* → *Android*. In the **Scene List**, make sure the scene you want is ticked and at the top.
3. Under **Run Device**, pick your device. Not listed? Click *Refresh*.
4. Click **Build And Run** and choose the `Builds` folder as the place for the app (that folder is git-ignored).

**The first build takes long:** about 25–30 minutes on our test laptop. Unity converts all the code to native Android code once (that's what IL2CPP does). Later builds are much faster.

When the app starts, it asks for camera permission: allow it. Move the device slowly and point it at the floor or a table; after a few seconds ARCore finds surfaces.

## 5. How the code works

Every AR scene has two parts:

- **AR Session** turns AR on and keeps track of whether it works. `ARSession.state` goes from `CheckingAvailability` to `SessionInitializing` to `SessionTracking`. `Unsupported` or `NeedsInstall` means the device lacks Google Play Services for AR.
- **XR Origin** is the device in your scene, with the camera inside it. It carries the *managers*: components that each look for one kind of thing in the room. Everything they find (a surface, an image) is a *trackable*.

`ARCheck` uses one manager, the **AR Plane Manager**, which finds surfaces and draws each one with its **Plane Prefab**. `ARCheck.cs` only shows the session state and counts the surfaces.

To go further, add more managers to the XR Origin:

- **Tap to place an object:** add an **AR Raycast Manager**. `Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon)` shoots a ray from a point on the screen into the room and tells you where it hits a surface. Read the tap with the Input System's `Pointer.current`, which works for both a mouse click in the editor and a touch on the device.
- **Recognise an image:** create a **Reference Image Library** (*Assets* → *Create* → *XR* → *Reference Image Library*), add your images with their real size in metres, and add an **AR Tracked Image Manager** with that library in **Serialized Library**. The manager turns itself off if the library is empty. Put an object in **Tracked Image Prefab** to show it on every image it finds, or listen to the manager's `trackablesChanged` event.
  - **On a device, ARCore only recognises images in your library.** The simulation also finds its own picture on the wall when it isn't in your library.
  - **Your own image in the simulation:** in the XR Environment toolbar, choose *Duplicate environment*. In your copy, select **Simulated Tracked Image**, set **Image** to the same texture file as in your library, and set its size. Save, choose *Assets* → *Refresh XR Environment List*, and pick your environment.

## 6. Common problems

| Problem | What to try |
|---|---|
| Hub or Unity warns that Android support is missing | Fine for the editor simulation. To build to a device, add the Android module (main README, step 1). |
| Build fails with errors about the Android SDK, NDK or JDK | The Android module or its *OpenJDK* / *Android SDK & NDK Tools* parts are missing. Add them in Unity Hub (main README, step 1). |
| The device doesn't appear under *Run Device* | USB debugging must be on, and you must have tapped *Allow* on the device. Try another cable (a data cable) or another USB port, then click *Refresh*. |
| The app shows a black screen where the camera image should be | The camera permission was denied: allow it in the device's app settings. In your own project, check that the Android renderer has the **AR Background Renderer Feature** (main README, "What's already set up"). |
| The app says AR is unsupported, or asks to install something | Install or update **Google Play Services for AR**, and check the device is on Google's list. |
| In the editor, nothing happens and there's no status text | Check that XR Simulation is on: *Edit* → *Project Settings* → *XR Plug-in Management*, Windows tab. |
| In the editor, "Surfaces found" stays at 0 | Move the simulated camera (hold the right mouse button and look around, section 4). Surfaces are only found while the camera moves. |
| No surfaces are found on the device | ARCore needs texture and light. A plain white table, a glass surface or a dark room gives it nothing to recognise. Move slowly, aim at a surface with some pattern, and turn on the lights. |

## 7. Tips for the museum

- **Light and texture:** AR works best in an evenly lit room, on floors and tables with some visible pattern. Shiny, plain and very dark surfaces are hard for ARCore.
- **Print images on matte paper.** Glossy paper reflects the lights and the image disappears in the glare. Choose images with lots of detail and contrast, and put them where visitors can stand back a little, so the whole image fits in the camera view.
- **Lock the device to your app.** Android's *app pinning* (in *Settings* → *Security*, sometimes called *screen pinning*) stops visitors leaving the app.
- **Plan for batteries and handling:** AR uses a lot of power, so keep devices charging between uses. Tablets are heavy for small children, so a strap or a stand helps.
- **Privacy:** the camera image is processed on the device and nothing is recorded. Say so on a sign.

## 8. Ideas for taking it further

- Tap to place an object (for example a statue from the collection) on the floor, and walk around it.
- Only allow placing on the floor, not on walls: each surface has an `alignment`.
- Recognise a printed image, such as a postcard, and bring it to life with a 3D object or animation.
- Show a different object for each image in your library.
