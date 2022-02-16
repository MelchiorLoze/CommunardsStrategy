
public class HQ : Ally
{
    override public void Start()
    {
    }

    protected override void Die()
    {
        base.Die();
        BuildManager.instance.ChangeBackground();
    }
}