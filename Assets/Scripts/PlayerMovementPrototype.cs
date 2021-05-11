using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPrototype : MonoBehaviour {
    private Management mg;
    public Rigidbody2D rb;
    public Animator an;
    [SerializeField] GameObject feetSensor;
    [SerializeField] GameObject groundSensor;
	public ParticleSystem runningParticle;
    public float jumpForce;
    public float velocity;
    public bool canMove = false;
    bool grounded = false;
    public int cont = 0;
    public bool stopped = false;
    public AudioSource audioSource;
    public AudioClip jumpClip,enemyDamageClip,buttonClip,crystalClip;
    private void Awake()
    {
        mg = GameObject.FindGameObjectWithTag("Manager").GetComponent<Management>();

        transform.position = mg.checkPoint;
    }
	void Start(){


	}
    // Update is called once per frame
    void Update () {
		var em = runningParticle.emission;
        //CORRIDA
        if (canMove)
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        if (canMove && grounded)
        {
            an.SetBool("Running", true);
			em.enabled = true;
        }else
        {
			em.enabled = false;
            an.SetBool("Running", false);
			
        }
        an.SetBool("Grounded", grounded);
        //PULO
        if (grounded)
        {
            an.SetBool("Jumping", false);
        }
        grounded = Physics2D.Linecast(feetSensor.transform.position, groundSensor.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(feetSensor.transform.position, groundSensor.transform.position);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump(jumpForce);
        }

        if (!canMove && grounded && cont >= 1)
        {
            canMove = true;
        }
    }

    public void Flip(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        velocity *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyHead"))
        {
            audioSource.PlayOneShot(enemyDamageClip, 0.8f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            audioSource.PlayOneShot(buttonClip,0.8f);
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            audioSource.PlayOneShot(crystalClip, 0.5f);
        }
    }
    public void Jump(float jumpheight)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpheight);
        cont += 1;
        an.SetTrigger("Jumped");
        an.SetBool("Jumping",true);
        JumpSfx();
    }
    public void JumpSfx() { audioSource.PlayOneShot(jumpClip, 1f); }
}
