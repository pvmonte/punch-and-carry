using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class SellPoint : MonoBehaviour , IInteractionCollidable
    {
        [SerializeField] private LevelBag _bag;
        [SerializeField] private float throwInterval = 0.25f;
        [SerializeField] private float throwDuration = 0.5f;
        [SerializeField] private AnimationCurve throwHeightCurve;

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
                await Awaitable.WaitForSecondsAsync(throwInterval);
            }
        }

        private async void MoveThrowed(Transform throwed)
        {
            Vector3 startPosition = throwed.position;
            float heightStart = startPosition.y;
            float heightEnd = transform.position.y;
            float lerp = 0;
            
            while (lerp < 1)
            {
                var positionLerped = Vector3.Lerp(startPosition, transform.position, lerp);
                float evaluated = throwHeightCurve.Evaluate(lerp);
                positionLerped.y = Mathf.LerpUnclamped(heightStart, heightEnd, evaluated);
                throwed.position = positionLerped;
                lerp += Time.deltaTime / throwDuration;
                await Awaitable.NextFrameAsync();
            }
            
            throwed.gameObject.SetActive(false);
            _bag.Earn(100);
        }
    }
}
