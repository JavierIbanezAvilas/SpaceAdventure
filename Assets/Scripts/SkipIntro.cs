using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Destroy(gameObject);
        }
    }
}
