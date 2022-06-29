using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Contexts;
using OnionStarter.Domain.Entities;

namespace OnionStarter.Application.Features.ProductFeatures.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; set; }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == query.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product == null) return null;
            return product;
        }
    }
}