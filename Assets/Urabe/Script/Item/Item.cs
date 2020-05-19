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

    //プレイヤーのゲームオブジェクト
    [SerializeField] private GameObject playerObject;

    //プレイヤークラス
    [SerializeField] private Player player;

    //システムオブジェクト
    [SerializeField] private GameObject systemObject;

    //メッセージマネージャークラス
    [SerializeField] private MessageManager mManager;

    private string getKeyMessage = "鍵を取得しました";

    private void Start()
    {
        //Playerタグが付いてるオブジェクトを取得する
        playerObject = GameObject.FindGameObjectWithTag("Player");

        //playerにPlayerクラスを代入する
        player = playerObject.GetComponent<Player>();

        //Systemタグが付いてるオブジェクトを取得する
        systemObject = GameObject.FindGameObjectWithTag("System");

        //mManagerにMessageManagerクラスを代入する
        mManager = systemObject.GetComponent<MessageManager>();
    }

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

        player.GetKey();

        mManager.SetMessage(getKeyMessage);

        //オブジェクトの破棄
        Destroy(gameObject);
    }
}