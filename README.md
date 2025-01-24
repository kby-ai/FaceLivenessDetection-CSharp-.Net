<p align="center">
  <a href="https://play.google.com/store/apps/dev?id=7086930298279250852" target="_blank">
    <img alt="" src="https://github-production-user-asset-6210df.s3.amazonaws.com/125717930/246971879-8ce757c3-90dc-438d-807f-3f3d29ddc064.png" width=500/>
  </a>  
</p>

### Our facial recognition algorithm is globally top-ranked by NIST in the FRVT 1:1 leaderboards.<span> <img src="https://github.com/kby-ai/.github/assets/125717930/bcf351c5-8b7a-496e-a8f9-c236eb8ad59e" style="margin: 4px; width: 36px; height: 20px"> <span/> </br> ([Latest NIST frvt evaluation report 2024-12-20](https://pages.nist.gov/frvt/html/frvt11.html)) </br>
![frvt-sheet](https://github.com/user-attachments/assets/16b4cee2-3a91-453f-94e0-9e81262393d7) 

#### 🆔 ID Document Liveness Detection - Linux - [Here](https://web.kby-ai.com) <span> <img src="https://github.com/kby-ai/.github/assets/125717930/bcf351c5-8b7a-496e-a8f9-c236eb8ad59e" style="margin: 4px; width: 36px; height: 20px"> <span/>
#### 🤗 Hugging Face - [Here](https://huggingface.co/kby-ai)
#### 📚 Product & Resources - [Here](https://github.com/kby-ai/Product)
#### 🛟 Help Center - [Here](https://docs.kby-ai.com)
#### 💼 KYC Verification Demo - [Here](https://github.com/kby-ai/KYC-Verification-Demo-Android)
#### 🙋‍♀️ Docker Hub - [Here](https://hub.docker.com/r/kbyai/face-recognition)

# FaceLivenessDetection-C#

## Overview
This repo is the `Face Liveness Detection` project for `Windows C#`.

> In this repo, we integrated `KBY-AI`'s `Face Liveness Detection` solution into `Windows Server SDK`.<br/>
> We can customize the SDK to align with your specific requirements.

### ◾FaceSDK(Server) Details
  | 🔽 Face Liveness Detection      | Face Recognition |
  |------------------|------------------|
  | <b>Face Detection</b>        | Face Detection    |
  | <b>Face Liveness Detection</b>        | Face Recognition(Face Matching or Face Comparison)    |
  | <b>Pose Estimation</b>        | Pose Estimation    |
  | <b>68 points Face Landmark Detection</b>        | 68 points Face Landmark Detection    |
  | <b>Face Quality Calculation</b>        | Face Occlusion Detection        |
  | <b>Face Occlusion Detection</b>        | Face Occlusion Detection        |
  | <b>Eye Closure Detection</b>        | Eye Closure Detection       |
  | <b>Mouth Opening Check</b>        | Mouth Opening Check        |

### ◾FaceSDK(Server) Product List
  | No.      | Repository | SDK Details |
  |------------------|------------------|------------------|
  | 1        | [Face Liveness Detection - Linux](https://github.com/kby-ai/FaceLivenessDetection-Docker)    | Face Livness Detection |
  | 2        | [Face Liveness Detection - Windows](https://github.com/kby-ai/FaceLivenessDetection-Windows)    | Face Livness Detection |
  | ➡️        | <b>[Face Liveness Detection - C#](https://github.com/kby-ai/FaceLivenessDetection-CSharp-.Net)</b>    | <b>Face Livness Detection</b> |
  | 4        | [Face Recognition - Linux](https://github.com/kby-ai/FaceRecognition-Docker)    | Face Recognition |
  | 5        | [Face Recognition - Windows](https://github.com/kby-ai/FaceRecognition-Windows)    | Face Recognition |
  | 6        | [Face Recognition - C#](https://github.com/kby-ai/FaceRecognition-CSharp-.NET)    | Face Recognition |

> To get `Face SDK(mobile)`, please visit products [here](https://github.com/kby-ai/Product):<br/>


## Screenshots

<p float="left">
  <img src="https://github.com/user-attachments/assets/ca07c133-76f2-4bf8-b14b-4820c5bf25f3" width=400/>
</p>

## SDK License

This project uses `KBY-AI`'s `Face Liveness Detection Server SDK`, which requires a license per machine.

- To request the license, please provide us with the `machine code` obtained from the `getMachineCode` function.

- Ensure you copy the `license.txt` file to the `bin\Debug\net8.0-windows` folder, as shown in the image below:
![image](https://github.com/user-attachments/assets/fc1fe601-9038-4932-b177-9e2442f67415)

#### Please contact us:
🧙`Email:` contact@kby-ai.com</br>
🧙`Telegram:` [@kbyai](https://t.me/kbyai)</br>
🧙`WhatsApp:` [+19092802609](https://wa.me/+19092802609)</br>
🧙`Skype:` [live:.cid.66e2522354b1049b](https://join.skype.com/invite/OffY2r1NUFev)</br>
🧙`Discord:` [KBY-AI](https://discord.gg/CgHtWQ3k9T)</br>

## About SDK

### 1. Initializing the SDK

- Step One

  First, obtain the `machine code` for activation and request a license based on the `machine code`.
  ```c#
  textBoxMachineCode.Text = LiveSDK.GetMachineCode();
  ```
  
- Step Two

  Next, activate the SDK using the received license.
  ```c#
  int ret = LiveSDK.SetActivation(license);
  ```  
  If activation is successful, the return value will be `SDK_SUCCESS`. Otherwise, an error value will be returned.

- Step Three

  After activation, call the initialization function of the SDK.
  ```c#
  ret = LiveSDK.InitSDK("model1");
  ```
  The first parameter is the path to the model.

  If initialization is successful, the return value will be `SDK_SUCCESS`. Otherwise, an error value will be returned.

### 2. Enum and Structure
  - SDK_ERROR
  
    This enumeration represents the return value of the `initSDK` and `setActivation` functions.

    | Feature| Value | Name |
    |------------------|------------------|------------------|
    | Successful activation or initialization        | 0    | SDK_SUCCESS |
    | License key error        | -1    | SDK_LICENSE_KEY_ERROR |
    | AppID error (Not used in Server SDK)       | -2    | SDK_LICENSE_APPID_ERROR |
    | License expiration        | -3    | SDK_LICENSE_EXPIRED |
    | Not activated      | -4    | SDK_NO_ACTIVATED |
    | Failed to initialize SDK       | -5    | SDK_INIT_ERROR |

- FaceBox
  
    This structure represents the output of the face detection function.

    | Feature| Type | Name |
    |------------------|------------------|------------------|
    | Face rectangle        | int    | x1, y1, x2, y2 |
    | Face liveness score (0 ~ 1)        | float    | liveness |
    | Face angles (-45 ~ 45)        | float    | yaw, roll, pitch |
    | Face quality (0 ~ 1)        | float    | face_quality |
    | Face luminance (0 ~ 255)       | float    | face_luminance |
    | Eye distance (pixels)       | float    | eye_dist |
    | Eye closure (0 ~ 1)       | float    | left_eye_closed, right_eye_closed |
    | Face occlusion (0 ~ 1)       | float    | face_occlusion |
    | Mouth opening (0 ~ 1)       | float    | mouth_opened |
    | 68 points facial landmark        | float [68 * 2]    | landmarks_68 |
  
    > 68 points facial landmark
    
    <img src="https://user-images.githubusercontent.com/125717930/235560305-ee1b6a39-5dab-4832-a214-732c379cabfd.png" width=500/>

### 3. APIs
  Please refer to `LiveSDK.cs`, where all APIs are implemented.
  - Face Detection
  
    The `Face SDK` provides a single API for detecting faces, getting `liveness score`, determining `face orientation` (yaw, roll, pitch), assessing `face quality`, detecting `facial occlusion`, `eye closure`, `mouth opening`, and identifying `facial landmarks`.
    
    The function can be used as follows:

    ```c#
    FaceBox[] faceBoxes = new FaceBox[10];
    int faceCount = LiveSDK.FaceDetection(pixels, imgBmp.Width, imgBmp.Height, faceBoxes, 10);
    ```
    
    This function requires 5 parameters.
    * The first parameter: the byte array of the RGB image buffer.
    * The second parameter: the width of the image.
    * The third parameter: the height of the image.
    * The fourth parameter: the `FaceBox` array allocated with `maxFaceCount` for storing the detected faces.
    * The fifth parameter: the count allocated for the maximum `FaceBox` objects.

    The function returns the count of the detected face.

### 4. Thresholds
  The default liveness threshold is `0.6`.

