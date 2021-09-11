using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.ApiServices
{
    public interface ICardApiService
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCard(string id);
        Task<Card> CreateCard(Card card);
        Task<Card> UpdateCard(Card card);
        Task DeleteCard(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
