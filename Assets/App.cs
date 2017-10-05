using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private int _amount;

    private HeartContainer _heartContainer;
    private Player _player;

    private void Start()
    {
        _player = new Player(20, 20);
        _heartContainer = new HeartContainer(
            _images.Select(image => new Heart(image)).ToList());

        _player.Healed += (sender, args) => _heartContainer.Replenish(args.Amount);
        _player.Damaged += (sender, args) => _heartContainer.Deplete(args.Amount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _player.Heal(_amount);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _player.Damage(_amount);
        }
    }
}