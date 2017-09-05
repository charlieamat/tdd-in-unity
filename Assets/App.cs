using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private int _amount;

    private HeartContainer _heartContainer;

    private void Start()
    {
        _heartContainer = new HeartContainer(
            _images.Select(image => new Heart(image)).ToList());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _heartContainer.Replenish(_amount);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _heartContainer.Deplete(_amount);
        }
    }
}