namespace StoreManager.Models;

public record OrderModel(int Id, DateTime OrderDate, DateTime? ShippedDate, string? ShipAddress);