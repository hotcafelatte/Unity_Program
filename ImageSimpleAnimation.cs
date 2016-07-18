using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// UIにシンプルなアニメーションを実装するクラス
/// </summary>
public class ImageSimpleAnimation : MonoBehaviour
{
    /// <summary>
    /// アニメーションさせるスピードを指定します
    /// </summary>
    [SerializeField]
    private float animationSpeed = 0.15f;
    /// <summary>
    /// スプライトを指定します
    /// </summary>
    public Sprite[] sprite;

    // コンポーネントのキャッシュ用変数
    Image image;
    
    /// <summary>
    /// 初期化時に呼び出されるメソッド
    /// </summary>
	void Start ()
    {
        // コンポーネントをキャッシュする
        image = GetComponent<Image>();

        // コルーチンを呼び出す
        StartCoroutine(AnimationSprite());
    }

    /// <summary>
    /// スプライトアニメーションコルーチン
    /// </summary>
    /// <returns>スプライトを切り替え続けます</returns>
    IEnumerator AnimationSprite()
    {
        // スプライト配列のサイズを格納する
        int spriteLength = sprite.Length;
        // 配列の添え字を格納する変数
        int index = 0;

        while (true)
        {
            yield return new WaitForSeconds(animationSpeed);

            // 剰余算により0~Lengthをループさせ、イメージに適用します
            index = ((index + 1) % spriteLength);
            image.sprite = sprite[index];
        }
    }
}
