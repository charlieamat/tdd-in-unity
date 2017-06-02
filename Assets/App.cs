using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private Image _image;
    private Heart _heart;

    private void Start()
    {
        _heart = new Heart(_image);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _heart.Replenish(1); 
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _heart.Deplete(1); 
        }
    }
}