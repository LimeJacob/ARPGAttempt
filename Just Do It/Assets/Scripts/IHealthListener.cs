public interface IHealthListener 
{
    public void NotifyDamaged();
    public void NotifyHealed();
    public void NotifyOutOfHealth();
}