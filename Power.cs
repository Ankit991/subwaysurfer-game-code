using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Power : MonoBehaviour
{
    public bool invisible = true;
    public Transform power, shoesspawn, coins;
    public GameObject[] shoes;
    Vector3 powerpos;
    int powerposx;
    [HideInInspector] public int x;
    public GameObject Respawn;
    Playercontroller playercontroller;
    public Text totalcointext, cointext;
    [HideInInspector]  public int coinpoint;
    [HideInInspector] public int totalcoin;

    // Start is called before the first frame update
    private void Awake()
    {
        cointext.enabled = false;
    }
    void Start()
    {
        totalcointext.text = PlayerPrefs.GetInt("Totalcoins", 0).ToString();
        totalcoin= PlayerPrefs.GetInt("Totalcoins", 0);
        InvokeRepeating("Powerspawn", 70f, 80f);
        InvokeRepeating("Spawnshoes", 50f, 50f);
        InvokeRepeating("coin", 3f, 2f);
        playercontroller = GetComponent<Playercontroller>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            playercontroller.jumpforce = 13;
        }
      
        if (PlayerPrefs.GetInt("Totalcoins", 0) <= totalcoin)
        {
           
            PlayerPrefs.SetInt("Totalcoins", totalcoin);
            totalcointext.text = totalcoin.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteKey("Totalcoins");
            PlayerPrefs.DeleteKey("Highscore");
        }
    }
   IEnumerator Invisible()
    {
        yield return new WaitForSeconds(5f);
        invisible = true;
        Respawn.SetActive(false);

    }
    IEnumerator highJump()
    {
        yield return new WaitForSeconds(10f);
        shoes[0].SetActive(false);
        shoes[1].SetActive(false);
        playercontroller.jumpforce = 13;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "power")
        {
            invisible = false;
            StartCoroutine(Invisible());
            Destroy(other.gameObject);
            Respawn.SetActive(true);
        }
        if (other.gameObject.tag == "Shoes")
        {
            playercontroller.jumpforce = 20;
            StartCoroutine(highJump());
            shoes[0].SetActive(true);
            shoes[1].SetActive(true);
        }
        if (other.gameObject.tag == "coin")
        {
            cointext.enabled = true;
            coinpoint += 1;
            totalcoin += 1;
           cointext.text = "+" + coinpoint.ToString();
            Audiomanager.Playsound("coin");
            Destroy(other.gameObject);
            StartCoroutine(Repeatcoinenable());
           
        }
       
    }
    IEnumerator Repeatcoinenable()
    {
        yield return new WaitForSeconds(1f);
        cointext.enabled = false;
    }
    public void Spawnshoes()
    {
       int shoesx = Random.Range(0, 3);
        switch (shoesx)
        {
            case 0:
                powerposx = -3;
                break;
            case 1:
                powerposx = 0;
                break;
            case 2:
                powerposx = 3;
                break;
        }
       
       
        this.gameObject.transform.position = new Vector3(0, 0, transform.position.z);
        powerpos = this.gameObject.transform.position + new Vector3(powerposx, 0f, Random.Range(100, 120));

        Instantiate(shoesspawn, powerpos,transform.rotation);
        powerposx = 0;
    }
    public void coin()
    {
        int shoesx = Random.Range(0, 3);
        switch (shoesx)
        {
            case 0:
                powerposx = -3;
                break;
            case 1:
                powerposx = 0;
                break;
            case 2:
                powerposx = 3;
                break;
        }
        this.gameObject.transform.position = new Vector3(0, 0, transform.position.z);
        powerpos = this.gameObject.transform.position + new Vector3(powerposx, -0.9f, Random.Range(100, 120));
        if (!playercontroller.gameover)
        {
            Instantiate(coins, powerpos, transform.rotation);
        }

    }
    public void Powerspawn()
    {
        x = Random.Range(0, 3);
        switch (x)
        {
            case 0:
                powerposx = -3;
                break;
            case 1:
                powerposx = 0;
                break;
            case 2:
                powerposx = 3;
                break;
        }
        this.gameObject.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        powerpos = this.gameObject.transform.position+new Vector3(powerposx,Random.Range(1,3),Random.Range(100, 120));
       
        Instantiate(power,powerpos,Quaternion.identity);
        powerposx = 0;
    }
   
}
