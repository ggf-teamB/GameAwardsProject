using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var button = GetComponent<Button>();
        //ボタンを押したとき
        button.onClick.AddListener(() =>
        {
            //シーン偏移の際にはSceneManagerを使用
            SceneManager.LoadScene("Menu");
        });
    }
}
