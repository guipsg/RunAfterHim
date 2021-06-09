using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPrototype : MonoBehaviour {
    [SerializeField] private Management mg;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator an;
    [SerializeField] private GameObject feetSensor;
    [SerializeField] private GameObject groundSensor;
    [SerializeField] private ParticleSystem runningParticle;

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private float _velocity;
    [SerializeField] private int _cont = 0;
    [SerializeField] private bool _canMove = false;
    private bool grounded = false;
    private bool stopped = false;
    private bool canDoubleJump = false;
    private bool canGroundPound = false;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpClip,enemyDamageClip,buttonClip,crystalClip;
    public float velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }
    public Rigidbody2D rb
    {
        get { return _rb; }
        set { _rb = value; }
    }
    public bool canMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }
    private int cont;

    private void Awake()
    {
        mg = GameObject.FindGameObjectWithTag("Manager").GetComponent<Management>();

        transform.position = mg.checkPoint;
    }

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
        }
        if(!canMove || !grounded)
        {
			em.enabled = false;
            an.SetBool("Running", false);
        }
        an.SetBool("Grounded", grounded);
        //PULO
        if (grounded)
        {
            cont = 0;
            an.SetBool("Jumping", false);
        }
        grounded = grounded = Physics2D.Linecast(feetSensor.transform.position, groundSensor.transform.position, 1 << LayerMask.NameToLayer("Ground")) ||
                                  Physics2D.OverlapCircle(feetSensor.transform.position, groundCheckRadius, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(feetSensor.transform.position, groundSensor.transform.position);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump(jumpForce);
        }
        else if (!grounded && Input.GetButtonDown("Jump") && cont <1 )
        {
            if (canDoubleJump)
            {
            Jump(jumpForce*0.5f);
            }
        }
        if(Input.GetButtonDown("Cancel") && canGroundPound)
        {
            Jump(jumpForce*-1f);
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
            audioSource.PlayOneShot(enemyDamageClip, PlayerPrefs.GetFloat("SfxVolume"));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            audioSource.PlayOneShot(buttonClip,PlayerPrefs.GetFloat("SfxVolume"));
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            audioSource.PlayOneShot(crystalClip, PlayerPrefs.GetFloat("SfxVolume") * 0.2f);
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
    public void JumpSfx() { audioSource.PlayOneShot(jumpClip, PlayerPrefs.GetFloat("SfxVolume")); }
}
