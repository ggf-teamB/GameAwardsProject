using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconControl : MonoBehaviour
{

    [SerializeField] private GameObject getKeyIcon;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isKey == true) getKeyIcon.SetActive(true);
    }
}
