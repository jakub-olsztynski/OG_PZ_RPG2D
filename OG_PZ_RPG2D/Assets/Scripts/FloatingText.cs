using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //zastepuje poprzednie dependency, wywala�o si� z NullPointerException i nie chce mi si� tego naprawia�, straci�em 6 godzin �ycia na to g

public class FloatingText //wywali�em : MonoBehaviour, za du�o by�o i udawa�o mu si� zawala� pami�� (???)
{
    public bool active;
    public GameObject go;
    public TextMeshProUGUI txt; //<MOZLIWE ZE POWINNO BYC TextMeshProUGUI  zamiast Text>samo Text nie dzia�a mimo tego co m�wi� ludzie w 50 threadach, podmini�em
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
        if (!active) //je�li nieaktywne, wyjd�
            return;
        if(Time.time - lastShown > duration) //wiadomo, je�li wyga�nie to ukryj
            Hide();
        go.transform.position += motion * Time.deltaTime; //to jest prostsze ni� wygl�da, motion to Vector3 do g�ry, tekst jedzie do g�ry

    }
}
