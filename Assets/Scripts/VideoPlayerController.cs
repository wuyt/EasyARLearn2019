using EasyAR;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlayerController : VideoPlayerBaseBehaviour
{
    private Text txt;
    private System.EventHandler videoReayEvent;
    private System.EventHandler videoErrorEvent;
    private System.EventHandler videoReachEndEvent;

    /// <summary>
    /// 重写Awake事件
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        txt = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }

    /// <summary>
    /// 重写Start事件
    /// </summary>
    protected override void Start()
    {
        videoReayEvent = OnVideoReady;
        videoErrorEvent = OnVideoError;
        videoReachEndEvent = OnVideoReachEnd;
        base.Start();
        //添加事件订阅
        VideoReadyEvent += videoReayEvent;          //视频加载成功事件
        VideoErrorEvent += videoErrorEvent;         //视频加载失败事件
        VideoReachEndEvent += videoReachEndEvent;   //视频播放完成事件
        Open();     //开始加载视频
    }

    /// <summary>
    /// 视频加载成功事件
    /// </summary>
    void OnVideoReady(object sender, System.EventArgs e)
    {
        Debug.Log("Load video success");
        txt.text = "load video success";
    }

    /// <summary>
    /// 视频加载失败事件
    /// </summary>
    void OnVideoError(object sender, System.EventArgs e)
    {
        Debug.Log("Load video error");
        txt.text = "load video error";
    }

    /// <summary>
    /// 视频播放完成事件
    /// </summary>
    void OnVideoReachEnd(object sender, System.EventArgs e)
    {
        Debug.Log("video reach end");
        txt.text = "video reach end";
    }

    /// <summary>
    /// 重写OnDestory事件
    /// </summary>
    protected override void OnDestroy()
    {
        VideoReadyEvent -= videoReayEvent;
        VideoErrorEvent -= videoErrorEvent;
        VideoReachEndEvent -= videoReachEndEvent;
        Close();
        base.OnDestroy();
    }

    /// <summary>
    /// 视频播放
    /// </summary>
    public void VideoPlay()
    {
        Play();
    }

    /// <summary>
    /// 视频停止
    /// </summary>
    public void VideoStop()
    {
        Stop();
    }
    
    /// <summary>
    /// 视频暂停
    /// </summary>
    public void VideoPause()
    {
        Pause();
    }
}
