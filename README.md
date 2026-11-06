# umu-demo-ar: Android AR demos for Unity

Small Unity demos showing augmented reality (AR) for a museum, on an Android phone or tablet: a 3D object that appears on a printed image, and an object you place on the floor or a table. They use Unity's **AR Foundation** with Google's **ARCore**.

Each demo is one scene with short scripts you can read in one sitting. Replace the interaction with your own idea.

The webcam and Kinect demos are in a separate project: **[umu-demo](https://github.com/IsabelleIKN/umu-demo)**.

> **Work in progress.** The demo scenes below are being built. For now the project holds one check scene in `Assets/Checks/`.

## The demos

| Scene | What it shows |
|---|---|
| `AR_ImageMarker` | Point the camera at a printed image; a 3D object and an info label appear on it. A printable marker is included. |
| `AR_PlaceObject` | The floor or a table is detected; tap to place an object (e.g. a statue), tap again to move it. |

Setup steps for the phone, common problems and tips for the museum are in **[Assets/Demos/README.md](Assets/Demos/README.md)**.

## Getting started

1. **Install Unity 6.3 LTS, version 6000.3.26f1**, with Unity Hub, **including the *Android Build Support* module** with its *OpenJDK* and *Android SDK & NDK Tools* parts. Already have the editor without it? In Hub, go to *Installs*, click the gear next to the editor, choose *Add modules*. If Hub doesn't offer 6000.3.26f1, get it from the [Unity download archive](https://unity.com/releases/editor/archive).
2. **Clone this repo**, with GitHub Desktop or `git clone https://github.com/IsabelleIKN/umu-demo-ar.git`.
3. **Open the project:** in Unity Hub, click *Add* → *Add project from disk* and pick the project folder. No setup script is needed for this project.
4. **Switch to Android:** *File* → *Build Profiles* → *Android* → *Switch Platform*. The first time, this takes a few minutes.
5. Follow [Assets/Demos/README.md](Assets/Demos/README.md) to build to your device, or to try the demos in the editor first with XR Simulation, no device needed.

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
Assets/Demos/
  README.md          phone setup, building, problems, museum tips
  ImageMarker/       the image marker demo
  PlaceObject/       the place-an-object demo
Assets/Checks/       check scene used while building the demos (will be removed)
Markers/             printable marker
```
