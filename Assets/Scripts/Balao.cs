using UnityEngine;
using System.Collections;

public class Balao : MonoBehaviour {

    public AudioClip audio;
    public AudioSource musica;
    [SerializeField]
    private GameObject b1, b2, b3, top;
    private SpriteRenderer Sprite;
    int i = 0;

    public GameObject Top
    {
        get
        {
            return top;
        }

        set
        {
            top = value;
        }
    }

    void Start ()
    {
        musica.clip = audio;
        this.Sprite = this.GetComponent<SpriteRenderer>();
	}
	

	void Update ()
    {

	}
    
    public void Verificacao()
    {
        if (i == 0)
        {
            musica.Play();
            this.b1.gameObject.SetActive(false);
        }
        if (i == 1)
        {
            musica.Play();
            this.b2.gameObject.SetActive(false);
        }
        if (i == 2)
        {
            musica.Play();
            this.b3.gameObject.SetActive(false);
        }
        i++;
        if (i == 3)
        {
            if (gameObject.GetComponentInParent<Jogador>())
                gameObject.GetComponentInParent<Jogador>().Morte();
            if (gameObject.GetComponentInParent<Inimigo>())
            {
                this.b1.gameObject.SetActive(true);
                this.b2.gameObject.SetActive(true);
                this.b3.gameObject.SetActive(true);
                i = 0;
                gameObject.GetComponentInParent<Inimigo>().Morte();
            }
        }
    }

}
