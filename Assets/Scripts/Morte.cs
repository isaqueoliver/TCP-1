using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Morte : MonoBehaviour
{
    public Button menu;

    private void Start()
    {
        Button myMenu = menu.GetComponent<Button>();
        myMenu.onClick.AddListener(MyMenu);

    }

    private void Update()
    {
    }
    void MyMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
