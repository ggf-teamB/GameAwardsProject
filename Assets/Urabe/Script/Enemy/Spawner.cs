using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    /// <summary>
    /// 敵出現のCoroutine
    /// </summary>
    ///<returns></returns> 

   private IEnumerator SpawnLoop()
    {
        while (true)
        {
            //距離10のベクトル
            var distanceVector = new Vector3(10, 0);

            //プレイヤーの位置をベースにした数の出現位置　Y軸に対してランダムに360度回転
            var spawnPositionFromPlayer = Quaternion.Euler(0, Random.
                Range(0, 360f), 0) * distanceVector;

            //敵を出現させたい位置を決定
            var spawnPosition = playerStatus.transform.position +
                spawnPositionFromPlayer;

            //指定座標から一番近いNavMeshの座標を探す
            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(spawnPosition, out navMeshHit,10,
                NavMesh.AllAreas))
            {
                //enemyPrefabを複製
                Instantiate(enemyPrefab, navMeshHit.position, Quaternion.
                    identity);
            }

            //10秒待つ
            yield return new WaitForSeconds(10);

            if(playerStatus.Life <= 0)
            {
                //プレイヤーが倒れたらループを抜ける
                break;
            }
        }
    }
}
