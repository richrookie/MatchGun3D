public class Define
{
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

    public enum eGunName : byte
    {
        HandGun,
        ShotGun,
        AutoRifle,
        Sniper,
        Bazooka,

        MaxCount
    }

    public enum eGunType : byte
    {
        HandGun00,
        Shotgun00,
        AutoRifle00,
        Sniper00,
        Bazooka00,

        HandGun01,
        Shotgun01,
        AutoRifle01,
        Sniper01,
        Bazooka01,

        HandGun02,
        Shotgun02,
        AutoRifle02,
        Sniper02,
        Bazooka02,

        HandGunIAP00,
        ShotGunIAP00,
        AutoRifleIAP00,
        SniperIAP00,
        BazookaIAP00,

        MaxCount
    }
    public enum eGunSprite : byte
    {
        Count_HandGun00,
        Count_AutoRifle00,
        Count_Shotgun00,
        Count_Sniper00,
        Count_Bazooka00,

        Count_HandGun01,
        Count_AutoRifle01,
        Count_Shotgun01,
        Count_Sniper01,
        Count_Bazooka01,

        Count_HandGun02,
        Count_AutoRifle02,
        Count_Shotgun02,
        Count_Sniper02,
        Count_Bazooka02,

        Count_HandGunIAP00,
        Count_AutoRifleIAP00,
        Count_ShotgunIAP00,
        Count_SniperIAP00,
        Count_BazookaIAP00,

        MaxCount
    }
    public enum eGunRunType : byte
    {
        RunHandGun00,
        RunAutoRifle00,
        RunShotgun00,
        RunSniper00,
        RunBazooka00,

        RunHandGun01,
        RunAutoRifle01,
        RunShotgun01,
        RunSniper01,
        RunBazooka01,

        RunHandGun02,
        RunAutoRifle02,
        RunShotgun02,
        RunSniper02,
        RunBazooka02,

        RunHandGunIAP00,
        RunAutoRifleIAP00,
        RunShotgunIAP00,
        RunSniperIAP00,
        RunBazookaIAP00,


        MaxCount
    }
    public enum eBulletType : byte
    {
        BulletHandgun00,
        BulletAutoRifle00,
        BulletShotgun00,
        BulletSniper00,
        BulletBazooka00,

        BulletHandgun01,
        BulletAutoRifle01,
        BulletShotgun01,
        BulletSniper01,
        BulletBazooka01,

        BulletHandgun02,
        BulletAutoRifle02,
        BulletShotgun02,
        BulletSniper02,
        BulletBazooka02,

        BulletHandgunIAP00,
        BulletAutoRifleIAP00,
        BulletShotgunIAP00,
        BulletSniperIAP00,
        BulletBazookaIAP00,
    }
    // public enum eGunRewardType : byte
    // {
    //     Count_AutoRifle,
    //     Count_Sniper,
    //     Count_Bazooka,

    //     MaxCount
    // }

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

    public enum eShopCurMenu : byte
    {
        HandGun,
        ShotGun,
        AutoRifle,
        Sniper,
        Bazooka,
        PayGun,

        MaxCount
    }
}
