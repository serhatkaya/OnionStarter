using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionStarter.Application.Interfaces.Contexts;

namespace OnionStarter.Application.Features.ProductFeatures.Commands;

public class UpdateProductCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (product == null)
            {
                return default;
            }
            else
            {
                product.Name = command.Name;
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}