using EasyAR;
using UnityEngine;

public class OffCard : ImageTargetBaseBehaviour {

    /// <summary>
    /// 要显示的模型
    /// </summary>
    public Transform model;

    /// <summary>
    /// 起始坐标
    /// </summary>
    private Vector3 position;
    /// <summary>
    /// 起始角度
    /// </summary>
    private Quaternion rotation;
    /// <summary>
    /// 起始缩放大小
    /// </summary>
    private Vector3 scale;

    /// <summary>
    /// 是否脱卡状态
    /// </summary>
    private bool offCard;

    /// <summary>
    /// 重写Awake事件
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        //订阅事件
        TargetFound += OnTargetFound;   //识别成功事件
        TargetLost += OnTargetLost;     //识别对象丢失事件

        ///保存起始位置信息
        position = model.localPosition;
        rotation = model.localRotation;
        scale = model.localScale;

        offCard = false;
    }

    /// <summary>
    /// 识别成功事件处理方法
    /// </summary>
    void OnTargetFound(TargetAbstractBehaviour behaviour)
    {
        Debug.Log("Found: " + Target.Name);     //输出到控制台

        //激活模型
        model.gameObject.SetActive(true);

        //将模型放置到默认位置
        if (model.parent != transform)
        {
            model.parent = transform;
        }
        model.localPosition = position;
        model.localRotation = rotation;
        model.localScale = scale;

        //结束脱卡状态
        offCard = false;
    }

    /// <summary>
    /// 识别对象丢失事件处理方法
    /// </summary>
    void OnTargetLost(TargetAbstractBehaviour behaviour)
    {
        Debug.Log("Lost: " + Target.Name);      //输出到控制台

        //如果没有在脱卡状态，隐藏模型
        if (!offCard)
        {
            model.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 脱卡
    /// </summary>
    public void SetOffCard()
    {
        //如果模型处于显示状态，则修改模型的父游戏对象。
        if (model.gameObject.activeSelf)
        {
            offCard = true;
            model.parent = null;
        }
    }
}
