public static class AvatarCollection
{
    private static AvatarData[] _players = new AvatarData[3];
    //public static AvatarData[] Players { get => _players; set => _players = value; }
    //TODO А это тут надо вообще?
    public static void SetPlayer(AvatarData avatarData, Belong belong)
    {
        _players[(byte)belong] = avatarData;
    }
}

public enum Belong : byte
{
    PlayerA = 1,
    PlayerB = 2,
    PlayerC = 3,
}
