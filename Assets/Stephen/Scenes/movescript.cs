using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class movescript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public LayerMask ground;
    public int CanShoot;
    public ParticleSystem particles;
    public int heldItem;
    public int Ammo;
    public int Shells;
    public int havePistol;
    public int haveShotgun;
    public int HaveRifle;
    public int HaveLighter;

    public float Health;
    public int InvincibilityFrame;
    public int RawFood;
    public int CookedFood;
    public int Essence;
    public TextMeshProUGUI Message;
    public TextMeshProUGUI Weapon;
    public TextMeshProUGUI HealthDisplay;
    public TextMeshProUGUI StatusDisplay;
    public string HeldWeapon;
    public string Status;
    public GameObject CompressorSFX;
    public GameObject BulletSFX;
    public float Restart;
    void Start()
    {
        Ammo=0;
        Shells=0;
        havePistol=0;
        haveShotgun=0;
        HaveRifle=0;
        HaveLighter=0;
        Health=10;
        Essence=0;
        Status="Human";
  
    }
    
    public GameObject ProjectilePrefab;
    public GameObject Flame;
    public Transform LaunchOffset;


    // Update is called once per frame
    void Update()
    {
        rb.velocity += Input.GetAxisRaw("Horizontal") * Vector2.right * Time.deltaTime * 7;
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Physics2D.OverlapCircle(transform.position + Vector3.down, 0.1f, ground)) {
            rb.velocity = new Vector2(rb.velocity.x, 11);
            
        }

        if(Input.GetAxisRaw("Horizontal")>0) {
           transform.rotation=Quaternion.Euler(new Vector3 (0,0,0));
        }
 
        if(Input.GetAxisRaw("Horizontal")<0) {
           transform.rotation=Quaternion.Euler(new Vector3 (0,180,0));
 
        }

        if(Health<0.1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        Message.text= "9mm:               " + Ammo.ToString() + "\n" + "Shells:              " + Shells.ToString() + "\n" + "RawFood:        " + RawFood.ToString() + "\n" + "CookedFood:   " + CookedFood.ToString()+ "\n" + "Essence:          " + Essence.ToString();

        if(heldItem==0){
            HeldWeapon="None";
        }
        if(heldItem==1){
            HeldWeapon="Pistol";
        }
        if(heldItem==2){
            HeldWeapon="Shotgun";
        }
        if(heldItem==3){
            HeldWeapon="Rifle";
        }
        if(heldItem==4){
            HeldWeapon="Lighter";
        }

        Weapon.text= "\n" + "Weapon: " + HeldWeapon.ToString();
        StatusDisplay.text= "Status: " + Status.ToString();
        HealthDisplay.text= "Health:       " + Health.ToString();



        if(Input.GetKey(KeyCode.LeftShift)){
            rb.gravityScale=0;
            rb.velocity = new Vector3(rb.velocity.x,5);
            // this lets you fly
        } else {
            rb.gravityScale=1;
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            if(havePistol==1){
                heldItem=1;
            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            if(haveShotgun==1){
                heldItem=2;
            }
        }
        if(Input.GetKeyDown(KeyCode.C)){
            if(HaveRifle==1){
                heldItem=3;
            }
        }
        if(Input.GetKeyDown(KeyCode.V)){
            if(HaveLighter==1){
                heldItem=4;
            }
        }
        if(Input.GetKeyDown(KeyCode.R)){
            if(Restart>0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Restart=20;
        }
        if(Input.GetKeyDown(KeyCode.RightShift)){
            if(CookedFood>0){
                if(Health<10){
                    Health+=2;
                    CookedFood-=1;
                }
            }else{
                if(Status == "Half-Dead"){
                    if(RawFood>0){
                        if(Health<10){
                            Health+=0.5f;
                            RawFood-=1;
                        }
                    }
                }
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(CanShoot < 0){
                if(Ammo>0){
                    if(heldItem==1){
                        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                        CanShoot=10;
                        Ammo-=1;
                        Instantiate(BulletSFX, transform.position, transform.rotation);

                    }
                }    
                
                if(heldItem==2){
                    if(Shells>0){
                        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                        CanShoot=35;
                        Shells-=1;
                        Instantiate(BulletSFX, transform.position, transform.rotation);

                    }
                }

                if(heldItem==4){
                    Instantiate(Flame, LaunchOffset.position, transform.rotation);
                    CanShoot=200;

                    
                }
            }
                
        }
        if(Input.GetKey(KeyCode.Space)){
            if(CanShoot < 0){
                if(Ammo>0){
                    if(heldItem==3){
                        Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
                        CanShoot=5;
                        Ammo-=1;
                        Instantiate(BulletSFX, transform.position, transform.rotation);
                    }
                }      
            }
                
        }
    }

    
    void FixedUpdate(){
        CanShoot-=1;
        InvincibilityFrame-=1;
        Restart-=1;
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.layer == 6)
        {
            rb.velocity = new Vector2(0,0);
            // this freezes the player
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            
        }

        if(collider.gameObject.layer==9){
            heldItem = collider.gameObject.GetComponent<OutlandsPickup>().value;
            Destroy(collider.gameObject);
            Ammo+=15;
            havePistol=1;
        }
        if(collider.gameObject.layer==10){
            heldItem = collider.gameObject.GetComponent<OutlandsPickup>().value;
            Destroy(collider.gameObject);
            Shells+=8;
            haveShotgun=1;
        }
        if(collider.gameObject.layer==11){
            heldItem = collider.gameObject.GetComponent<OutlandsPickup>().value;
            Destroy(collider.gameObject);
            Ammo+=20;
            HaveRifle=1;
        }
        if(collider.gameObject.layer==21){
            heldItem = collider.gameObject.GetComponent<OutlandsPickup>().value;
            Destroy(collider.gameObject);
            HaveLighter=1;
        }
        if(collider.gameObject.layer==12){
            if(InvincibilityFrame<1){
                if(Status == "Half-Dead"){
                    Health-=0.5f;
                }else{
                    Health-=1; 
                }
                InvincibilityFrame=25;
                }
        }
        if(collider.gameObject.layer==13){
            Ammo+=10;
            Shells+=6;
            Destroy(collider.gameObject);
            }
        if(collider.gameObject.layer==14){
            RawFood+=1;
            Destroy(collider.gameObject);
            }
        if(collider.gameObject.layer==15){
            CookedFood+=RawFood;
            RawFood=0;
            }
        if(collider.gameObject.layer==17){
            Essence+=1;
            Destroy(collider.gameObject);
            }
        if(collider.gameObject.layer==18){
            if(Status == "Human"){
                if(Essence>29){
                    Essence-=30;
                    Status="Half-Dead";
                    Instantiate(CompressorSFX, transform.position, transform.rotation);
                }
            }
        }
    }
}

