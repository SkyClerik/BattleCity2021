using UnityEngine;

namespace Extensions
{
    public static class AvatarDataExt
    {
        public static void SetRotation(this AvatarData avatarData, Vector3 targetPosition)
        {
            var heading = targetPosition - avatarData.transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            direction.y = 0;
            avatarData.transform.rotation = Quaternion.LookRotation(direction);
        }

        public static void SetRotationFast(this AvatarData avatarData, Vector3 direction)
        {
            if (direction != Vector3.zero)
                avatarData.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}