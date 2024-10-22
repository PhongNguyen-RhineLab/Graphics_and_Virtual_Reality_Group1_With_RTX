using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public TextMeshProUGUI category;
    public TextMeshProUGUI name;
    public TextMeshProUGUI authorname;
    public TextMeshProUGUI instructor;

    public void SetScore(string category, string name, string authorname, string instructor)
    {
        this.category.GetComponent<TextMeshProUGUI>().text = category;
        this.name.GetComponent<TextMeshProUGUI>().text = name;
        this.authorname.GetComponent<TextMeshProUGUI>().text = authorname;
        this.instructor.GetComponent<TextMeshProUGUI>().text = instructor;
    }
}
