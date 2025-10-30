using KBYAILive;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FaceLivenessDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBoxMachineCode.Text = LiveSDK.GetMachineCode();

            try
            {
                string license = File.ReadAllText("license.txt");
                int ret = LiveSDK.SetActivation(license);
                if (ret == (int)SDK_ERROR.SDK_SUCCESS)
                {
                    ret = LiveSDK.InitSDK("model1");
                    if (ret == (int)SDK_ERROR.SDK_SUCCESS)
                    {
                        MessageBox.Show("Init Successful!");
                    }
                    else
                    {
                        MessageBox.Show("Init Failed!");
                    }
                }
                else
                {
                    throw new Exception("Activtaion Failure!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Activtaion Failure!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;

                Image image = null;
                try
                {
                    image = LoadImageWithExif(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unknown Format!");
                    return;
                }

                Bitmap imgBmp = ConvertTo24bpp(image);
                BitmapData bitmapData = imgBmp.LockBits(new Rectangle(0, 0, imgBmp.Width, imgBmp.Height), ImageLockMode.ReadWrite, imgBmp.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(imgBmp.PixelFormat) / 8;
                int stride = bitmapData.Stride;

                // Allocate array with width * 3 for each pixel's RGB values
                byte[] pixels = new byte[imgBmp.Width * 3 * imgBmp.Height];

                IntPtr ptrFirstPixel = bitmapData.Scan0;
                byte[] rawData = new byte[stride * imgBmp.Height];
                Marshal.Copy(ptrFirstPixel, rawData, 0, rawData.Length);

                // Copy only the RGB data, ignoring any padding
                for (int y = 0; y < imgBmp.Height; y++)
                {
                    int rawOffset = y * stride;
                    int pixelOffset = y * imgBmp.Width * 3;

                    Marshal.Copy(rawData, rawOffset, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, pixelOffset), imgBmp.Width * 3);
                }

                imgBmp.UnlockBits(bitmapData);


                FaceBox[] faceBoxes = new FaceBox[10];
                int faceCount = LiveSDK.FaceDetection(pixels, imgBmp.Width, imgBmp.Height, faceBoxes, 10);
                if (faceCount > 0)
                {
                    if (faceBoxes[0].liveness > 0.7)
                    {
                        richTextBox1.Text = "Real face! " + String.Format("Liveness Score: {0:F}", faceBoxes[0].liveness);
                    }
                    else
                    {
                        richTextBox1.Text = "Spoof face! " + String.Format("Liveness Score: {0:F}", faceBoxes[0].liveness);
                    }
                }
                else
                {
                    richTextBox1.Text = "No face!";
                }

                pictureImage.Image = image;
            }
        }

        public static Bitmap ConvertTo24bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }


        public static Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image LoadImageWithExif(String filePath)
        {
            try
            {
                Image image = Image.FromFile(filePath);

                // Check if the image has EXIF orientation data
                if (image.PropertyIdList.Contains(0x0112))
                {
                    int orientation = image.GetPropertyItem(0x0112).Value[0];

                    switch (orientation)
                    {
                        case 1:
                            // Normal
                            break;
                        case 3:
                            // Rotate 180
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            // Rotate 90
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            // Rotate 270
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            // Do nothing
                            break;
                    }
                }

                return image;
            }
            catch (Exception e)
            {
                throw new Exception("Image null!");
            }
        }

        public byte[] BitmapToJpegByteArray(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the Bitmap as JPEG to the MemoryStream
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                // Return the byte array
                return memoryStream.ToArray();
            }
        }

        public static Bitmap ConvertJpgByteArrayToBitmap(byte[] jpgData)
        {
            using (MemoryStream ms = new MemoryStream(jpgData))
            {
                return new Bitmap(ms);
            }
        }

    }
}
