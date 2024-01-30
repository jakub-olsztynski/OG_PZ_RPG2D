using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)

    {
        if (coll.name == "Player") //sprawdza czy to gracz zeby monsterki sie nie wala³y po planszy! Jak coœ innego wlezie to bedzie error, juz sprawdza³em
        {
            //Teleport gracza
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
