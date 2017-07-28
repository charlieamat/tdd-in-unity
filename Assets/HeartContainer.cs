using System.Collections.Generic;

public class HeartContainer
{
    private readonly List<Heart> _hearts;

    public HeartContainer(List<Heart> hearts)
    {
        _hearts = hearts;
    }

    public void Replenish(int numberOfHeartPieces)
    {
        var numberOfHeartPiecesRemaining = numberOfHeartPieces;
        foreach (var heart in _hearts)
        {
            numberOfHeartPiecesRemaining -= Heart.HeartPiecesPerHeart - heart.CurrentNumberOfHeartPieces;
            heart.Replenish(numberOfHeartPieces);
            if (numberOfHeartPiecesRemaining <= 0) break;
        }
    }
}