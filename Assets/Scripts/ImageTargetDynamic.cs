using EasyAR;
using UnityEngine;

public class ImageTargetDynamic : ImageTargetBaseBehaviour
{

	public void ShowNamecard()
    {
        SetupWithImage("namecard.jpg", StorageType.Assets, "name card", new Vector2(1f, 0.6f));
    }

    public void ShowIdback()
    {
        SetupWithImage("idback.jpg", StorageType.Assets, "id back", new Vector2(1f, 0.618f));
    }
}
