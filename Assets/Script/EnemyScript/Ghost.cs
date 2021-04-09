using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0.05f, 0);
    }

    //画面外出たら削除
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
