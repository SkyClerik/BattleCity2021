public class BaseWall : Wall
{
    public override void SetDestroy()
    {        
        GameState.Instance.ThisGameOver();
        base.SetDestroy();
    }
}
