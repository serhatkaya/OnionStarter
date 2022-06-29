using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Contexts;

namespace OnionStarter.Application.Features.ProductFeatures.Commands;

public class DeleteProductByIdCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductByIdCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
            if (product == null) return default;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}