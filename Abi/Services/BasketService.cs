using Abi.Abstractions;
using Abi.Contexts;
using Abi.ViewModels.BasketViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Abi.Services
{
    public class BasketService(AppDbContext _context, IHttpContextAccessor _accessor) : IBasketService
    {
        public async Task<List<BasketItemVM>> GetBasketItemsAsync()
        {
            string userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
            var isExistUser = await _context.Users.AnyAsync(x => x.Id == userId);
            if (!isExistUser)
            {
                return [];
            }
            var basketItems = await _context.BasketItems
            .Where(x => x.AppUserId == userId)
            .Include(x => x.Product)
            .Select(x => new BasketItemVM
            {
                Id = x.ProductId,
                Name = x.Product!.Name,
                Image = x.Product.MainImageUrl,
                Price = x.Product.Price,
                Count = x.Count
            })
            .ToListAsync();
            return basketItems;
        }
    }
}
