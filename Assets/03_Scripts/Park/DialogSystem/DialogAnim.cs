using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnim : MonoBehaviour
{
    public void startTyping()
    {
        DialogManager.instance.ShowDialog(0);
    }
    public void Hide()
    {
        DialogManager.instance.HidePanel();
    }
}
