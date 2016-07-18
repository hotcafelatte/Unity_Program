using UnityEngine;
using System.Collections;

/// <summary>
/// スクリプトによるアニメーションをさせるクラス
/// </summary>
public class OnButtonAnimation : MonoBehaviour
{

    /// <summary>
    /// コルーチン処理の終了時間。アニメーションの終了時刻に合わせる。
    /// </summary>
    [SerializeField]
    private float endTime = 0.15f;
    /// <summary>
    /// AnimationCurve.Linearの引数（開始時間、初期値、終了時間、終了値）を指定します
    /// </summary>
    public AnimationCurve scaleCurveX = AnimationCurve.Linear(0, 1, 1, 1);
    public AnimationCurve scaleCurveY = AnimationCurve.Linear(0, 1, 1, 1);

    // コンポーネントのキャッシュ用変数
    RectTransform rectTransform;

    /// <summary>
    /// 初期化時に呼び出されるメソッド
    /// </summary>
    void Start()
    {
        // コンポーネントをキャッシュします
        rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// アニメーション開始時に呼び出されるメソッド
    /// </summary>
    public void StartAnimation()
    {
        // コルーチンを開始する
        StartCoroutine(AnimationCoroutine());
    }

    /// <summary>
    /// アニメーションを実行するコルーチン
    /// </summary>
    /// <returns>アニメーション動作をするコルーチンです</returns>
    IEnumerator AnimationCoroutine()
    {
        // 初期値を指定します
        Vector3 initialScale = new Vector3(0, 0, 1);
        float startTime = 0;
        float time = 0;
        float x;
        float y;

        // endTimeになるまで繰り返します
        while(time - startTime <= endTime)
        {
            x = scaleCurveX.Evaluate(time - startTime);
            y = scaleCurveY.Evaluate(time - startTime);
            rectTransform.localScale = initialScale + new Vector3(x, y, 0);
            time += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
    
}