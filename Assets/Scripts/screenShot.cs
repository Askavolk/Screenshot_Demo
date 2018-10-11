using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenShot : MonoBehaviour {

    private static screenShot instance;

    private Camera myCamera;

    private bool takeTheScreenshotOnNextFrame;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        // Renders the Image 
        if (takeTheScreenshotOnNextFrame) {
            takeTheScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            // Holds our Data with transparency
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            // Array that allow us to saves the image with a name and a specific format

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/DemoCameraScreenshot.png", byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }
    // Void that allows us to take the screenshot with the image size

    private void TakeScreenshoot (int width, int height) {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeTheScreenshotOnNextFrame = true;
    }


    public static void TakeScreenshot_Static(int width, int height) {
        instance.TakeScreenshoot(width, height);
    }

}
