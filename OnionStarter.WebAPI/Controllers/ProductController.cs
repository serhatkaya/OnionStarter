using Microsoft.AspNetCore.Mvc;
using OnionStarter.Application.Interfaces.Repositories;
using OnionStarter.Application.Interfaces.Services;
using OnionStarter.Domain.Entities;

namespace OnionStarter.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    readonly IProductRepository _productRepository;
    readonly IEmailService _emailService;

    public ProductController(IProductRepository productRepository, IEmailService emailService)
    {
        _productRepository = productRepository;
        _emailService = emailService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Product> allProducts = await _productRepository.GetAsync();
        return Ok(allProducts);
    }

    [HttpGet("send-email")]
    public IActionResult SendEmail()
    {
        bool result = _emailService.Send("root@serhatkaya.com.tr", "There is no place like 127.0.0.1");
        return Ok(result);
    }
}