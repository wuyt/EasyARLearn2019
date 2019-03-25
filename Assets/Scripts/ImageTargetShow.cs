using EasyAR;
using UnityEngine;
using UnityEngine.UI;

public class ImageTargetShow : ImageTargetBaseBehaviour
{
    /// <summary>
    /// UI文本
    /// </summary>
    private Text uiText;

    /// <summary>
    /// 重写Awake事件
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        //订阅事件
        TargetFound += OnTargetFound;   //识别成功事件
        TargetLost += OnTargetLost;     //识别对象丢失事件
        TargetLoad += OnTargetLoad;     //目标加载事件
        TargetUnload += OnTargetUnload; //目标卸载事件

        //找到文本
        uiText = FindObjectOfType<Text>();
    }

    /// <summary>
    /// 识别成功事件处理方法
    /// </summary>
    void OnTargetFound(TargetAbstractBehaviour behaviour)
    {
        Debug.Log("Found: " + Target.Name);     //输出到控制台
        uiText.text = "Found: " + Target.Name + "\r\n" + uiText.text;   //输出到UI文本
    }

    /// <summary>
    /// 识别对象丢失事件处理方法
    /// </summary>
    void OnTargetLost(TargetAbstractBehaviour behaviour)
    {
        Debug.Log("Lost: " + Target.Name);      //输出到控制台
        uiText.text = "Lost: " + Target.Name + "\r\n" + uiText.text;    //输出到UI文本
    }

    /// <summary>
    /// 识别对象加载事件处理方法
    /// </summary>
    void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
    {
        Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
    }

    /// <summary>
    /// 识别对象卸载事件处理方法
    /// </summary>
    void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
    {
        Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
    }
}
