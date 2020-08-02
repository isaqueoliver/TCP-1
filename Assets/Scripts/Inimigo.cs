using UnityEngine;
using System.Collections;

public enum estados
{
    perseguir, fugir, procurar
}

public class Inimigo : MonoBehaviour {
    
    private Rigidbody2D rb;
    private Transform trans;
    GameObject npc;
    
    [SerializeField]
    private float mov, lVel;
    int dirX = 1, dirY = 1;
    float tempo, tempo2, enjoo, cdPer2, timer;
    bool cd = false, cdPer = true;
    estados estado = estados.procurar;
    GameObject alvo;

	void Start ()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.trans = GetComponent<Transform>();
        this.npc = this.gameObject;
	}
	
	void Update ()
    {
        
        switch (estado)
        {
            case estados.fugir:
                Fugir();
                break;
            case estados.perseguir:
                Perseguir();
                break;
            case estados.procurar:
                Movimentacao();
                break;
        }
        if (cd)
        {
            tempo2 -= Time.deltaTime;
        }
        if (this.trans.position.y < 0)
            MoveUp();
    }

    void Perseguir()
    {
        if (cdPer)
        {
            if (this.gameObject.transform.position.y - GetComponent<Renderer>().bounds.extents.y > alvo.gameObject.transform.position.y + GetComponent<Renderer>().bounds.extents.y)
            {
                //Eu na esquerda
                if (this.gameObject.transform.position.x < alvo.transform.position.x)
                    MoveRight();
                else
                    MoveLeft();
            }
            cdPer2 += Time.deltaTime;
            if (cdPer2 >= 5)
            {
                cdPer2 = 0;
                cdPer = false;
                estado = estados.fugir;

            }
            cd = false;
            if (Vector2.Distance(this.gameObject.transform.position, alvo.gameObject.transform.position) > 2)
                estado = estados.procurar;
        }
    }
    void Fugir()
    {
        if (this.gameObject.transform.position.x < alvo.transform.position.x)
        {
            MoveLeft();
            MoveUp();
        }
        else
        {
            MoveRight();
            MoveUp();
        }
        if (Vector2.Distance(this.gameObject.transform.position, alvo.gameObject.transform.position) > 2)
            estado = estados.procurar;
        if (!cdPer)
        {
            enjoo += Time.deltaTime;
            if (enjoo >= 2)
            {
                cdPer = true;
                enjoo = 0;
            }
        }
    }
	void Movimentacao ()
	{
        if (tempo > 0)
        {
            if (dirX < 1)
                MoveRight();
            else
                MoveLeft();
            if (dirY < 1)
                MoveUp();
            tempo -= Time.deltaTime;
        }
        else
        {
            tempo = Random.Range(1f, 4f);
        	dirX = Random.Range (0, 2);
		    dirY = Random.Range (0, 2);
        }
        if (!cdPer)
        {
            enjoo += Time.deltaTime;
            if (enjoo >= 2)
            {
                cdPer = true;
                enjoo = 0;
            }
        }
	}
    void MoveUp()
    {

        this.rb.AddForce(new Vector2(0, mov));
        if (this.rb.velocity.y > lVel)
            this.rb.velocity = (new Vector2(this.rb.velocity.x, lVel));

    }
    void MoveRight()
    {
        this.rb.AddForce(new Vector2(mov, 0));
        if (this.rb.velocity.x > lVel)
            this.rb.velocity = new Vector2(lVel, this.rb.velocity.y);
        if (this.trans.localScale.x < 0)
            this.trans.localScale = new Vector3(-this.trans.localScale.x, this.trans.localScale.y, this.trans.localScale.z);
    }
    void MoveLeft()
    {
        this.rb.AddForce(new Vector2(-mov, 0));
        if (this.rb.velocity.x < -lVel)
            this.rb.velocity = new Vector2(-lVel, this.rb.velocity.y);
        if (this.trans.localScale.x > 0)
            this.trans.localScale = new Vector3(-this.trans.localScale.x, this.trans.localScale.y, this.trans.localScale.z);
    }
   void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.tag == "ParedeUP")
            dirY = 1;
        if (colisao.gameObject.tag == "ParedeRight")
            dirX = 1;
        if (colisao.gameObject.tag == "ParedeLeft")
            dirX = 0;
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Balao>())
        {
            float up = this.gameObject.transform.position.y;
            float downI = col.gameObject.transform.position.y;

            if (up < downI)
            {
                estado = estados.fugir;
            }
            else
                if (tempo2 <= 0)
                    estado = estados.perseguir;
            alvo = col.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        estado = estados.procurar;
    }
    public void Estorou()
    {
        estado = estados.procurar;
        cd = true;
        tempo2 = 3;
    }
    public void Morte()
    {
        FindObjectOfType<Jogador>().Res(this.gameObject);
        gameObject.SetActive(false);

    }
}
