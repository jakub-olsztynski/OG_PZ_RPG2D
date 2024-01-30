using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)

    {
        if (coll.name == "Player") //sprawdza czy to gracz zeby monsterki sie nie wala�y po planszy! Jak co� innego wlezie to bedzie error, juz sprawdza�em
        {
            //Teleport gracza
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
