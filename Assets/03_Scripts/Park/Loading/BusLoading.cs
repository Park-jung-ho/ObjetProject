using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BusLoading : MonoBehaviour
{
    public UnityEvent BusIn;
    public UnityEvent BusOut;
    void on()
    {
        BusIn.Invoke();
    }
    void off()
    {
        BusOut.Invoke();
    }
    void move()
    {
        SceneManager.LoadScene("2DMap");
    }
}
