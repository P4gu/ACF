using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AddCards : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject crd;

    public bool startGame = false;

    public string modeGame;

    private int cardsNumbers;

    public void setEasyCards()
    {
        Debug.Log("chamou a funcao setEasyCards");
        cardsNumbers = 8;
        modeGame = "easy";
        StartGame();
        GameController gameController = Object.FindFirstObjectByType<GameController>();
        gameController.StartGame();
    }
    public void setMediumCards()
    {
        Debug.Log("chamou a funcao setMediumCards");
        cardsNumbers = 12;
        GridLayoutGroup gridLayout = puzzleField.GetComponent<GridLayoutGroup>();
        if (gridLayout != null)
        {
            gridLayout.constraintCount = 6;
        }
        modeGame = "medium";
        StartGame();
        GameController gameController = Object.FindFirstObjectByType<GameController>();
        gameController.StartGame();
    }
    public void setHardCards()
    {
        Debug.Log("chamou a funcao setHardCards");
        cardsNumbers = 18;
        GridLayoutGroup gridLayout = puzzleField.GetComponent<GridLayoutGroup>();
        if (gridLayout != null)
        {
            gridLayout.constraintCount = 6;
            gridLayout.cellSize = new Vector2(160, 200);
        }
        modeGame = "hard";
        StartGame();
        GameController gameController = Object.FindFirstObjectByType<GameController>();
        gameController.StartGame();
    }
    void StartGame()
    {
        for (int i = 0; i < cardsNumbers; i++)
        {
            GameObject cards = Instantiate(crd);
            cards.name = "" + i;
            cards.transform.SetParent(puzzleField, false);
        }
    }
}
