using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 offset;
    public float smoothness = 3f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(0, player.position.y, player.position.z);
        pos += offset;
        transform.position = Vector3.Lerp(transform.position,pos,smoothness*Time.deltaTime);
    }
}
