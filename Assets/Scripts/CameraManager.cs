using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    private GameObject player;

    private Vector3 distPlayerToCam;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
        distPlayerToCam = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            transform.position = Vector3.Lerp(transform.position, player.transform.position + distPlayerToCam, Time.deltaTime * 2.0f) ;
        }
    }

    IEnumerator ChasePlayer()
    {

        yield return null;
    }
}
