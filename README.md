# umu-demo-ar: Android AR starter project for Unity

A Unity project for exploring augmented reality (AR) for a museum, on an Android phone or tablet. It uses Unity's **AR Foundation** with Google's **ARCore**.

It holds one **check scene** that shows AR works and draws the surfaces it finds (floor, tables, walls). You can run it in the Unity editor without a device, in a simulated room. Build your own idea on top of it.

The webcam and Kinect starter project is separate: **[umu-demo](https://github.com/IsabelleIKN/umu-demo)**.

## What's in here

| Scene (in `Assets/Checks/`) | What it shows |
|---|---|
| `ARCheck` | The AR session's state, and the surfaces (planes) ARCore finds, drawn as you look around |

Setup steps for the device, how the code works, common problems and tips for the museum are in **[Assets/Demos/README.md](Assets/Demos/README.md)**.

## Getting started

1. **Install Unity 6.3 LTS, version 6000.3.26f1**, with Unity Hub. If Hub doesn't offer 6000.3.26f1, get it from the [Unity download archive](https://unity.com/releases/editor/archive). This is the version we tested; other Unity 6 versions may work.
   - **Only to build to a device:** also install the *Android Build Support* module with its *OpenJDK* and *Android SDK & NDK Tools* parts. Already have the editor without it? In Hub, go to *Installs*, click the gear next to the editor, choose *Add modules*. You don't need it to try the scene in the editor.
2. **Clone this repo**, with GitHub Desktop or `git clone https://github.com/IsabelleIKN/umu-demo-ar.git`. Or get it from a USB stick.
3. **Open the project:** in Unity Hub, click *Add* → *Add project from disk* and pick the project folder. No setup script is needed for this project. If Hub warns that Android support is missing, open it anyway: the editor simulation doesn't need it.
4. Open `Assets/Checks/ARCheck.unity` and press Play. You're now in a simulated room: see [Assets/Demos/README.md](Assets/Demos/README.md), section 4, for the controls.
5. **To build to a device:** *File* → *Build Profiles* → *Android* → *Switch Platform* (the first time takes a few minutes), then follow section 4 of the same README.

## What's already set up

If you start your own AR project later, these are the settings it needs. They're all done in this one:

- Packages **AR Foundation** and **Google ARCore XR Plugin**, both 6.3.5.
- *Project Settings* → *XR Plug-in Management* → Android tab: **Google ARCore** ticked.
- The same page's Windows tab: **XR Simulation** ticked, so Play mode in the editor runs in a simulated room (see [Assets/Demos/README.md](Assets/Demos/README.md)). It isn't included in the Android app.
- *Project Settings* → *Player* → Android: scripting backend **IL2CPP**, target architecture **ARM64**, minimum API level **Android 10 (API 29)**. The *Project Validation* page under XR Plug-in Management checks most of this and can fix it for you.
- The URP renderer for Android (`Assets/Settings/Mobile_Renderer.asset`) has the **AR Background Renderer Feature**. Without it the camera image stays black, and Project Validation does *not* warn you about this one.

## Project layout

```
README.md            this file
Assets/Checks/       the check scene and its script: start here
Assets/Demos/
  README.md          device setup, building, how the code works, problems, museum tips
```
