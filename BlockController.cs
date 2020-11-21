using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public AudioSource audiosrc;   
    int containerchangingvalue;
    public GameObject[] Block;
    public GameObject firstblock;
    public GameObject[] containers;
    float x = 1077, y = 1077, z = 1077,i=1077,j=1077;
    public bool Block1cnt = true,Block2cnt=true, Block3cnt = true, Block4cnt = true, Block5cnt = true;
    Playercontroller cntrl;
    // Start is called before the first frame update
    void Start()
    {
        cntrl = GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        // A block when is for when they will active and when they will disable;
        containers[0].SetActive(Block1cnt);
        containers[1].SetActive(!Block1cnt);
        containers[2].SetActive(Block2cnt);
        containers[3].SetActive(!Block2cnt);
        containers[4].SetActive(Block3cnt);
        containers[5].SetActive(!Block3cnt);
        containers[6].SetActive(Block4cnt);
        containers[7].SetActive(!Block4cnt);
        containers[8].SetActive(Block5cnt);
        containers[9].SetActive(!Block5cnt);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="cube")
        {
            Block[0].transform.position = new Vector3(0, 0, x);
             x = 1077 + x;
            cntrl.pV += 1;
            //Block[3].SetActive(true) ;
           // Block[0].SetActive(false);
            //firstblock.SetActive(false);
            cntrl.ps += 2;

            Block1cnt = !Block1cnt;
        }
        if (other.gameObject.tag=="cube1")
        {
            Block[1].transform.position = new Vector3(0, 0,y);
            y = 1077 + y;
            //Block[4].SetActive(true);
         //   Block[1].SetActive(false);

            Block2cnt = !Block2cnt;
        }
        if (other.gameObject.tag=="cube2")
        {
            Block[2].transform.position = new Vector3(0, 0, z);
            z = 1077 + z;
            //Block[0].SetActive(true);
           // Block[2].SetActive(false);

            Block3cnt = !Block3cnt;
        }
        if (other.gameObject.tag == "cube3")
        {
            Block[3].transform.position = new Vector3(0, 0, i);
            i = 1077 + i;
           // Block[1].SetActive(true);
           // Block[3].SetActive(false);

            Block4cnt = !Block4cnt;
        }
        if (other.gameObject.tag == "cube4")
        {
            Block[4].transform.position = new Vector3(0, 0, j);
            j = 1077 + j;
          //  Block[2].SetActive(true);
          //  Block[4].SetActive(false);

            Block5cnt = !Block5cnt;
            cntrl.ps += 2;

        }
    }
    public void Playsound()
    {
        audiosrc.enabled = true;
    }
    public void Stopsound()
    {
        audiosrc.enabled = false;
    }

}
