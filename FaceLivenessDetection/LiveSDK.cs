using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace KBYAILive
{
    enum SDK_ERROR
    {
        SDK_SUCCESS = 0,
        SDK_LICENSE_KEY_ERROR = -1,
        SDK_LICENSE_APPID_ERROR = -2,
        SDK_LICENSE_EXPIRED = -3,
        SDK_NO_ACTIVATED = -4,
        SDK_INIT_ERROR = -5,
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct FaceBox
    {
        public int x1, y1, x2, y2;

        public float liveness;

        public float yaw, roll, pitch;
        public float face_quality, face_luminance, eye_dist;

        public float left_eye_closed, right_eye_closed, face_occlusion, mouth_opened;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68 * 2)]
        public float[] landmark_68; // Array of 136 floats

        public FaceBox(int n)
        {
            x1 = x2 = y1 = y2 = 0;
            yaw = roll = pitch = 0;
            face_quality = face_luminance = eye_dist = 0;
            left_eye_closed = right_eye_closed = face_occlusion = mouth_opened = 0;
            landmark_68 = new float[68 * 2];
        }
    };

    class LiveSDK
    {
        [DllImport("kbyai_facesdk1.dll")]

        public static extern IntPtr kbyai_live_getMachineCode();

        public static String GetMachineCode()
        {
            try
            {
                IntPtr machineCode = kbyai_live_getMachineCode();
                if (machineCode == null)
                    throw new Exception("Failed to retrieve machine code.");

                string strMachineCode = Marshal.PtrToStringAnsi(machineCode);
                return strMachineCode;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [DllImport("kbyai_facesdk1.dll")]
        public static extern int kbyai_live_setActivation(IntPtr license);

        public static int SetActivation(String license)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(license);

            try
            {
                return kbyai_live_setActivation(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);                
            }
        }

        [DllImport("kbyai_facesdk1.dll")]
        public static extern int kbyai_live_initSDK(IntPtr modelPath);

        public static int InitSDK(String modelPath)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(modelPath);

            try
            {
                return kbyai_live_initSDK(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);
            }
        }

        [DllImport("kbyai_facesdk1.dll")]
        public static extern int kbyai_live_faceDetection(
            IntPtr rgbData, // Pointer to the RGB data
            int width,      // Width of the image
            int height,     // Height of the image
            [In, Out] FaceBox[] faceBoxes, // Array of FaceBox
            int faceBoxCount // Number of face boxes
        );

        public static int FaceDetection(byte[] rgbData, int width, int height, [In, Out] FaceBox[] faceBoxes, int faceBoxCount)
        {
            IntPtr imgPtr = Marshal.AllocHGlobal(rgbData.Length);
            Marshal.Copy(rgbData, 0, imgPtr, rgbData.Length);

            try
            {
                int ret = kbyai_live_faceDetection(imgPtr, width, height, faceBoxes, faceBoxCount);
                return ret;
            }
            finally
            {
                Marshal.FreeHGlobal(imgPtr);
            }
        }
    }
}
