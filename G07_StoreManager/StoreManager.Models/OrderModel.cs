namespace StoreManager.Models;

public record OrderModel(int id,DateTime OrderDate,DateTime? Shipdate,string? Shipaddress);