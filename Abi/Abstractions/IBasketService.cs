using Abi.ViewModels.BasketViewModels;
using System.Threading.Tasks;

namespace Abi.Abstractions
{
    public interface IBasketService
    {
        Task<List<BasketItemVM>> GetBasketItemsAsync();
    }
}
