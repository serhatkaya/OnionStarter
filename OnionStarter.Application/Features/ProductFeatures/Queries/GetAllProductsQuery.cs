using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Contexts;
using OnionStarter.Domain.Entities;

namespace OnionStarter.Application.Features.ProductFeatures.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery query,
            CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            if (productList == null)
            {
                return null;
            }

            return productList.AsReadOnly();
        }
    }
}