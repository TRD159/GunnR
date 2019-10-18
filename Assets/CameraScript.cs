using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject player;
    Transform pT;

    public Vector3 Offset;

    bool CamLock;

    // Start is called before the first frame update
    void Start()
    {
        CamLock = false;
        player = GameObject.Find("Player");
        pT = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pT.position.x + Offset.x, pT.position.y + Offset.y, pT.position.z + Offset.z);
    }
}
