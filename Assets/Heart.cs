using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Heart
{
    public static readonly int HeartPiecesPerHeart = 4;
    private const float FillPerHeartPiece = 0.25f;
    private readonly Image _image;

    public Heart(Image image)
    {
        _image = image;
    }

    public int CurrentNumberOfHeartPieces
    {
        get { return (int) (_image.fillAmount * HeartPiecesPerHeart); }
    }

    public void Replenish(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces");
        _image.fillAmount += numberOfHeartPieces * FillPerHeartPiece;
    }

    public void Deplete(int numberOfHeartPieces)
    {
        if (numberOfHeartPieces < 0) throw new ArgumentOutOfRangeException("numberOfHeartPieces");
        _image.fillAmount -= numberOfHeartPieces * FillPerHeartPiece;
    }

    public float Speed;
    public Transform transform;

    private void Update1()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var x = h * Speed * Time.deltaTime;
        var z = v * Speed * Time.deltaTime;

        transform.position += new Vector3(x, 0, z);
    }

    public Movement Movement;

    private void Update2()
    {
        transform.position += Movement.GetNextPosition(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"), 
            Time.deltaTime);
    }

    public Vector3 GetPositionAfterMovement(float h, float v, float delta)
    {
        return new Vector3(h*Speed*delta, 0, v);
    }
}

public class Movement
{
    public float Speed { get; set; }

    public Vector3 GetNextPosition(float h, float v, float delta)
    {
        var x = h * Speed * Time.deltaTime;
        var z = v * Speed * Time.deltaTime;

        return new Vector3(h, 0, v);
    }
}