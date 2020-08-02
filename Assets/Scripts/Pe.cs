using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pe : MonoBehaviour {

    [SerializeField]
    private GameObject botton;
    bool cd = true;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponentInChildren<Balao>())
        {
            if (col.gameObject.GetComponentInChildren<Balao>().Top.transform.position.y < this.botton.transform.position.y)
            {
                col.gameObject.GetComponentInChildren<Balao>().Verificacao();
                if (gameObject.GetComponentInParent<Jogador>())
                    gameObject.GetComponentInParent<Jogador>().AddScore();
                if (!gameObject.GetComponentInParent<Jogador>())
                {
                    gameObject.GetComponentInParent<Inimigo>().Estorou();
                }
            }
        }
    }
}
