using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // makes an object persistent in between scene loads 
    private void Awake()
    {
        transform.SetParent(null);
        Object.DontDestroyOnLoad(gameObject);
    }
}
