using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public void SetCursor(bool flg)
    {
        Cursor.visible = flg;
    }
}
