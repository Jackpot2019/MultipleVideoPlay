# MultipleVideoPlay
This is unity project that playing multiple video files.

Step by step play video
1. In the Hierarchy create UI-> Raw Image.
2. Add component VideoStream.cs in RawImage inspector .
3. Add component VideoPlayer in RawImage inspector.

VideoStream.cs code following.

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

        Debug.Log("Done Preparing Video");        

        image.texture = videoPlayer.texture;      // very important
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
