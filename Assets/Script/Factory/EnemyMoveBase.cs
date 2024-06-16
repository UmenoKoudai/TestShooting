public interface EnemyMoveBase
{
    public float Speed { get; set; }
    public float Radius { get; set; }
    public float RotateX { get; set; }
    public float RotateY { get; set; }
    public ShipBase Ship { get; set; }

    public abstract void Init();
    public abstract void Move();
}
