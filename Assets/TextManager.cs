using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdown;

    public bool doneCounting = false;

    public bool doneDeclaringWinner = false;
    // Start is called before the first frame update

    public IEnumerator UpdateCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        var counter = 3;
        while(counter > 0)
        {
            _countdown.SetText(counter.ToString());
            counter--;
            yield return new WaitForSeconds(1);
        }
        _countdown.SetText("SAUSAGE TIME!");
        yield return new WaitForSeconds(1);
        _countdown.SetText("");
        doneCounting = true;
    }
    public IEnumerator DoGameOver()
    {
        yield return new WaitForSeconds(1);
        _countdown.SetText($"GAME OVER!");
        yield return new WaitForSeconds(3);
        doneDeclaringWinner = true;
    }
    public IEnumerator DoWinner(string name)
    {
        _countdown.SetText($"{name.Split("(")[0]} WON!");
        yield return new WaitForSeconds(1.25f);
        if (_countdown.text == $"{name.Split("(")[0]} WON!")
        {
            _countdown.SetText("");
        }
    }
}
