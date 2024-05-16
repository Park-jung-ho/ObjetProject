using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventTest
{
    public static string eventID = "";
    public static int eventDialogID;
    
    public static void ChangeDialogID(int id)
    {
        if (eventDialogID == id)
        {
            OnEvent();
        }
    }
    public static void OnEvent()
    {
        if (eventID == "AppleOut")
        {
            GameManager.instance.SendMessage("넌 그냥 나가라 ㅋㅋ","티미");
        }
    }

}
