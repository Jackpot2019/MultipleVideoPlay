using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoStream : MonoBehaviour
{
    //Raw Image to Show Video Images [Assign from the Editor]
    public VideoPlayer videoPlayer;
    public RawImage image;

    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    private void Update()
    {
    }

    IEnumerator playVideo()
    {
        videoPlayer.Prepare();

        //Wait until video is prepared
        Debug.Log("Preparing Video");
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");        //Assign the Texture from Video to RawImage to be displayed

        image.texture = videoPlayer.texture;
        //Play Video
        videoPlayer.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        Debug.Log("Done Playing Video");
    }

    public void OnMute(bool mute)
    {
        videoPlayer.SetDirectAudioMute(0, mute);
    }
}
