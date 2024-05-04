using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusLoading : MonoBehaviour
{
    void move()
    {
        SceneManager.LoadScene("2DMap");
    }
}
