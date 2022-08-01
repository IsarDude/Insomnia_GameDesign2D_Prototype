using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenuController : MonoBehaviour
{
    public GameObject gameObject;
    public Button continueBtn;
    public Button escBtn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        escBtn.gameObject.SetActive(false);
		continueBtn.onClick.AddListener(continueGame);
        escBtn.onClick.AddListener(exitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
                continueBtn.gameObject.SetActive(false);
                escBtn.gameObject.SetActive(false);
                Cursor.visible = false;
            }else{
                Cursor.visible = true;
                gameObject.SetActive(true);
                continueBtn.gameObject.SetActive(true);
                escBtn.gameObject.SetActive(true);
            }
        }
    }
	void continueGame()
    {
		gameObject.SetActive(false);
        continueBtn.gameObject.SetActive(false);
        escBtn.gameObject.SetActive(false);
        Cursor.visible = false;
	}

    void exitGame()
    {
        Application.Quit();
    }
}
