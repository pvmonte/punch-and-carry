using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class SellPoint : MonoBehaviour , IInteractionCollidable
    {
        [SerializeField] private LevelBag _bag;

        public void Collide(PlayerController player)
        {
            ThrowAtPoint(player.EnemyStack);
        }

        private async void ThrowAtPoint(EnemyStack stack)
        {
            if(stack.StackCount < 1) return;

            while (stack.StackCount > 0)
            {
                var popped = stack.PopCharacter();
                MoveThrowed(popped);
                await Awaitable.WaitForSecondsAsync(0.1f);
            }
        }

        private async void MoveThrowed(Transform throwed)
        {
            Vector3 startPosition = throwed.position;
            float lerp = 0;
            
            while (lerp < 1)
            {
                throwed.position = Vector3.Lerp(startPosition, transform.position, lerp);
                lerp += Time.deltaTime;
                await Awaitable.NextFrameAsync();
            }
            
            throwed.gameObject.SetActive(false);
            _bag.Earn(100);
        }
    }
}
