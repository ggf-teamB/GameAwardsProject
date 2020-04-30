using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

   /// <summary>
   /// Is TrigerがONの時に他のColliderと重なっているときは、常に呼び出される
   /// </summary>
   /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        //onTriggerStayで指定された処理を実行する
        onTriggerStay.Invoke(other);
    }

    // UnityEventを継承したクラスに[Serializable]属性を付与して、Inspectorウインドウ上に表示する
    [Serializable]
    public class TriggerEvent:UnityEvent<Collider>
    {
    }
}
