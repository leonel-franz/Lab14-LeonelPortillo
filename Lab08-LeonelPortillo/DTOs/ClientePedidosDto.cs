namespace Lab08_LeonelPortillo.DTOs;

public class ClientePedidosDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public int TotalOrders { get; set; }
}