using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SetCursor(bool flg)
    {
        Cursor.visible = flg;
    }
}
