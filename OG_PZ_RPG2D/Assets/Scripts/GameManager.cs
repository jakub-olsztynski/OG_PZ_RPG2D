using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null) //zapobiega EWENTUALNEJ (jakims cudem) duplikacji GM. Jedyny sposob zeby zduplikowac to zaladowac dwa razy MainScene
        {
            Debug.Log("EmergencyDestroyManager");
            Destroy(gameObject);
            return;
        }
        Debug.Log("EnterManager");
        //SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject); //rozwiazuje problem duplikacji skryptow w przejsciu w scenach
        instance = this; //zeby zawsze widzialo ten skrypt jak wywoluje instance GameManager
    }
    
    //Resourcy tutaj

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrice;
    public List<int> xpTable;

    //Referencje tutaj
    public Player player;
    //public Weapon weapon; //TODO

    //obs³uga FloatingText
    public FloatingTextManager floatingText;
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) //do FloatingText ofc //<int fontSize, Color color> wykomentowane
    {
        floatingText.Show(msg, fontSize, color, position, motion, duration);
    }

    //Scene s;//LEPIEJ TO USUN

    //Logika
    public int pesos;
    public int experience;
    
    //Obsluga Save/Load State
    public void SaveState()
    {
        
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0" + "|";
        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("SaveState");
        //TODO: skin, level broni
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("NoSaveState, cancelled loading");
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //TODO changeskin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //TODO change weapon broni
        //SceneManager.sceneLoaded -= LoadState; //wywalone bo robilo problem z GameManagerem duplikacje
        Debug.Log("LoadState");
        //playerSprites.Clear();
    }
    

}
