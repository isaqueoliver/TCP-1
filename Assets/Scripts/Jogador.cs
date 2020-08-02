using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Jogador : MonoBehaviour {
    public Text pontos;
    public Image morte;

    [SerializeField]
    private float vel, imp, lVel;
    private Rigidbody2D rb;
    private Transform trans;
    bool cd = false;
    float cd2 = 5;
    int score;
    GameObject iniRes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.GetComponent<ScoreMax>());
    }

    void Start () {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.trans = this.GetComponent<Transform>();
 
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        Impulso();
        if(cd)
        {
            cd2 -= Time.deltaTime;
            Res(this.gameObject);
        }
        pontos.text = score.ToString();

	}
    void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (this.trans.localScale.x < 0)
                this.trans.localScale = new Vector3(-this.trans.localScale.x, this.trans.localScale.y, this.trans.localScale.z);
            this.rb.AddForce(new Vector2(vel, 0));
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if(this.trans.localScale.x > 0)
                this.trans.localScale = new Vector3(-this.trans.localScale.x, this.trans.localScale.y, this.trans.localScale.z);

            this.rb.AddForce(new Vector2(-vel, 0));
        }
        if (this.rb.velocity.x > lVel)
            this.rb.velocity = new Vector2(lVel, this.rb.velocity.y);
        if (this.rb.velocity.x < -lVel)
            this.rb.velocity = new Vector2(-lVel, this.rb.velocity.y);

    }
    void Impulso()
    {
        if (Input.GetAxis("Vertical") > 0)
            this.rb.AddForce(new Vector2(0, imp));
        if (this.rb.velocity.y > lVel)
            this.rb.velocity = new Vector2(this.rb.velocity.x, lVel);
    }
    public void Morte()
    {
        gameObject.GetComponent<ScoreMax>().ScoreTotal();
        morte.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Res(GameObject inimigo)
    {
        if (!cd)
            iniRes = inimigo;
        cd = true;
        if (cd2 <= 0)
        {
            iniRes.SetActive(true);
            cd = false;
            cd2 = 5;
        }
    }

    public void AddScore()
    {
        score += 40;
    }
}
