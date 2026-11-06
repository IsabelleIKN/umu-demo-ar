# Android AR demos (AR Foundation + ARCore)

These demos run on an Android phone or tablet. Google's ARCore follows how the device moves and finds flat surfaces and printed images in the camera image, so 3D objects can stay in place in the room. Everything runs on the device: no images are stored or sent anywhere.

Back to the [main README](../../README.md). The webcam and Kinect demos are in [umu-demo](https://github.com/IsabelleIKN/umu-demo).

## 1. What you need

- **An Android phone or tablet that supports ARCore**, running **Android 10 or newer**. Check Google's [list of supported devices](https://developers.google.com/ar/devices). Most mid-range and better phones from the last few years are on it; many cheap tablets aren't.
- **A USB cable that carries data**, not just power. Some cables that come with chargers only charge.
- For `AR_ImageMarker`: a printer, to print the marker.

No device? You can still try and change the demos in the Unity editor with XR Simulation (section 4). You only need a device to see how AR behaves in a real room.

## 2. Installing

**On the computer:** Unity's Android Build Support module (see the main README). Nothing else.

**On the device:**

1. Turn on developer options: *Settings* → *About phone* → tap **Build number** seven times. (On some devices it's under *Software information*.)
2. In *Settings* → *System* → *Developer options*, turn on **USB debugging**.
3. Connect the device to the computer. A prompt "Allow USB debugging?" appears on the device: tap **Allow** (and tick *Always allow from this computer*).
4. Install or update **Google Play Services for AR** from the Play Store.

## 3. Check the device works outside Unity

Look up **Google Play Services for AR** in the Play Store on the device. If it offers *Install*, *Update* or *Open*, the device supports AR. If the Play Store says the device isn't compatible, it can't run these demos.

## 4. Running a demo

### In the editor, with XR Simulation (no device needed)

Pressing Play in the editor doesn't use your webcam. It puts you in a **simulated room** instead, and AR Foundation finds its floor, walls and table as if a phone were scanning a real room. The same scripts run unchanged, so this is the quickest way to try a change.

1. Open a demo scene and press Play.
2. Click in the Game view. **Hold the right mouse button** and move the mouse to look around. While holding it, use **W A S D** to walk, **Q** and **E** to go down and up, and **Shift** to go faster.
3. **Keep moving:** just like on a phone, surfaces are only found while the camera moves. Look around the room slowly for a few seconds.

The standard room is a plain grey space with a table and a picture that can serve as an image marker. For more realistic rooms, open the **XR Environment** toolbar in the Scene view and choose *Install sample environments*. (Toolbar not visible? Hover over the Scene view, press the **`** key and tick *XR Environment*.)

The simulation is generous: real cameras struggle with plain surfaces, glare and dim light, and the simulated one doesn't. **Always test on a real device before the museum.**

### On a device

Build an app and install it on the device:

1. Connect the device with USB debugging on (section 2).
2. Open *File* → *Build Profiles* → *Android*. In the **Scene List**, make sure the demo scene you want is ticked and at the top.
3. Under **Run Device**, pick your device. Not listed? Click *Refresh*.
4. Click **Build And Run** and choose the `Builds` folder as the place for the app (that folder is git-ignored).

**The first build takes long:** about 25–30 minutes on our test laptop. Unity converts all the code to native Android code once (that's what IL2CPP does). Later builds are much faster.

When the app starts, it asks for camera permission: allow it. Move the device slowly and point it at the floor or a table; after a few seconds ARCore finds surfaces.

## 5. How the code works

*Written together with the demos.*

## 6. Common problems

| Problem | What to try |
|---|---|
| Build fails with errors about the Android SDK, NDK or JDK | The Android module or its *OpenJDK* / *Android SDK & NDK Tools* parts are missing. Add them in Unity Hub (main README, step 1). |
| The device doesn't appear under *Run Device* | USB debugging must be on, and you must have tapped *Allow* on the device. Try another cable (a data cable) or another USB port, then click *Refresh*. |
| The app shows a black screen where the camera image should be | The camera permission was denied: allow it in the device's app settings. In your own project, check that the Android renderer has the **AR Background Renderer Feature** (main README, "What's already set up"). |
| The app says AR is unsupported, or asks to install something | Install or update **Google Play Services for AR**, and check the device is on Google's list. |
| In the editor, "Surfaces found" stays at 0 | Move the simulated camera (hold the right mouse button and look around, section 4). Surfaces are only found while the camera moves. |
| No surfaces are found on the device | ARCore needs texture and light. A plain white table, a glass surface or a dark room gives it nothing to recognise. Move slowly, aim at a surface with some pattern, and turn on the lights. |

## 7. Tips for the museum

- **Light and texture:** AR works best in an evenly lit room, on floors and tables with some visible pattern. Shiny, plain and very dark surfaces are hard for ARCore.
- **Print markers on matte paper.** Glossy paper reflects the lights and the marker disappears in the glare. Put the marker where visitors can stand back from it a little, so it fits in the camera image.
- **Lock the device to your app.** Android's *app pinning* (in *Settings* → *Security*, sometimes called *screen pinning*) stops visitors leaving the app.
- **Plan for batteries and handling:** AR uses a lot of power, so keep devices charging between uses. Tablets are heavy for small children, so a strap or a stand helps.
- **Privacy:** the camera image is processed on the device and nothing is recorded. Say so on a sign.

## 8. Ideas for taking it further

*Written together with the demos.*
