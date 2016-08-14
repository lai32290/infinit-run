using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator anime;
	public Rigidbody2D playerRigidbody;
	public int forceJump;

	public bool jump;
	public bool slide;

	public Transform groundCheck;
	public bool grounded;
	public LayerMask ground;

    public float timeToJumpTop;
    private float _timeToJumpTop;

    public float slideAnimationDuration;
	private float _slideAnimationDuration;


	public GameObject player;
    public Transform colisor;

    public AudioSource audio;
    public AudioClip jumpSound;
    public AudioClip dashSound;

    public UnityEngine.UI.Text scoreText;
    public static int score;

	private float defaultColiderY = 0.58f;
	private float jumpColiderY = 0.912f;
    private float slideColiderY = 0.386f;


    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update() {


        scoreText.text = score.ToString();

        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));

            _timeToJumpTop = 0;
            audio.PlayOneShot(jumpSound);
            audio.volume = 1;
            slide = false;
        }

        if (!grounded)
        {
            _timeToJumpTop += Time.deltaTime;

            if (_timeToJumpTop >= timeToJumpTop)
			    colisor.position = new Vector3 (colisor.position.x, calcJumpColiderY(player.transform.position, jumpColiderY));

        }

		if (Input.GetButtonDown("Slide") && grounded) {
			slide = true;
            audio.PlayOneShot(dashSound);
            audio.volume = 0.5f;
            colisor.position = new Vector3(colisor.position.x, 
                calcSlideColiderY(player.transform.position.y, slideColiderY));

            _slideAnimationDuration = 0;
		}

        if (slide)
        {
            _slideAnimationDuration += Time.deltaTime;

            if (_slideAnimationDuration >= slideAnimationDuration)
                slide = false;

        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);

		if (grounded && !slide) {
			colisor.position = new Vector3 (colisor.position.x, calcDefaultColiderY (player.transform.position, this.defaultColiderY));
		}
        
        anime.SetBool ("jumping", !grounded);
		anime.SetBool ("slashing", slide);
	}

	private float calcJumpColiderY (Vector3 playerVector, float jumpY) {
		return playerVector.y + jumpY;
	}

	private float calcDefaultColiderY(Vector3 playerVector, float defaultY) {
		return playerVector.y + defaultY;
	}

    private float calcSlideColiderY(float playerY, float slideY)
    {
        return playerY + slideY;
    }

    void OnTriggerEnter2D()
    {
        int recored = PlayerPrefs.GetInt("record");
        PlayerPrefs.SetInt("score", score);
        if (score > recored)
            PlayerPrefs.SetInt("record", score);

        Application.LoadLevel("over");
    }
}
