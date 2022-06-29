using MediatR;
using OnionStarter.Application.Interfaces.Contexts;
using OnionStarter.Domain.Entities;

namespace OnionStarter.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateProductCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Name = command.Name;
                product.Description = command.Description;
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}