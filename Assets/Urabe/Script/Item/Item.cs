using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    //アイテムの種類定義
    public enum ItemType
    {
        Key //鍵
    }

    [SerializeField] private ItemType type;

    //初期化処理
    public void Initialize()
    {
        //アニメーションが終わるまで無効に
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        //出現アニメーション
        var transformCache = transform;
        var dropPosition = transform.localPosition +
            new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        transformCache.DOLocalMove(dropPosition, 0.5f);
        var defaultScale = transformCache.localScale;
        transformCache.localScale = Vector3.zero;
        transformCache.DOScale(defaultScale, 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                colliderCache.enabled = true;
            }); 
    }

    //プレイヤーが鍵を取得したら
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        //オブジェクトの破棄
        Destroy(gameObject);
    }
}