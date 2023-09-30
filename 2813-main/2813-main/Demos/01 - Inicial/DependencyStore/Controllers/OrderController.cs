using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositorios;
using DependencyStore.Repositorios.Contratos;
using DependencyStore.Servicos.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;
using System.Runtime.ConstrainedExecution;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
    private readonly ICustomerRepositorio _customerRepositorio;
    private readonly IDeliveryFeeService _deliveryFeeService;
    private readonly IPromoCodeRepositorio _promoCodeRepositorio;

    public OrderController(
        ICustomerRepositorio customerRepositorio,
        IDeliveryFeeService deliveryFeeService,
        IPromoCodeRepositorio promoCodeRepositorio)
    {
        _customerRepositorio = customerRepositorio;
        _deliveryFeeService = deliveryFeeService;
        _promoCodeRepositorio = promoCodeRepositorio;

    }

    [Route("v1/orders")]
    [HttpPost]
    public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
    {
        // #1 - Recupera o cliente
        var customer = await _customerRepositorio.ObterIdAsync(customerId);
        if (customer == null)
            return NotFound();

        var deliveryFee = await _deliveryFeeService.ObterTaxaEntregaAsync(zipCode);
        var cupom = await _promoCodeRepositorio.ObterPromoCodeAsync(promoCode);
        var discount = cupom?.Value ?? 0M;
        var order = new Order(deliveryFee, discount, new List<Product>());
        return Ok($"Pedido {order.Code} gerado com sucesso!");

        
    }
}