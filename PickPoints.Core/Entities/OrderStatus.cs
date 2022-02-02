namespace PickPoints.Core.Entities
{
    public enum OrderStatus
    {
        /// <summary>Зарегистрирован</summary>
        Registered = 1,

        /// <summary>Принят на складе</summary>
        TakenToWarehouse = 2,

        /// <summary>Выдан курьеру</summary>
        IssuedToCourier = 3,

        /// <summary>Доставлен в постамат</summary>
        DeliveredToPostamt = 4,

        /// <summary>Доставлен получателю</summary>
        DeliveredToRecipient = 5,

        /// <summary>Отменен</summary>
        Canceled = 6
    }
}
