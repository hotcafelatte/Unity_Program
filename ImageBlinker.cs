using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// イメージを点滅させるクラス
/// </summary>
public class ImageBlinker : MonoBehaviour
{
    /// <summary>
    /// 点滅周期の時間を指定します
    /// </summary>
    [SerializeField]
    private float interval = 0.5f;

    // コンポーネントのキャッシュ用変数
    Image image;

    /// <summary>
    /// インスタンスが生成された際に呼ばれるメソッド
    /// </summary>
    void Awake()
    {
        // コンポーネントをキャッシュします
        image = GetComponent<Image>();
    }

    /// <summary>
    /// 実行可能状態になった際に呼び出されるメソッド
    /// </summary>
    void OnEnable()
    {
        // コルーチンを開始します
        StartCoroutine(Blink());
    }

    /// <summary>
    /// 点滅コルーチン
    /// </summary>
    /// <returns>イメージをinterval毎に点滅させます</returns>
    IEnumerator Blink()
    {
        while (true)
        {
            image.enabled = !image.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}