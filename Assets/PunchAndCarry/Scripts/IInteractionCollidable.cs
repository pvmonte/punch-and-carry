namespace PunchAndCarry.Scripts
{
    public interface IInteractionCollidable
    {
    }

    public interface IInteractionCollidable<in T> : IInteractionCollidable
    {
        public void Collide(T interactor);
    }
}