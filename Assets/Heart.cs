using System;
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

    public int FilledHeartPieces
    {
        get { return CalculateFilledHeartPieces(); }
    }

    public int EmptyHeartPieces
    {
        get { return HeartPiecesPerHeart - CalculateFilledHeartPieces(); }
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

    private int CalculateFilledHeartPieces()
    {
        return (int) (_image.fillAmount * HeartPiecesPerHeart);
    }
}