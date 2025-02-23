using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    public GameObject initialGame;

    private Game currentGame;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }

        if(instance != this)
        {
            Destroy(instance);
        }

        currentGame = initialGame.GetComponent<Game>();
        currentGame.OnAwake();
    }

    void Start()
    {
        currentGame.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        currentGame.OnRunning();
    }

    public void changeGame(Game newGame){

        if (currentGame != null){
            currentGame.OnExit();
        }

        if(newGame != null){
            currentGame = newGame;
            currentGame.OnStart();
        }
    }

    public Game getCurrentGame(){
        return currentGame;
    }
}
