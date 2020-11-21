using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerdestroy : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 50f);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

}
