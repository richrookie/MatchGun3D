public class Define
{
    public static int SpawnCount = 16;

    public enum eGameState : byte
    {
        Ready,
        Play_Match,
        End_Match,
        Play_Run,
        End
    }

    public enum eScene : byte
    {
        Unknown,
        Loading,
        Game,
    }

    public enum eSound : byte
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent : byte
    {
        Click,
        Drag,
        Up,
        Down,
    }

    public enum eLanguage : byte
    {
        Kor,
        Eng,
    }
    public enum eObjectType : byte
    {
        NotAssigned,
        GameObject,
        TextMesh,
        Image,
        Button,
        Text,
    }

    public static float BOUND = 0.5f;
    public static float ROULLETE_GUNIMG_SPEED = 200f;

    public enum eGunName : byte
    {
        HandGun,
        ShotGun,
        AutoRifle,

        MaxCount
    }

    public enum eGunType : byte
    {
        HandGun,
        Shotgun,
        AutoRifle,

        MaxCount
    }
    public enum eGunSprite : byte
    {
        Count_HandGun00,
        Count_AutoRifle00,
        Count_Shotgun00,

        MaxCount
    }
    public enum eGunRunType : byte
    {
        RunHandGun00,
        RunAutoRifle00,
        RunShotgun00,

        MaxCount
    }
    public enum eBulletType : byte
    {
        BulletHandgun00,
        BulletAutoRifle00,
        BulletShotgun00,

        MaxCount
    }

    public enum eObstacleType : byte
    {
        Piller,
        EndBlockRunPart,

        MaxCount
    }

    public enum ePillerType : byte
    {
        Damage,
        FireRate,
        MaxCount
    }

    public enum eSprayType : byte
    {
        Single,
        Triple,
        MaxCount
    }
}
