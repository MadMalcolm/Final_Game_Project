using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SystemViewCameraTextureScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // this script needs to be on the same object that has the image/sprite
        //Transform srt_transform = transform.parent.Find("SystemRenderTexture");
        //Debug.Log(srt_transform.name);

        //Sprite sprite = GetComponent<Image>().sprite;



        RectTransform rt = GetComponent<RectTransform>();

        SystemViewTexture = new RenderTexture((int)rt.rect.width, (int)rt.rect.height, 24 );
        SystemCamera.targetTexture = SystemViewTexture;

        //Sprite sprite = Sprite.Create();

        RawImage ri = GetComponent<RawImage>();
        ri.texture = SystemViewTexture;



    }

    RenderTexture SystemViewTexture;

    public Camera SystemCamera;


    // Update is called once per frame
    void Update()
    {
        
    }
}
