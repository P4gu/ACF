using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles = new Sprite[9];
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> crds = new List<Button>();

    private bool firstGuess, secondGuess;
    private string firstGuessPuzzle, secondGuessPuzzle;

    private int firstGuessIndex, secondGuessIndex;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    void Start()
    {
        GetCards();
        AddListeners();
        AddGamePuzzle();
        Suffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }
    void GetCards()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleCard");

        foreach (GameObject obj in objects)
        {
            crds.Add(obj.GetComponent<Button>());
        }
    }
    void AddGamePuzzle()
    {
        int looper = crds.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach (Button card in crds)
        {
            card.onClick.AddListener(() => PickAPuzzle());
        }
    }
    public void PickAPuzzle()
    {
        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            crds[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            crds[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            StartCoroutine(CheckIfThePuzzleMatch());
        }
    }

    IEnumerator CheckIfThePuzzleMatch()
    {
        yield return new WaitForSeconds(.5f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            Debug.Log("Acerto miseravi");
            yield return new WaitForSeconds(.1f);
            crds[firstGuessIndex].interactable = false;
            crds[secondGuessIndex].interactable = false;
            crds[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            crds[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfTheGameFinished();
        }
        else
        {
            Debug.Log("Vacilou vacilão");
            yield return new WaitForSeconds(.1f);
            crds[firstGuessIndex].image.sprite = bgImage;
            crds[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(.1f);
        firstGuess = secondGuess = false;
    }
    void CheckIfTheGameFinished()
    {
        countCorrectGuesses++;
        countGuesses++;
        if (countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Fim de jogo");
            Debug.Log("Voce tentou " + gameGuesses + " vezes para conseguir finalizar o jogo.");
        }
        else
        {
            firstGuess = secondGuess = false;
        }
    }
    void Suffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
