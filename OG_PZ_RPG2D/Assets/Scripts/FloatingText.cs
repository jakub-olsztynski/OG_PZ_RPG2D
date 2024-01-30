using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //zastepuje poprzednie dependency, wywala³o siê z NullPointerException i nie chce mi siê tego naprawiaæ, straci³em 6 godzin ¿ycia na to g

public class FloatingText //wywali³em : MonoBehaviour, za du¿o by³o i udawa³o mu siê zawalaæ pamiêæ (???)
{
    public bool active;
    public GameObject go;
    public TextMeshProUGUI txt; //<MOZLIWE ZE POWINNO BYC TextMeshProUGUI  zamiast Text>samo Text nie dzia³a mimo tego co mówi¹ ludzie w 50 threadach, podmini³em
    public Vector3 motion;
    public float duration;
    public float lastShown;
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    public void Hide()
    {
        active=false;
        go.SetActive(active);
    }
    public void UpdateFloatingText()
    {
        if (!active) //jeœli nieaktywne, wyjdŸ
            return;
        if(Time.time - lastShown > duration) //wiadomo, jeœli wygaœnie to ukryj
            Hide();
        go.transform.position += motion * Time.deltaTime; //to jest prostsze ni¿ wygl¹da, motion to Vector3 do góry, tekst jedzie do góry

    }
}
