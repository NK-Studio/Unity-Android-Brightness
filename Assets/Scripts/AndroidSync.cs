using UnityEngine;
using UnityEngine.UI;

public class AndroidSync : MonoBehaviour
{
    private AndroidJavaObject _androidJavaObject;
    
    public Text CurrentText;

    private void Start()
    {
        if (_androidJavaObject == null) 
            _androidJavaObject = new AndroidJavaObject("com.unity3d.player.UPlugin");
    }

    /// <summary>
    /// 밝기를 설정합니다. (0~1)
    /// </summary>
    /// <param name="adjustedBrightness">0~255까지의 숫자로 밝기를 처리합니다.</param>
    public void SetBrightness(int adjustedBrightness)
    {
        _androidJavaObject.Call("SetBrightness", adjustedBrightness);
    }

    /// <summary>
    /// 밝기를 가져옵니다.
    /// </summary>
    /// <returns></returns>
    public int GetBrightness()
    {
        return _androidJavaObject.Call<int>("GetBrightness");
    }
    
    public void ASKPermission()
    {
        _androidJavaObject.Call("AskPermission");
    }
    
    public void Test()
    {
        CurrentText.text = GetBrightness().ToString();
    }

    public void Test02(float value)
    {
        // 밝기 조절을 위한 비율 (0.1에서 1.0 사이의 값을 사용)
        int adjustedBrightness = (int)(255 * value);
        SetBrightness(adjustedBrightness);
    }
}