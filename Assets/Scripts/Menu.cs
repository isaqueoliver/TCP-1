using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public Button novoJogo, instrucao, sair;
    public GameObject menuInst;

    private void Start()
    {
        Button jogar = novoJogo.GetComponent<Button>();
        jogar.onClick.AddListener(NewGame);
        Button inst = instrucao.GetComponent<Button>();
        inst.onClick.AddListener(Instrucao);
        //Button exit = sair.GetComponent<Button>();
        //jogar.onClick.AddListener(SairGame);
    }

    void NewGame()
    {
        SceneManager.LoadScene("airballoon");
    }
    void Instrucao()
    {
        this.gameObject.SetActive(false);
        menuInst.SetActive(true);

    }
    /*void SairGame()
    {
        Debug.Log("Clicou!");
        //Application.Quit();
    }*/
}
