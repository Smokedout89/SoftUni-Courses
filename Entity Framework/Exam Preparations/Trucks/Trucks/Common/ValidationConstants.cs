namespace Trucks.Common;

public static class ValidationConstants
{
    // Truck
    public const int TruckRegNumberLength = 8;
    public const int TruckVinNumberLength = 17;
    public const int TruckTankMinCapacity = 950;
    public const int TruckTankMaxCapacity = 1420;
    public const int TruckCargoMinCapacity = 5000;
    public const int TruckCargoMaxCapacity = 29000;
    public const int TruckCategoryTypeMin = 0;
    public const int TruckCategoryTypeMax = 3;
    public const int TruckMakeTypeMin = 0;
    public const int TruckMakeTypeMax = 4;
    public const string TruckRegNumberRegex = @"^[A-Z]{2}\d{4}[A-Z]{2}$";

    // Client
    public const int ClientNameMinLength = 3;
    public const int ClientNameMaxLength = 40;
    public const int ClientNationalityMinLength = 2;
    public const int ClientNationalityMaxLength = 40;

    // Dispatcher
    public const int DispatcherNameMinLength = 2;
    public const int DispatcherNameMaxLength = 40;
}