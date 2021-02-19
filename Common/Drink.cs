using System;

namespace LutayCRUD.Common
{
    [Flags]
    public enum Drink
    {
        Tea = 1 << 0,
        Coffee = 1 << 1,
        Juice = 1 << 2,
        Water = 1 << 3,
    }
}
